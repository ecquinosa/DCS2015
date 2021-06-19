
using System;
using System.Windows.Forms;

namespace DCS2015.Forms
{   

    public partial class Sig100_DeviceChecker : Form
    {
        public Sig100_DeviceChecker()
        {
            InitializeComponent();            
        }
                
        private static int intDeviceCount = 0;

        private void Sig100_DeviceChecker_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }       

        public short DeviceGetCount()
        {         
            return (short)intDeviceCount;
        }
    }
}
