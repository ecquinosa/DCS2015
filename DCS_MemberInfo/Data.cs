
using System;
using System.Data;
using System.Text;
using System.IO;

namespace DCS_MemberInfo
{
    public class Data
    {
        public static string AssemblyNameAndProductVersion
        {
            get
            {
                string attributes = System.Reflection.Assembly.GetExecutingAssembly().FullName;
                return attributes;
            }
        }

        private static string _OperatorID = "";
        private static string _TerminalName = "";
        private static string _SessionReference = "";
        private static string _UserRole = "";        
        private static string _MemberID = "";        

        private static DataTable _dtMemberInfo;

        private static string _MemberDataXMLFile = "";
        private static string _MemberDataSingleFile = "";

        private static string _PhotoRawFile = "";
        private static string _PhotoICAOFile = "";

        private static string _SignatureFile = "";

        private static string _BiometricLeftPinkyFileJPG = "";
        private static string _BiometricLeftPinkyFileANSI378 = "";
        private static string _BiometricLeftPinkyFileWSQ = "";
        private static string _BiometricLeftPinkyQualityScore = "";

        private static string _BiometricLeftRingFileJPG = "";
        private static string _BiometricLeftRingFileANSI378 = "";
        private static string _BiometricLeftRingFileWSQ = "";
        private static string _BiometricLeftRingQualityScore = "";

        private static string _BiometricLeftMiddleFileJPG = "";
        private static string _BiometricLeftMiddleFileANSI378 = "";
        private static string _BiometricLeftMiddleFileWSQ = "";
        private static string _BiometricLeftMiddleQualityScore = "";

        private static string _BiometricLeftPrimaryFileJPG = "";
        private static string _BiometricLeftPrimaryFileANSI378 = "";
        private static string _BiometricLeftPrimaryFileWSQ = "";
        private static string _BiometricLeftPrimaryQualityScore = "";

        private static string _BiometricLeftThumbFileJPG = "";
        private static string _BiometricLeftThumbFileANSI378 = "";
        private static string _BiometricLeftThumbFileWSQ = "";
        private static string _BiometricLeftThumbQualityScore = "";

        private static string _BiometricRightPrimaryFileJPG = "";
        private static string _BiometricRightPrimaryFileANSI378 = "";
        private static string _BiometricRightPrimaryFileWSQ = "";
        private static string _BiometricRightPrimaryQualityScore = "";

        private static string _BiometricRightThumbFileJPG = "";
        private static string _BiometricRightThumbFileANSI378 = "";
        private static string _BiometricRightThumbFileWSQ = "";
        private static string _BiometricRightThumbQualityScore = "";

        private static string _BiometricRightMiddleFileJPG = "";
        private static string _BiometricRightMiddleFileANSI378 = "";
        private static string _BiometricRightMiddleFileWSQ = "";
        private static string _BiometricRightMiddleQualityScore = "";

        private static string _BiometricRightRingFileJPG = "";
        private static string _BiometricRightRingFileANSI378 = "";
        private static string _BiometricRightRingFileWSQ = "";
        private static string _BiometricRightRingQualityScore = "";

        private static string _BiometricRightPinkyFileJPG = "";
        private static string _BiometricRightPinkyFileANSI378 = "";
        private static string _BiometricRightPinkyFileWSQ = "";
        private static string _BiometricRightPinkyQualityScore = "";

        private static string _LeftPinkyCode = "";
        private static string _LeftRingCode = "";
        private static string _LeftMiddleCode = "";
        private static string _LeftPrimaryCode = "";
        private static string _LeftThumbCode = "";

        private static string _RightPinkyCode = "";
        private static string _RightRingCode = "";
        private static string _RightMiddleCode = "";
        private static string _RightPrimaryCode = "";
        private static string _RightThumbCode = "";

        private static string _SupervisorOverrideApprover = "";
        private static bool _PhotoOverride = false;
        private static bool _SignatureOverride = false;
        private static bool _IsICAO = true;
        private static bool _IsCheckSingleFile = false;
        private static double _PhotoScore;

        private static string _capturedDataRepo = "";

        public static string CapturedDataRepo
        {
            get { return _capturedDataRepo; }
            set { _capturedDataRepo = value; }
        }


        public static string OperatorID
        {
            get { return _OperatorID; }
            set { _OperatorID = value; }
        }

