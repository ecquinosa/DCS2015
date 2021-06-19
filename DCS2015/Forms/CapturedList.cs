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
    public partial class CapturedList : Form
    {
        public CapturedList()
        {
            InitializeComponent();
        }

        private void CapturedList_Load(object sender, EventArgs e)
        {     
            ExtractData_PhilhealthDCS();

            if (dt != null)
            {
                if (dt != null) { grid.DataSource = dt; }
                if (dtData != null) { grid2.DataSource = dtData; }

                label1.Text = string.Format("{0}: {1}", "TOTAL CAPTURED (LOCAL)", dt.DefaultView.Count.ToString());
                label2.Text = string.Format("{0}: {1}", "TOTAL CAPTURED (SUBMITTED TO SERVER)", dtData.DefaultView.Count.ToString());
            }
            else
            {
                label1.Text = string.Format("{0}: {1}", "TOTAL CAPTURED (LOCAL)", 0);
                label2.Text = string.Format("{0}: {1}", "TOTAL CAPTURED (SUBMITTED TO SERVER)", 0);
            }
        }

        public static ph_com_allcard_philhealth_secura.Allcard securaWS()
        {
            return new ph_com_allcard_philhealth_secura.Allcard();
        }

        private System.Data.DataTable dt=null;
        private System.Data.DataTable dtData=null;        

        private void ExtractData()
        {
            string[] files = System.IO.Directory.GetFiles(@"D:\EDEL\ACC\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\FINAL", "*.xml",System.IO.SearchOption.AllDirectories);
            foreach (string strFile in files)
            {
                ReadXML(strFile);
            }
        }

        private void ExtractData_PhilhealthDCS()
        {
            Class.Utilities.GetCapturedData(ref dt, true);

            if (dt != null)
            {
                string PhilhealthNos = string.Join(",", dt.AsEnumerable().Select(r => r.Field<string>("PhilhealthNo")).ToList());
                if (PhilhealthNos.Trim().LastIndexOf(",") == (PhilhealthNos.Trim().Length - 1)) PhilhealthNos = PhilhealthNos.Substring(0, PhilhealthNos.Trim().LastIndexOf(","));

                //ACCALLCARD.PROG_SECURA_DEFAULT.PHILHEALTH_NO IN ()
                StringBuilder sb = new StringBuilder();

                sb.Append(@"SELECT ACCALLCARD.PROG_SECURA_DEFAULT.PHILHEALTH_NO, ACCALLCARD.PROG_SECURA_DEFAULT.FIRST_NAME, ");
                sb.Append(@"ACCALLCARD.PROG_SECURA_DEFAULT.MIDDLE_NAME,ACCALLCARD.PROG_SECURA_DEFAULT.LAST_NAME, ACCALLCARD.PROG_SECURA_DEFAULT.SUFFIX, ");
                sb.Append(@"ACCALLCARD.PROG_SECURA_DEFAULT.CREATED_BY FROM ACCALLCARD.PROG_SECURA_DEFAULT ");
                sb.Append(@" WHERE ACCALLCARD.PROG_SECURA_DEFAULT.PHILHEALTH_NO IN (" + PhilhealthNos + ")");

                string ErrorMsg = "";
                securaWS().SP100("(*812aAiP*@", sb.ToString(), ref dtData, ref ErrorMsg);
            }
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
            //dt.Columns.Add("PhilhealthNo", Type.GetType("System.String"));
            //dt.Columns.Add("FirstName", Type.GetType("System.String"));
            //dt.Columns.Add("MiddleName", Type.GetType("System.String"));
            //dt.Columns.Add("LastName", Type.GetType("System.String"));
            //dt.Columns.Add("Suffix", Type.GetType("System.String"));
            //dt.Columns.Add("Company", Type.GetType("System.String"));
            //dt.Columns.Add("Branch", Type.GetType("System.String"));            

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

        private void ReadXML(string strFile)
        {
            System.Data.DataRow rw = dt.NewRow();


            string strElementName="";

            System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(strFile);
            while ((reader.Read()))
            {
                switch (reader.NodeType)
                {
                    case System.Xml.XmlNodeType.Element:
                        
                        //Display beginning of element.
                        strElementName = reader.Name;
                        Console.Write("<" + reader.Name);
                        //If attributes exist
                        if (reader.HasAttributes)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                //Display attribute name and value.
                                Console.Write(" {0}='{1}'", reader.Name, reader.Value);
                            }
                        }
                        //Console.WriteLine(">");
                        break;
                    case System.Xml.XmlNodeType.Text:
                        //Display the text in each element.
                        //Console.WriteLine(reader.Value);
                        switch (strElementName)
                        {                            
                            case "MemberNo":
                                rw[0] = reader.Value;
                                break;
                            case "BOSPayjur":
                                rw[1] = reader.Value;
                                break;
                            case "FirstName":
                                rw[2] = reader.Value;
                                break;
                            case "MiddleName":
                                rw[3] = reader.Value;
                                break;
                            case "LastName":
                                rw[4] = reader.Value;
                                break;
                            case "SessionReference":
                                rw[5] = reader.Value;
                                dt.Rows.Add(rw);
                                break;
                            //strData.Split("|")(17)
                        }
                        break;
                    case System.Xml.XmlNodeType.EndElement:
                        //Display end of element.
                        //Console.Write("</" + reader.Name);
                        //Console.WriteLine(">");                        
                        break;
                }
            }
        }

    }
}
