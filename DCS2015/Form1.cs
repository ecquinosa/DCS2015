using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS2015
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string strFile = "";
        string strFile2 = "";

        private void button1_Click(object sender, EventArgs e)
        {
            string source = @"D:\MACEMCO CAPTURES\DATA - Copy\PREP\PHOTO_RAW";

            foreach (string strFile in System.IO.Directory.GetFiles(source))
            {
                CropPhoto(strFile);
                System.Threading.Thread.Sleep(100);
            }
            
            //CropPhoto("2");
            //CropPhoto("3");
            //CropPhoto("4");
            //CropPhoto("5");

            MessageBox.Show("done!");
        }

        private void CropPhoto(string _file)
        {
            this.BackgroundImage = null;
            System.Threading.Thread.Sleep(100);
            string _ntfiAttributes = "";

            //strFile = @"C:\Users\ecquiñosa\Downloads\Compressed\iface_3.2.2_desktop_x64_win64\x86-64_win64\samples\sample_detect\assets\" + _file  + ".jpg";
            //strFile2 = strFile.Replace(".jpg", "2.jpg");            
            strFile = _file;
            string tempFile = @"D:\MACEMCO CAPTURES\DATA - Copy\PREP\Temp2\TempFile" + DateTime.Now.ToString("hhmmss") + ".jpg";
            strFile2 = @"D:\MACEMCO CAPTURES\DATA - Copy\PREP\PHOTO_300x345\" + System.IO.Path.GetFileName(strFile);

            System.IO.File.Copy(strFile, tempFile,true);

            Class.PhotoAnalysis photoAnalysis = new Class.PhotoAnalysis();
            string icaoPhoto = "";
            //photoAnalysis.Convert_TO_ICAO_Test(tempFile, ref icaoPhoto, ref _ntfiAttributes);
            photoAnalysis = null;
            //this.BackgroundImage = Image.FromFile(strFile2);

            Size s = new Size(300, 400);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(tempFile.Replace(".jpg", "2.jpg"));
            Rectangle r = new Rectangle(new Point(0, 50), new Size(300, 345));
            //pictureBox1.Image = cropAtRect(bmp, r);
            Image result = cropImage(bmp, r);
            //result.Save(strFile.Replace(".jpg", "_300x345.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
            result.Save(strFile2, System.Drawing.Imaging.ImageFormat.Jpeg);
            //pictureBox1.Image = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pb1.Location = new Point(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            pb1.Size = new Size(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
        }

        private Bitmap cropAtRect(Bitmap b, Rectangle r)
        {
            Bitmap nb = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(b, -r.X, -r.Y);
            nb.Save(strFile.Replace(".jpg", "3.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
            return nb;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //button1.PerformClick();           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Size s = new Size(300, 400);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(strFile2);
            Rectangle r = new Rectangle(new Point(0, 50), new Size(300, 345));
            //pictureBox1.Image = cropAtRect(bmp, r);
            Image result = cropImage(bmp, r);
            result.Save(strFile.Replace(".jpg", "_300x345.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox1.Image = result;
        }

        private Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
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
                    if (y <= Convert.ToInt16(txtYLimit.Text))
                    {
                        for (x = 0; x <= image1.Width - 1; x++)
                        {
                            if (Convert.ToInt32(image1.GetPixel(x, y).R.ToString()) < 150)
                            {
                                intCntr += 1;
                            }

                            //textBox6.Text = 30 //acceptable result
                            if (intCntr> Convert.ToInt32(textBox6.Text)) return false;

                           
                            //rtb.AppendText(string.Format("X: {0} | Y: {1} | {2} | {3}", x, y, image1.GetPixel(x, y).ToString(), image1.GetPixel(x, y).R.ToString()) + Environment.NewLine);
                            //rtb.ScrollToCaret();
                        }
                    }

                } 
            }

            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string PHOTO_PASSED = @"D:\MACEMCO CAPTURES\DATA - Copy\PREP\PHOTO_PASSED";
            string PHOTO_FAILED = @"D:\MACEMCO CAPTURES\DATA - Copy\PREP\PHOTO_FAILED";

            if(System.IO.Directory.Exists(PHOTO_PASSED))System.IO.Directory.Delete(PHOTO_PASSED, true);
            if (System.IO.Directory.Exists(PHOTO_FAILED)) System.IO.Directory.Delete(PHOTO_FAILED, true);

            System.IO.Directory.CreateDirectory(PHOTO_PASSED);
            System.IO.Directory.CreateDirectory(PHOTO_FAILED);

            rtb.Clear();
            foreach (string strFile in System.IO.Directory.GetFiles(textBox5.Text))
            {
                Bitmap bmp = new System.Drawing.Bitmap(strFile);
                if (CheckPhotoIfPassed(bmp))                
                    System.IO.File.Copy(strFile, @"D:\MACEMCO CAPTURES\DATA - Copy\PREP\PHOTO_PASSED\" + System.IO.Path.GetFileName(strFile), true);
                else
                    System.IO.File.Copy(strFile, @"D:\MACEMCO CAPTURES\DATA - Copy\PREP\PHOTO_FAILED\" + System.IO.Path.GetFileName(strFile));

                bmp.Dispose();
                bmp = null;
            }

            MessageBox.Show("Done!");
        }
    }
}
