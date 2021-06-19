using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DCS2015
{
    public partial class PhotoCropper : Form
    {

        private string tempFile = "";
        private string icaoPhoto = "";

        public PhotoCropper()
        {
            InitializeComponent();
        }

        private void PhotoCropper_Load(object sender, EventArgs e)
        {
            txtPassedPhoto.Text = txtRawPhoto.Text;
        }


        private void StartCroppingProcess()
        {
            string source = txtRawPhoto.Text;

            foreach (string strFile in System.IO.Directory.GetFiles(source))
            {
                if (txtPassedPhoto.Text == "")
                    CropPhoto(strFile);
                else
                {
                    string passedFile = string.Format("{0}\\{1}", txtPassedPhoto.Text, Path.GetFileName(strFile));
                    if (!File.Exists(passedFile)) CropPhoto(strFile);
                }
            }            

            MessageBox.Show("Done!");
        }

        private void CropPhoto(string _file)
        {
            pbRaw.Image = null;
            System.Threading.Thread.Sleep(100);
            string _ntfiAttributes = "";

            //txtTempWidth.Text = txtWidth.Text;        
            //txtTempHeight.Text = txtHeight.Text;

            string TEMP_FOLDER = "Temp";
            string DESTINATION_FOLDER = string.Format("PHOTO_{0}x{1}",txtTempWidth.Text,txtTempHeight.Text);
            string OUTPUT_FILE = string.Format("{0}\\{1}", DESTINATION_FOLDER, System.IO.Path.GetFileName(_file));

            try
            {
                if (Directory.Exists(TEMP_FOLDER)) Directory.Delete(TEMP_FOLDER, true);
                Directory.CreateDirectory(TEMP_FOLDER);
            }
            catch { }
            
            if (!Directory.Exists(DESTINATION_FOLDER)) Directory.CreateDirectory(DESTINATION_FOLDER);
            
            tempFile = string.Format("{0}\\TempFile{1}.jpg",TEMP_FOLDER,DateTime.Now.ToString("hhmmss"));            
            System.IO.File.Copy(_file, tempFile, true);

            Class.PhotoAnalysis photoAnalysis = new Class.PhotoAnalysis();
            photoAnalysis.Convert_TO_ICAO_Test(tempFile, new Size(Convert.ToInt32(txtWidth.Text), Convert.ToInt32(txtHeight.Text)), ref icaoPhoto,  ref _ntfiAttributes);
            photoAnalysis = null;

            FinalCrop(OUTPUT_FILE);
        }

        private void FinalCrop(string _file)
        {
            Bitmap bmpTemp = new Bitmap(tempFile);
            Size s = new Size(bmpTemp.Width, bmpTemp.Height);
            bmpTemp.Dispose();
            bmpTemp = null;

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(icaoPhoto);
            Rectangle r = new Rectangle(new Point(Convert.ToInt32(txtX.Text), Convert.ToInt32(txtY.Text)), new Size(Convert.ToInt32(txtTempWidth.Text), Convert.ToInt32(txtTempHeight.Text)));
            Image result = cropImage(bmp, r);
            result.Save(_file, System.Drawing.Imaging.ImageFormat.Jpeg);
            result.Dispose();
            result = null;
        }

        private Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private void btnTestOutput_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            string _file = System.IO.Directory.GetFiles(txtRawPhoto.Text)[0];
            CropPhoto(_file);

            Image imgRaw = Image.FromStream(new MemoryStream(File.ReadAllBytes(_file)));
            Image imgICAO = new Bitmap(Image.FromStream(new MemoryStream(File.ReadAllBytes(icaoPhoto))));

            pbRaw.Image = imgRaw;
            pnlCropped.BackgroundImage = imgICAO;

            lblRawDimension.Text = string.Format("WIDTH: {0}, HEIGHT: {1}", imgRaw.Width.ToString(), imgRaw.Height.ToString());
            lblCroppedDimension.Text = string.Format("WIDTH: {0}, HEIGHT: {1}", imgICAO.Width.ToString(), imgICAO.Height.ToString());

            Repaint_pbTemp();

            Cursor = Cursors.Default;
            this.Enabled = true;

            MessageBox.Show("Done!");
        }  

        private Point MouseDownLocation;

        private void pbTemp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;               
            }
        }

        private void pbTemp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int intLeft = e.X + pbTemp.Left - MouseDownLocation.X;
                int intTop = e.Y + pbTemp.Top - MouseDownLocation.Y;

                if (intLeft < 0) intLeft = 0;
                if (intTop < 0) intTop = 0;

                pbTemp.Left = intLeft;
                pbTemp.Top = intTop;
            }
        }

        private void pbTemp_MouseUp(object sender, MouseEventArgs e)
        {
            PreviewFinalCrop();
        }

        private void PreviewFinalCrop()
        {
            try
            {                
                Rectangle r = new Rectangle(new Point(Convert.ToInt32(txtX.Text), Convert.ToInt32(txtY.Text)), new Size(Convert.ToInt32(txtTempWidth.Text), Convert.ToInt32(txtTempHeight.Text)));
                Image result = cropImage(pnlCropped.BackgroundImage, r);
                pbFinalCrop.Image = result;
            }
            catch { }
        }

        private void pbTemp_LocationChanged(object sender, EventArgs e)
        {
            txtX.Text = pbTemp.Location.X.ToString();
            txtY.Text = pbTemp.Location.Y.ToString();           
        }

        private void Repaint_pbTemp()
        {
            pbTemp.Location = new Point(Convert.ToInt32(txtX.Text), Convert.ToInt32(txtY.Text));
            pbTemp.Size = new Size(Convert.ToInt32(txtTempWidth.Text), Convert.ToInt32(txtTempHeight.Text));
            PreviewFinalCrop();
        }

        private void pbTempTxtBox_TextChanged(object sender, EventArgs e)
        {
            Repaint_pbTemp();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Repaint_pbTemp();
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            txtTempWidth.Text = txtWidth.Text;
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            txtTempHeight.Text = txtHeight.Text;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            rtbFilterPhotoGood.Clear();
            rtbFilterPhotoBad.Clear();

            int intGood = 0;
            int intFailed = 0;

            string PHOTO_PASSED = string.Format("{0}\\PHOTO_PASSED", txtSourcePhotos.Text);
            string PHOTO_FAILED = string.Format("{0}\\PHOTO_FAILED", txtSourcePhotos.Text);            

            if (System.IO.Directory.Exists(PHOTO_PASSED)) System.IO.Directory.Delete(PHOTO_PASSED, true);
            if (System.IO.Directory.Exists(PHOTO_FAILED)) System.IO.Directory.Delete(PHOTO_FAILED, true);

            System.IO.Directory.CreateDirectory(PHOTO_PASSED);
            System.IO.Directory.CreateDirectory(PHOTO_FAILED);
            
            foreach (string strFile in System.IO.Directory.GetFiles(txtSourcePhotos.Text))
            {
                Bitmap bmp = new System.Drawing.Bitmap(strFile);
                if (CheckPhotoIfPassed(bmp))
                {
                    intGood += 1;
                    System.IO.File.Copy(strFile, string.Format("{0}\\{1}",PHOTO_PASSED,System.IO.Path.GetFileName(strFile), true));
                    rtbFilterPhotoGood.AppendText(Path.GetFileName(strFile) + Environment.NewLine);
                }
                else
                {
                    intFailed += 1;
                    System.IO.File.Copy(strFile, string.Format("{0}\\{1}", PHOTO_FAILED, System.IO.Path.GetFileName(strFile), true));                    
                    rtbFilterPhotoBad.AppendText(Path.GetFileName(strFile) + Environment.NewLine);
                }

                bmp.Dispose();
                bmp = null;

                lblFilterPhotoGood.Text = "GOOD: " + intGood.ToString("N0");
                lblFilterPhotoBad.Text = "FAILED: " + intFailed.ToString("N0");
                Application.DoEvents();
            }

            Cursor = Cursors.Default;
            this.Enabled = true;

            MessageBox.Show("Done!");
        }

        private bool CheckPhotoIfPassed(Bitmap image1)
        {
            int x, y;

            short intCntr = 0;

            for (y = 0; y <= image1.Height - 1; y++)
            {
                if (y != 10)
                {
                    //txtYLimit.Text = 0 //acceptable result
                    if (y <= Convert.ToInt16(txtStartingY.Text))
                    {
                        for (x = 0; x <= image1.Width - 1; x++)
                        {
                            if (Convert.ToInt32(image1.GetPixel(x, y).R.ToString()) < 150) intCntr += 1;                            

                            //textBox6.Text = 30 //acceptable result
                            if (intCntr > Convert.ToInt32(txtFailCntr.Text)) return false;
                        }
                    }

                }
            }

            return true;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            StartCroppingProcess();

            Cursor = Cursors.Default;
            this.Enabled = true;

            MessageBox.Show("Done!");
        }
    }
}