        public static string TerminalName
        {
            get { return _TerminalName; }
            set { _TerminalName = value; }
        }

        public static string SessionReference
        {
            get { return _SessionReference; }
            set { _SessionReference = value; }
        }

        public static string UserRole
        {
            get { return _UserRole; }
            set { _UserRole = value; }
        }

        public static string SupervisorOverrideApprover
        {
            get { return _SupervisorOverrideApprover; }
            set { _SupervisorOverrideApprover = value; }
        }

        public static string MemberID
        {
            get { return _MemberID; }
            set { _MemberID = value; }
        }

        public static DataTable MemberInfo
        {
            get { return _dtMemberInfo; }
            set { _dtMemberInfo = value; }
        }

        public static string MemberDataXMLFile
        {
            get { return _MemberDataXMLFile; }
            set { _MemberDataXMLFile = value; }
        }

        public static string MemberDataSingleFile
        {
            get { return _MemberDataSingleFile; }
            set { _MemberDataSingleFile = value; }
        }

        public static string PhotoRawFile
        {
            get { return _PhotoRawFile; }
            set { _PhotoRawFile = value; }
        }

        public static string PhotoICAOFile
        {
            get { return _PhotoICAOFile; }
            set { _PhotoICAOFile = value; }
        }

        public static string SignatureFile
        {
            get { return _SignatureFile; }
            set { _SignatureFile = value; }
        }

        public static string BiometricLeftPrimaryFileJPG
        {
            get { return _BiometricLeftPrimaryFileJPG; }
            set { _BiometricLeftPrimaryFileJPG = value; }
        }

        public static string BiometricLeftPrimaryFileANSI378
        {
            get { return _BiometricLeftPrimaryFileANSI378; }
            set { _BiometricLeftPrimaryFileANSI378 = value; }
        }

        public static string BiometricLeftPrimaryFileWSQ
        {
            get { return _BiometricLeftPrimaryFileWSQ; }
            set { _BiometricLeftPrimaryFileWSQ = value; }
        }

        public static string BiometricLeftPrimaryQualityScore
        {
            get { return _BiometricLeftPrimaryQualityScore; }
            set { _BiometricLeftPrimaryQualityScore = value; }
        }

        public static string BiometricLeftMiddleFileJPG
        {
            get { return _BiometricLeftMiddleFileJPG; }
            set { _BiometricLeftMiddleFileJPG = value; }
        }

        public static string BiometricLeftMiddleFileANSI378
        {
            get { return _BiometricLeftMiddleFileANSI378; }
            set { _BiometricLeftMiddleFileANSI378 = value; }
        }

        public static string BiometricLeftMiddleFileWSQ
        {
            get { return _BiometricLeftMiddleFileWSQ; }
            set { _BiometricLeftMiddleFileWSQ = value; }
        }

        public static string BiometricLeftMiddleQualityScore
        {
            get { return _BiometricLeftMiddleQualityScore; }
            set { _BiometricLeftMiddleQualityScore = value; }
        }

        public static string BiometricLeftRingFileJPG
        {
            get { return _BiometricLeftRingFileJPG; }
            set { _BiometricLeftRingFileJPG = value; }
        }

        public static string BiometricLeftRingFileANSI378
        {
            get { return _BiometricLeftRingFileANSI378; }
            set { _BiometricLeftRingFileANSI378 = value; }
        }

        public static string BiometricLeftRingFileWSQ
        {
            get { return _BiometricLeftRingFileWSQ; }
            set { _BiometricLeftRingFileWSQ = value; }
        }

        public static string BiometricLeftRingQualityScore
        {
            get { return _BiometricLeftRingQualityScore; }
            set { _BiometricLeftRingQualityScore = value; }
        }

        public static string BiometricLeftPinkyFileJPG
        {
            get { return _BiometricLeftPinkyFileJPG; }
            set { _BiometricLeftPinkyFileJPG = value; }
        }

        public static string BiometricLeftPinkyFileANSI378
        {
            get { return _BiometricLeftPinkyFileANSI378; }
            set { _BiometricLeftPinkyFileANSI378 = value; }
        }

        public static string BiometricLeftPinkyFileWSQ
        {
            get { return _BiometricLeftPinkyFileWSQ; }
            set { _BiometricLeftPinkyFileWSQ = value; }
        }

