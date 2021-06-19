
using System;
using System.Collections.Generic;
using System.Text;
using WinSCP;
using System.IO;

namespace DCS_FileTransfer
{
    class Program
    {

        private delegate void dlgtProcess();
        private static System.Threading.Thread _thread;
        private static short MINUTE_INTERVAL = 3;

        private static string configFile = "config";
        private static bool IsProcessReady = true;

        private static string FTP_HOST = "sftp.allcardtech.com.ph";

        private static string FTP_Username = "philhealth";
        private static string FTP_Password = "Minerals*";

        //private static string FTP_Username = "bayambang";
        //private static string FTP_Password = "Argon2016*";
        
        private static int FTP_PortNumber = 2022;
        
        private static string FTP_SshHostKeyFingerprint = "ssh-rsa 2048 7b:ec:8a:a6:a4:31:e7:a9:8b:3d:d8:0c:1c:79:03:e5";        

        private static string LOCALPATH = "";
        private static string REMOTEPATH = "";

        private static string SystemLog = "System.txt";
        private static string ErrorLog = "Error.txt";

        static void Main()
        {            
            if (IsProgramRunning("DCS_FileTransfer.exe") > 1)
                return;
            else
            {
                SaveToLog(SystemLog, "Main(): Application start");
                if (Init())
                    StartThread();
                else
                    SaveToLog(SystemLog, "Main(): Application closed");
            }            
        }

        private static bool Init()
        {
            try
            {
                if (!File.Exists(configFile))
                {
                    SaveToLog(ErrorLog, "Init(): Config file is missing");
                    return false;
                }
                else
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(configFile))
                        {
                            while (!sr.EndOfStream)
                            {
                                string strLine = sr.ReadLine();

                                if (strLine != "")
                                {
                                    if (strLine.Contains("LOCALPATH"))
                                        LOCALPATH = strLine.Split('=')[1];
                                    else if (strLine.Contains("REMOTEPATH"))
                                        REMOTEPATH = strLine.Split('=')[1];
                                    else if (strLine.Contains("MINUTE_INTERVAL"))
                                        MINUTE_INTERVAL = Convert.ToInt16(strLine.Split('=')[1]);
                                }
                            }

                            sr.Dispose();
                            sr.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        SaveToLog(ErrorLog, "Init(): Error reading config file. Runtime catched error " + ex.Message);
                        return false;
                    }
                }

                if (!Directory.Exists(LOCALPATH))
                {
                    SaveToLog(ErrorLog, "Init(): Directory does not exist " + LOCALPATH);
                    return false;
                }

                //if (!Directory.Exists(REMOTEPATH))
                //{
                //    SaveToLog(ErrorLog, "Init(): Directory does not exist " + REMOTEPATH);
                //    return false;
                //}

