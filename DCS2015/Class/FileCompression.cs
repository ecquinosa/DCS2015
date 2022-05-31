
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace DCS2015.Class
{
    class FileCompression
    {
        private string _ErrorMessage;

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
        }        

        public bool Compress(string directoryPath, string ZipPassword)
        {
            try
            {
                // Depending on the directory this could be very large and would require more attention
                // in a commercial package.
                string[] filenames = Directory.GetFiles(directoryPath);

                // 'using' statements guarantee the stream is closed properly which is a big source
                // of problems otherwise.  Its exception safe as well which is great.
                using (ZipOutputStream s = new ZipOutputStream(File.Create(directoryPath + ".zip")))
                {

                    s.SetLevel(9); // 0 - store only to 9 - means best compression
                    if (ZipPassword != "") s.Password = ZipPassword;

                    byte[] buffer = new byte[4096];

                    foreach (string file in filenames)
                    {

                        // Using GetFileName makes the result compatible with XP
                        // as the resulting path is not absolute.
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                        // Setup the entry data as required.

                        // Crc and size are handled by the library for seakable streams
                        // so no need to do them here.

                        // Could also use the last write time or similar for the file.
                        entry.DateTime = System.DateTime.Now;
                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {

                            // Using a fixed size buffer here makes no noticeable difference for output
                            // but keeps a lid on memory usage.
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }

                    // Finish/Close arent needed strictly as the using statement does this automatically

                    // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                    // the created file would be invalid.
                    s.Finish();

                    // Close is important to wrap things up and unlock the file.
                    s.Close();

                    return true;
                }
            }
            catch (System.Exception ex)
            {
                //Utilities.SaveToErrorLog(Utilities.TimeStamp() + string.Format("Failed to compress {0}", Utilities.SessionReference()));
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + string.Format("Failed to compress {0}", Utilities.CaptureSessionReference));
                return false;
            }
        }
        
    }
}