        public static string BiometricLeftPinkyQualityScore
        {
            get { return _BiometricLeftPinkyQualityScore; }
            set { _BiometricLeftPinkyQualityScore = value; }
        }

        public static string BiometricLeftThumbFileJPG
        {
            get { return _BiometricLeftThumbFileJPG; }
            set { _BiometricLeftThumbFileJPG = value; }
        }

        public static string BiometricLeftThumbFileANSI378
        {
            get { return _BiometricLeftThumbFileANSI378; }
            set { _BiometricLeftThumbFileANSI378 = value; }
        }

        public static string BiometricLeftThumbFileWSQ
        {
            get { return _BiometricLeftThumbFileWSQ; }
            set { _BiometricLeftThumbFileWSQ = value; }
        }

        public static string BiometricLeftThumbQualityScore
        {
            get { return _BiometricLeftThumbQualityScore; }
            set { _BiometricLeftThumbQualityScore = value; }
        }

        public static string BiometricRightPrimaryFileJPG
        {
            get { return _BiometricRightPrimaryFileJPG; }
            set { _BiometricRightPrimaryFileJPG = value; }
        }

        public static string BiometricRightPrimaryFileANSI378
        {
            get { return _BiometricRightPrimaryFileANSI378; }
            set { _BiometricRightPrimaryFileANSI378 = value; }
        }

        public static string BiometricRightPrimaryFileWSQ
        {
            get { return _BiometricRightPrimaryFileWSQ; }
            set { _BiometricRightPrimaryFileWSQ = value; }
        }

        public static string BiometricRightPrimaryQualityScore
        {
            get { return _BiometricRightPrimaryQualityScore; }
            set { _BiometricRightPrimaryQualityScore = value; }
        }

        public static string BiometricRightMiddleFileJPG
        {
            get { return _BiometricRightMiddleFileJPG; }
            set { _BiometricRightMiddleFileJPG = value; }
        }

        public static string BiometricRightMiddleFileANSI378
        {
            get { return _BiometricRightMiddleFileANSI378; }
            set { _BiometricRightMiddleFileANSI378 = value; }
        }

        public static string BiometricRightMiddleFileWSQ
        {
            get { return _BiometricRightMiddleFileWSQ; }
            set { _BiometricRightMiddleFileWSQ = value; }
        }

        public static string BiometricRightMiddleQualityScore
        {
            get { return _BiometricRightMiddleQualityScore; }
            set { _BiometricRightMiddleQualityScore = value; }
        }

        public static string BiometricRightRingFileJPG
        {
            get { return _BiometricRightRingFileJPG; }
            set { _BiometricRightRingFileJPG = value; }
        }

        public static string BiometricRightRingFileANSI378
        {
            get { return _BiometricRightRingFileANSI378; }
            set { _BiometricRightRingFileANSI378 = value; }
        }

        public static string BiometricRightRingFileWSQ
        {
            get { return _BiometricRightRingFileWSQ; }
            set { _BiometricRightRingFileWSQ = value; }
        }

        public static string BiometricRightRingQualityScore
        {
            get { return _BiometricRightRingQualityScore; }
            set { _BiometricRightRingQualityScore = value; }
        }

        public static string BiometricRightPinkyFileJPG
        {
            get { return _BiometricRightPinkyFileJPG; }
            set { _BiometricRightPinkyFileJPG = value; }
        }

        public static string BiometricRightPinkyFileANSI378
        {
            get { return _BiometricRightPinkyFileANSI378; }
            set { _BiometricRightPinkyFileANSI378 = value; }
        }

        public static string BiometricRightPinkyFileWSQ
        {
            get { return _BiometricRightPinkyFileWSQ; }
            set { _BiometricRightPinkyFileWSQ = value; }
        }

        public static string BiometricRightPinkyQualityScore
        {
            get { return _BiometricRightPinkyQualityScore; }
            set { _BiometricRightPinkyQualityScore = value; }
        }

        public static string BiometricRightThumbFileJPG
        {
            get { return _BiometricRightThumbFileJPG; }
            set { _BiometricRightThumbFileJPG = value; }
        }

        public static string BiometricRightThumbFileANSI378
        {
            get { return _BiometricRightThumbFileANSI378; }
            set { _BiometricRightThumbFileANSI378 = value; }
        }

        public static string BiometricRightThumbFileWSQ
        {
            get { return _BiometricRightThumbFileWSQ; }
            set { _BiometricRightThumbFileWSQ = value; }
        }

