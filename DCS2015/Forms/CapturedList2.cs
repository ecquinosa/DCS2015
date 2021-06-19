using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS2015.Forms
{
    public partial class CapturedList2 : Form
    {
        public CapturedList2()
        {
            InitializeComponent();
        }

        private void CapturedList2_Load(object sender, EventArgs e)
        {
            ExtractData_Bayambang();

            if (dt != null)
            {

                grid.DataSource = dt;
                label1.Text = string.Format("{0}: {1}", "TOTAL CAPTURED (LOCAL)", (dt.DefaultView.Count-1).ToString());                
            }
            else label1.Text = string.Format("{0}: {1}", "TOTAL CAPTURED (LOCAL)", 0);
        }       

        private System.Data.DataTable dt=null;             

        
        private void ExtractData_Bayambang()
        {
            Class.Utilities.GetCapturedData(ref dt, true);            
        }

        private void CreateTable()
        {
            dt = new System.Data.DataTable();            
            dt.Columns.Add("MemberNos", Type.GetType("System.String"));
            dt.Columns.Add("BOSPayjur", Type.GetType("System.String"));
            dt.Columns.Add("First", Type.GetType("System.String"));
            dt.Columns.Add("Middle", Type.GetType("System.String"));
            dt.Columns.Add("Last", Type.GetType("System.String"));
            dt.Columns.Add("SessionReference", Type.GetType("System.String"));
            dt.AcceptChanges();
        }

        private void CreateTable_PhilhealthDCS()
        {
            //philhealth dcs
            //0{philhealth#}|1{fname}|2{mname}|3{lname}|4{suffix}|5{company}|6{branch}|7{sessionreference}|8{operatorid}|9{timestamp}
            dt = new System.Data.DataTable();                

            StringBuilder sb = new StringBuilder();
            DataRow[] rws = DCS_MemberInfo.Data.MemberInfo.Select("IsCapturedListViewable=true");

            foreach (DataRow rw in rws)
            {
                dt.Columns.Add(rw[0].ToString().Trim(), Type.GetType("System.String"));                
            }

            dt.Columns.Add("Operator", Type.GetType("System.String"));
            dt.Columns.Add("SessionReference", Type.GetType("System.String"));
            dt.Columns.Add("Timestamp", Type.GetType("System.String"));
            dt.AcceptChanges();
        }    

    }
}
