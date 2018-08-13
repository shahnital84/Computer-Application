using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ComputerApp
{
    public static class StaticVar
    {
        public static string pid, condition, cost, platform, manufacturer, os, model, memory, cbrand, ctype, lsize, cno, cspeed, hdd, gputype, webcam, filedata;

        public static DataTable GetProductDetail()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con1 = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con1);
            if (con1.State == ConnectionState.Closed)
            {
                con1.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con1.Close();
            return dt;
        }

        //public static void OpenMenu()
        //{
        //    OpenFileDialog openDig = new OpenFileDialog();
        //    openDig.Filter = "Text Files|*.txt";
        //    if (openDig.ShowDialog() == DialogResult.OK)
        //    {
        //        filedata = System.IO.File.ReadAllText(openDig.FileName);
        //        Console.WriteLine(filedata);
        //        string[] data = filedata.Split('|');
        //        foreach (string i in data)
        //        {
        //            string getdata = i;
        //        }
        //        pid = data[0];
        //        condition = data[1];
        //        cost = data[2];
        //        platform = data[3];
        //        manufacturer = data[4];
        //        os = data[5];
        //        model = data[6];
        //        memory = data[7];
        //        cbrand = data[8];
        //        ctype = data[9];
        //        lsize = data[10];
        //        cno = data[11];
        //        cspeed = data[12];
        //        hdd = data[13];
        //        gputype = data[14];
        //        webcam = data[15];
        //    }


        //}

        //public static void closeAll()
        //{
        //    FormCollection fc = System.Windows.Forms.Application.OpenForms;
        //    if (fc.Count > 1)
        //    {
        //        for (int i = (fc.Count); i > 1; i--)
        //        {
        //            Form selectedForm = System.Windows.Forms.Application.OpenForms[i - 1];
        //            selectedForm.Close();
        //        }
        //    }
        //}

    }
}