        public static string BiometricRightThumbQualityScore
        {
            get { return _BiometricRightThumbQualityScore; }
            set { _BiometricRightThumbQualityScore = value; }
        }

        public static string LeftPinkyCode
        {
            get { return _LeftPinkyCode; }
            set { _LeftPinkyCode = value; }
        }

        public static string LeftRingCode
        {
            get { return _LeftRingCode; }
            set { _LeftRingCode = value; }
        }

        public static string LeftMiddleCode
        {
            get { return _LeftMiddleCode; }
            set { _LeftMiddleCode = value; }
        }

        public static string LeftPrimaryCode
        {
            get { return _LeftPrimaryCode; }
            set { _LeftPrimaryCode = value; }
        }

        public static string LeftThumbCode
        {
            get { return _LeftThumbCode; }
            set { _LeftThumbCode = value; }
        }

        public static string RightMiddleCode
        {
            get { return _RightMiddleCode; }
            set { _RightMiddleCode = value; }
        }

        public static string RightRingCode
        {
            get { return _RightRingCode; }
            set { _RightRingCode = value; }
        }

        public static string RightPinkyCode
        {
            get { return _RightPinkyCode; }
            set { _RightPinkyCode = value; }
        }

        public static string RightPrimaryCode
        {
            get { return _RightPrimaryCode; }
            set { _RightPrimaryCode = value; }
        }

        public static string RightThumbCode
        {
            get { return _RightThumbCode; }
            set { _RightThumbCode = value; }
        }

        public static bool PhotoOverride
        {
            get { return _PhotoOverride; }
            set { _PhotoOverride = value; }
        }

        public static bool SignatureOverride
        {
            get { return _SignatureOverride; }
            set { _SignatureOverride = value; }
        }

        public static bool IsICAO
        {
            get { return _IsICAO; }
            set { _IsICAO = value; }
        }

        public static bool IsCheckSingleFile
        {
            get { return _IsCheckSingleFile; }
            set { _IsCheckSingleFile = value; }
        }

        public static double PhotoScore
        {
            get { return _PhotoScore; }
            set { _PhotoScore = value; }
        } 

        public static void ResetData()
        {
            ResetMemberInfo();
            ResetPhoto();
            ResetSignature();
            ResetBiometrics();
        }

        public static void ResetMemberInfo()
        {
            _dtMemberInfo = null;
            DeleteFile(_MemberDataXMLFile);
        }

        public static void ResetPhoto()
        {
            DeleteFile(_PhotoRawFile);
            DeleteFile(_PhotoICAOFile);
            _PhotoRawFile = "";
            _PhotoICAOFile = "";            
        }

        public static void ResetSignature()
        {
            if(_SignatureFile!="")DeleteFile(_SignatureFile);
            if (_SignatureFile != "") DeleteFile(_SignatureFile.Replace(".tiff", "2.tiff"));
            if (_SignatureFile != "") DeleteFile(_SignatureFile.Replace(".tiff", "3.tiff"));
            if (_SignatureFile != "") DeleteFile(_SignatureFile.Replace(".tiff", "4.tiff"));
            _SignatureFile = "";           
        }

        public static void ResetBiometrics()
        {
            ResetBiometricLeftMiddle();
            ResetBiometricLeftRing();
            ResetBiometricLeftPinky();
            ResetBiometricLeftPrimary();
            ResetBiometricLeftThumb();
            ResetBiometricRightPrimary();
            ResetBiometricRightThumb();
            ResetBiometricRightMiddle();
            ResetBiometricRightRing();
            ResetBiometricRightPinky();
        }

        public static void ResetBiometricLeftMiddle()
        {
            DeleteFile(_BiometricLeftMiddleFileJPG);
            DeleteFile(_BiometricLeftMiddleFileANSI378);
            DeleteFile(_BiometricLeftMiddleFileWSQ);
            _BiometricLeftMiddleFileJPG = "";
            _BiometricLeftMiddleFileANSI378 = "";
            _BiometricLeftMiddleFileWSQ = "";
            _LeftMiddleCode = "";

        }

        public static void ResetBiometricLeftPinky()
        {
            DeleteFile(_BiometricLeftPinkyFileJPG);
            DeleteFile(_BiometricLeftPinkyFileANSI378);
            DeleteFile(_BiometricLeftPinkyFileWSQ);
            _BiometricLeftPinkyFileJPG = "";
            _BiometricLeftPinkyFileANSI378 = "";
            _BiometricLeftPinkyFileWSQ = "";
            _LeftPinkyCode = "";

        }

