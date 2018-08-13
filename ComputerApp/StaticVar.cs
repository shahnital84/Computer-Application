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

        public static DataTable GetProductDetail() // public funstion to access data from database 
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
    }
}