                return true;
            }
            catch (Exception ex)
            {
                SaveToLog(ErrorLog, "Init(): Runtime catched error " + ex.Message);
                return false;
            }
        }

        private static void StartThread()
        {
            System.Threading.Thread objNewThread = new System.Threading.Thread(ProgramThread);
            objNewThread.Start();
            _thread = objNewThread;
        }

        private static void ProgramThread()
        {
            try
            {
                while (true)
                {
                    if (IsProcessReady)
                    {
                        IsProcessReady = false;
                        dlgtProcess _delegate = new dlgtProcess(RunProcess);
                        _delegate.Invoke();
                        _delegate = null;
                        System.Threading.Thread.Sleep((MINUTE_INTERVAL * 60000));                        
                    }

                }

            }
            catch (Exception ex)
            {                
                SaveToLog(ErrorLog, "ProgramThread(): Runtime catched error " + ex.Message);               
            }

        }

        private static void RunProcess()
        {
            string strProcessTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

            TransferFileToFTP();

            Console.WriteLine(("Last process: " + strProcessTime));
            Console.WriteLine("Waiting for next process...");
            IsProcessReady = true;
        }

        private static SessionOptions sessionOptions()
        {
            return new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = FTP_HOST,
                UserName = FTP_Username,
                Password = FTP_Password,
                PortNumber = FTP_PortNumber,
                SshHostKeyFingerprint = FTP_SshHostKeyFingerprint
            };
        }

        private static void TransferFileToFTP()
        {
            try
            {
                int intFileCount = Directory.GetFiles(LOCALPATH).Length;

                if (intFileCount > 0)
                {
                    Console.WriteLine("Transfer of {0} file(s) started...", intFileCount.ToString());

                    //// Setup session options
                    //SessionOptions sessionOptions = new SessionOptions
                    //{
                    //    Protocol = Protocol.Sftp,
                    //    HostName = FTP_HOST,
                    //    UserName = FTP_Username,
                    //    Password = FTP_Password,
                    //    PortNumber = FTP_PortNumber,
                    //    SshHostKeyFingerprint = FTP_SshHostKeyFingerprint
                    //};

                    using (Session session = new Session())
                    {
                        // Connect
                        session.Open(sessionOptions());

                        // Upload files
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;
                        
                        //transferOptions.FilePermissions = null; // This is default
                        //added by edel 09/06/2017 due to error reported by philhealth ops
                        transferOptions.PreserveTimestamp = false;

                        //added for bayamabang 09/23/2016
                        if (FTP_Username == "bayambang")
                        {
                            REMOTEPATH = string.Format("{0}{1}/", REMOTEPATH, DateTime.Now.ToString("MM-dd-yyyy"));
                            // Create remote subdirectory, if it does not exist yet
                            if (!session.FileExists(REMOTEPATH))
                                session.CreateDirectory(REMOTEPATH);
                            //
                        }

                        TransferOperationResult transferResult;
                        transferResult = session.PutFiles(string.Format(@"{0}\*", LOCALPATH), REMOTEPATH, false, transferOptions);

                        // Throw on any error
                        transferResult.Check();

                        // Print results
                        foreach (TransferEventArgs transfer in transferResult.Transfers)
                        {
                            string strFilename = Path.GetFileName(transfer.FileName);

                            //Console.WriteLine("Upload of {0} succeeded", transfer.FileName);                         
                            Console.WriteLine("Upload of {0} succeeded", strFilename);
                            SaveToLog(SystemLog, string.Format("Upload of {0} succeeded", strFilename));

                            //delete file if successfully transferred
                            File.Delete(string.Format(@"{0}\{1}", LOCALPATH, strFilename));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("TransferFileToFTP(): Runtime error {0}", ex.Message));
                SaveToLog(ErrorLog, string.Format("TransferFileToFTP(): Runtime error {0}", ex.Message));
            }
        }

        private static void SaveToLog(string strFile, string strData)
        {
            if(!Directory.Exists("Logs")){ Directory.CreateDirectory("Logs"); }

            using (StreamWriter sw = new StreamWriter(@"Logs\" + strFile,true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt").PadRight(24, ' ') + strData);
                sw.Dispose();
                sw.Close();
            }
        }

        private static short IsProgramRunning(string Program)
        {
            System.Diagnostics.Process[] p;        
            p = System.Diagnostics.Process.GetProcessesByName(Program.Replace(".exe", "").Replace(".EXE", ""));

            return (short)p.Length;
        }

        //public bool IsFileExist()
        //{
        //    try
        //    {using (Session session = new Session())
        //        {
        //            // Connect
        //            session.Open(sessionOptions());

        //            string stamp = DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
        //            string fileName = "export_" + stamp + ".txt";
        //            string remotePath = "/home/user/sysbatch/" + fileName;
        //            string localPath = "d:\\backup\\" + fileName;

        //            // Manual "remote to local" synchronization.

        //            // You can achieve the same using:
        //            // session.SynchronizeDirectories(
        //            //     SynchronizationMode.Local, localPath, remotePath, false, false, SynchronizationCriteria.Time, 
        //            //     new TransferOptions { FileMask = fileName }).Check();
        //            if (session.FileExists(remotePath))
        //            {
        //                bool download;
        //                if (!File.Exists(localPath))
        //                {
        //                    Console.WriteLine("File {0} exists, local backup {1} does not", remotePath, localPath);
        //                    download = true;
        //                }
        //                else
        //                {
        //                    DateTime remoteWriteTime = session.GetFileInfo(remotePath).LastWriteTime;
        //                    DateTime localWriteTime = File.GetLastWriteTime(localPath);

        //                    if (remoteWriteTime > localWriteTime)
        //                    {
        //                        Console.WriteLine(
        //                            "File {0} as well as local backup {1} exist, " +
        //                            "but remote file is newer ({2}) than local backup ({3})",
        //                            remotePath, localPath, remoteWriteTime, localWriteTime);
        //                        download = true;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine(
        //                            "File {0} as well as local backup {1} exist, " +
        //                            "but remote file is not newer ({2}) than local backup ({3})",
        //                            remotePath, localPath, remoteWriteTime, localWriteTime);
        //                        download = false;
        //                    }
        //                }

        //                if (download)
        //                {
        //                    // Download the file and throw on any error
        //                    session.GetFiles(remotePath, localPath).Check();

        //                    Console.WriteLine("Download to backup done.");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("File {0} does not exist yet", remotePath);
        //            }
        //        }

        //        return 0;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error: {0}", e);
        //        return 1;
        //    }
        //}
    }
}