        public static void ResetBiometricLeftRing()
        {
            DeleteFile(_BiometricLeftRingFileJPG);
            DeleteFile(_BiometricLeftRingFileANSI378);
            DeleteFile(_BiometricLeftRingFileWSQ);
            _BiometricLeftRingFileJPG = "";
            _BiometricLeftRingFileANSI378 = "";
            _BiometricLeftRingFileWSQ = "";
            _LeftRingCode = "";

        }

        public static void ResetBiometricLeftPrimary()
        {
            DeleteFile(_BiometricLeftPrimaryFileJPG);
            DeleteFile(_BiometricLeftPrimaryFileANSI378);
            DeleteFile(_BiometricLeftPrimaryFileWSQ);
            _BiometricLeftPrimaryFileJPG = "";
            _BiometricLeftPrimaryFileANSI378 = "";
            _BiometricLeftPrimaryFileWSQ = "";
            _LeftPrimaryCode = "";
            
        }

        public static void ResetBiometricLeftThumb()
        {
            DeleteFile(_BiometricLeftThumbFileJPG);
            DeleteFile(_BiometricLeftThumbFileANSI378);
            DeleteFile(_BiometricLeftThumbFileWSQ);
            _BiometricLeftThumbFileJPG = "";
            _BiometricLeftThumbFileANSI378 = "";
            _BiometricLeftThumbFileWSQ = "";
            _LeftThumbCode = "";            
        }

        public static void ResetBiometricRightPrimary()
        {
            DeleteFile(_BiometricRightPrimaryFileJPG);
            DeleteFile(_BiometricRightPrimaryFileANSI378);
            DeleteFile(_BiometricRightPrimaryFileWSQ);
            _BiometricRightPrimaryFileJPG = "";
            _BiometricRightPrimaryFileANSI378 = "";
            _BiometricRightPrimaryFileWSQ = "";
            _RightPrimaryCode = "";            
        }

        public static void ResetBiometricRightMiddle()
        {
            DeleteFile(_BiometricRightMiddleFileJPG);
            DeleteFile(_BiometricRightMiddleFileANSI378);
            DeleteFile(_BiometricRightMiddleFileWSQ);
            _BiometricRightMiddleFileJPG = "";
            _BiometricRightMiddleFileANSI378 = "";
            _BiometricRightMiddleFileWSQ = "";
            _RightMiddleCode = "";
        }

        public static void ResetBiometricRightRing()
        {
            DeleteFile(_BiometricRightRingFileJPG);
            DeleteFile(_BiometricRightRingFileANSI378);
            DeleteFile(_BiometricRightRingFileWSQ);
            _BiometricRightRingFileJPG = "";
            _BiometricRightRingFileANSI378 = "";
            _BiometricRightRingFileWSQ = "";
            _RightRingCode = "";
        }

        public static void ResetBiometricRightPinky()
        {
            DeleteFile(_BiometricRightPinkyFileJPG);
            DeleteFile(_BiometricRightPinkyFileANSI378);
            DeleteFile(_BiometricRightPinkyFileWSQ);
            _BiometricRightPinkyFileJPG = "";
            _BiometricRightPinkyFileANSI378 = "";
            _BiometricRightPinkyFileWSQ = "";
            _RightPinkyCode = "";
        }

        public static void ResetBiometricRightThumb()
        {
            DeleteFile(_BiometricRightThumbFileJPG);
            DeleteFile(_BiometricRightThumbFileANSI378);
            DeleteFile(_BiometricRightThumbFileWSQ);
            _BiometricRightThumbFileJPG = "";
            _BiometricRightThumbFileANSI378 = "";
            _BiometricRightThumbFileWSQ = "";
            _RightThumbCode = "";            
        }

        private static void DeleteFile(string strFile)
        {
            if (File.Exists(strFile)) { File.Delete(strFile); }
        }

