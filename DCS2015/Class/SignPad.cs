// Copyright 2000-2015, signotec GmbH, Ratingen, Germany, All Rights Reserved
// signotec GmbH
// Am Gierath 20b
// 40885 Ratingen
// Tel: +49 (2102) 5 35 75-10
// Fax: +49 (2102) 5 35 75-39
// E-Mail: <info@signotec.de>
//
//-----------------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following _disclaimer.
//   * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following _disclaimer in the documentation
//     and/or other materials provided with the distribution.
//   * Neither the name of the signotec GmbH nor the names of its contributors
//     may be used to endorse or promote products derived from this software
//     without specific prior written permission.
//
// THIS SOFTWARE ONLY DEMONSTRATES HOW TO IMPLEMENT SIGNOTEC SOFTWARE COMPONENTS
// AND IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
// OF THE POSSIBILITY OF SUCH DAMAGE.
//-----------------------------------------------------------------------------
//
// Version: 8.1.4.4
// Date:    2015-04-16

using System;
using System.Collections.Generic;
using System.Text;

namespace DCS2015.Class
{
    public class SignPad
    {
        private AxSTPadCaptLib.AxSTPadCapt _axSTPadCapt = null;
        private int _index = -1;
        private int _padType = 0;
        private int _connectionType = 0;
        private string _serial = null;
        private int _fwMajor = 0;
        private int _fwMinor = 0;
        private bool _open = false;

        public SignPad()
        {
            _serial = "";
        }

        public SignPad(AxSTPadCaptLib.AxSTPadCapt axSTPadCapt, int index)
        {
            _axSTPadCapt = axSTPadCapt;
            _axSTPadCapt.DeviceDisconnected += new AxSTPadCaptLib._DSTPadCaptEvents_DeviceDisconnectedEventHandler(axSTPadCapt_DeviceDisconnected);
            _index = index;

            // get serial and type of selected device
            int rc = _axSTPadCapt.DeviceGetInfo(ref _serial, ref _padType, index);
            if (rc < 0)
                throw new STPadException(rc, axSTPadCapt);

            // get connection type
            rc = _axSTPadCapt.DeviceGetConnectionType(index);
            if (rc < 0)
                throw new STPadException(rc, axSTPadCapt);
            _connectionType = rc;

            // get firmware version
            string version = "";
            rc = _axSTPadCapt.DeviceGetVersion(ref version, index);
            if (rc < 0)
                throw new STPadException(rc, axSTPadCapt);
            string[] versionArray = version.Split('.');
            if ((versionArray != null) && (versionArray.Length > 1))
            {
                _fwMajor = Int32.Parse(versionArray[0]);
                _fwMinor = Int32.Parse(versionArray[1]);
            }
        }

        ~SignPad()
        {
            _axSTPadCapt.DeviceDisconnected -= new AxSTPadCaptLib._DSTPadCaptEvents_DeviceDisconnectedEventHandler(axSTPadCapt_DeviceDisconnected);
        }

        public int PadType
        {
            get { return _padType; }
        }

        public string PadName
        {
            get
            {
                switch (_padType)
                {
                    case 1:
                        return "Sigma HID";
                    case 2:
                        return "Sigma Serial";
                    case 11:
                        return "Omega HID";
                    case 12:
                        return "Omega Serial";
                    case 31:
                        return "Alpha USB";
                    case 32:
                        return "Alpha Serial";
                    case 33:
                        return "Alpha IP";
                    default:
                        return "Unkown pad type " + _padType;
                }
            }
        }

        public bool Sigma
        {
            get
            {
                switch (_padType)
                {
                    case 1:
                    case 2:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool Omega
        {
            get
            {
                switch (_padType)
                {
                    case 11:
                    case 12:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool Alpha
        {
            get
            {
                switch (_padType)
                {
                    case 31:
                    case 32:
                    case 33:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public string ConnectionName
        {
            get
            {
                switch (_connectionType)
                {
                    case 0:
                        return "HID";
                    case 1:
                        return "USB";
                    case 2:
                        int rc = _axSTPadCapt.DeviceGetComPort(_index);
                        if (rc < 0)
                            throw new STPadException(rc, _axSTPadCapt);
                        return String.Format("Port: COM{0}", rc);
                    case 3:
                        string strAddress = "";
                        rc = _axSTPadCapt.DeviceGetIPAddress(ref strAddress, _index);
                        if (rc < 0)
                            throw new STPadException(rc, _axSTPadCapt);
                        return string.Format("IP: {0}", strAddress);
                    default:
                        return "Unkown connection type " + _connectionType;
                }
            }
        }

        public bool USB
        {
            get { return (_connectionType == 1); }
        }

        public bool IP
        {
            get { return (_connectionType == 3); }
        }

        public string Serial
        {
            get { return _serial; }
        }

        public string Firmware
        {
            get { return String.Format("{0}.{1}", _fwMajor, _fwMinor); }
        }

        public int DefaultPenWidth
        {
            get { return (Omega ? 2 : 1); }
        }

        public int DefaultFontSize
        {
            get { return (Sigma ? 20 : 40); }
        }

        public bool HasColorDisplay
        {
            get { return (Omega || Alpha); }
        }

        public bool SupportsVerticalScrolling
        {
            get { return (Omega || (Alpha && IsFirmware(1, 8))); }
        }

        public bool SupportsHorizontalScrolling
        {
            get { return (Alpha && IsFirmware(1, 8)); }
        }

        public bool SupportsServiceMenu
        {
            get { return Alpha; }
        }

        public bool SupportsRSA
        {
            get { return ((Sigma && IsFirmware(1, 16)) || (Omega && IsFirmware(1, 25)) || Alpha); }
        }

        public bool SupportsContentSigning
        {
            get { return ((Sigma && IsFirmware(1, 16)) || (Omega && IsFirmware(1, 25)) || (Alpha && IsFirmware(1, 8))); }
        }

        public bool SupportsH2ContentSigning
        {
            get { return ((Sigma && IsFirmware(1, 21)) || (Omega && IsFirmware(1, 31)) || (Alpha && IsFirmware(1, 8))); }
        }

        public bool Open
        {
            get {return _open;}
        }

        private bool IsFirmware(int fwMajor, int fwMinor)
        {
            return ((_fwMajor > fwMajor) || ((_fwMajor == fwMajor) && (_fwMinor >= fwMinor)));
        }

        public void DeviceOpen()
        {
            if (!(Sigma || Omega || Alpha))
                throw new STPadException("This pad type is not supported by this demo application!");

            int rc = _axSTPadCapt.DeviceOpen(_index);
            if (rc < 0)
                throw new STPadException(rc, _axSTPadCapt);
            _open = true;
        }

        public void DeviceClose()
        {
            int rc = _axSTPadCapt.DeviceClose(_index);
            if ((rc < 0) && (!(rc == -5) || (rc == -22)))
                throw new STPadException(rc, _axSTPadCapt);
            _open = false;
        }

        private void axSTPadCapt_DeviceDisconnected(object sender, AxSTPadCaptLib._DSTPadCaptEvents_DeviceDisconnectedEvent e)
        {
            if (e.nIndex == _index)
                _open = false;
        }
    }
}