        public static void InitMemberInfo()
        {
            if (_dtMemberInfo == null)
            {
                _dtMemberInfo = new DataTable();
                _dtMemberInfo.Columns.Add("Field", Type.GetType("System.String"));
                _dtMemberInfo.Columns.Add("Value", Type.GetType("System.String"));
                _dtMemberInfo.Columns.Add("Label", Type.GetType("System.String"));
                _dtMemberInfo.Columns.Add("ControlName", Type.GetType("System.String"));
                _dtMemberInfo.Columns.Add("ControlType", Type.GetType("System.String"));
                _dtMemberInfo.Columns.Add("IsBuiltInControl", Type.GetType("System.Boolean"));
                _dtMemberInfo.Columns.Add("IsMandatory", Type.GetType("System.Boolean"));
                _dtMemberInfo.Columns.Add("IsSearchable", Type.GetType("System.Boolean"));
                _dtMemberInfo.Columns.Add("IsReceiptViewable", Type.GetType("System.Boolean"));
                _dtMemberInfo.Columns.Add("IsCapturedListViewable", Type.GetType("System.Boolean"));                 
            }
            else _dtMemberInfo.Clear();                        
        }

        public static string MemberInfoExtractData(string FieldName)
        {
            if (_dtMemberInfo.Select(string.Format("Field='{0}'", FieldName)).Length > 0)
            {
                return _dtMemberInfo.Select(string.Format("Field='{0}'", FieldName))[0][1].ToString();
            }
            else
            {
                return "Field not found";
            }
        }

        public static bool AddMemberInfoRow(string FieldName, string Value, string Label, string ControlName, string ControlType, Boolean IsBuiltInControl, Boolean IsMandatory, Boolean IsSearchable, Boolean IsReceiptViewable, Boolean IsCapturedListViewable)
        {
            if (_dtMemberInfo.Select(string.Format("Field='{0}'", FieldName)).Length > 0)
            {
                return false;
            }
            else
            {
                DataRow rw = _dtMemberInfo.NewRow();
                rw[0] = FieldName;
                rw[1] = Value;
                rw[2] = Label;
                rw[3] = ControlName;
                rw[4] = ControlType;                
                rw[5] = IsBuiltInControl;
                rw[6] = IsMandatory;
                rw[7] = IsSearchable;
                rw[8] = IsReceiptViewable;
                rw[9] = IsCapturedListViewable;
                _dtMemberInfo.Rows.Add(rw);                
                return true;                
            }
        }

        public static bool EditMemberInfoRow_All(string FieldName, string Value, string Label, string ControlName, string ControlType, Boolean IsBuiltInControl, Boolean IsMandatory, Boolean IsSearchable, Boolean IsReceiptViewable, Boolean IsCapturedListViewable)
        {
            if (_dtMemberInfo.Select(string.Format("Field='{0}'", FieldName)).Length == 0)
            {
                return false;
            }
            else
            {
                DataRow rw = _dtMemberInfo.Select(string.Format("Field='{0}'", FieldName))[0];
                rw[0] = FieldName;
                rw[1] = Value;
                rw[2] = Label;
                rw[3] = ControlName;
                rw[4] = ControlType;
                rw[5] = IsBuiltInControl;
                rw[6] = IsMandatory;
                rw[7] = IsSearchable;
                rw[8] = IsReceiptViewable;
                rw[9] = IsCapturedListViewable;                
                rw.AcceptChanges();               
                return true;
            }
        }

        public static bool EditMemberInfoRow_Value(string FieldName, string Value)
        {
            if (_dtMemberInfo.Select(string.Format("Field='{0}'", FieldName)).Length == 0)
            {
                return false;
            }
            else
            {
                DataRow rw = _dtMemberInfo.Select(string.Format("Field='{0}'", FieldName))[0];        
                rw[1] = Value;                
                rw.AcceptChanges();               
                return true;
            }
        }

        public static bool EditMemberInfoRow_IsMandatory_IsCapturedListViewable(string FieldName, bool IsMandatory, bool IsCapturedListViewable)
        {
            if (_dtMemberInfo.Select(string.Format("Field='{0}'", FieldName)).Length == 0)
            {
                return false;
            }
            else
            {
                DataRow rw = _dtMemberInfo.Select(string.Format("Field='{0}'", FieldName))[0];                
                rw[6] = IsMandatory;                
                rw[9] = IsCapturedListViewable;
                rw.AcceptChanges();                
                return true;
            }
        }

        public static void DeleteMemberInfoRow(string FieldName)
        {
            _dtMemberInfo.Select(string.Format("Field='{0}'", FieldName))[0].Delete();            
        }
    }
}
