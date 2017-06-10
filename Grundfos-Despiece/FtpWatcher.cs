using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Grundfos_Despiece
{
    public static class FtpWatcherInstance
    {
        public static FtpWatcher fwc;
    }

    public class FtpWatcher
    {
        private FileSystemWatcher wtch;

        public FtpWatcher()
        {
            wtch = new FileSystemWatcher(HttpContext.Current.Server.MapPath("~/"), "*.xml");
            wtch.Changed += new FileSystemEventHandler(Changed);
            wtch.EnableRaisingEvents = true;
            wtch.IncludeSubdirectories = false;
            wtch.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;
        }

        protected static void Changed(object source, FileSystemEventArgs e)
        {
            ActualizarDatos();
        }

        protected static void ActualizarDatos()
        {
            DataSet ds = new DataSet();

            ds.ReadXml(HttpContext.Current.Server.MapPath("~/transac.xml"));

            string cmddelete2 = "delete from ordcompras";
            string cmddelete3 = "delete from stock";

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

            SqlCommand com2 = new SqlCommand(cmddelete2, myConnection);
            SqlCommand com3 = new SqlCommand(cmddelete3, myConnection);
            SqlDataReader dr;
            myConnection.Open();
            dr = com2.ExecuteReader();
            dr.Read();
            dr.Close();
            dr = com3.ExecuteReader();
            dr.Read();
            dr.Close();
            myConnection.Close();

            foreach (DataRow datar in ds.Tables["PO"].Rows)
            {
                string cmdinsert = "insert into ordcompras values ('" + datar.ItemArray[0] + "'," + datar.ItemArray[1] + ",'" + Convert.ToDateTime(datar.ItemArray[2]).ToString("yyyyMMdd") + "')";
                SqlCommand com4 = new SqlCommand(cmdinsert, myConnection);
                SqlDataReader dr2;
                myConnection.Open();
                dr2 = com4.ExecuteReader();
                dr2.Read();
                dr2.Close();
                myConnection.Close();   
            }
            foreach (DataRow datar in ds.Tables["Stock"].Rows)
            {
                string cmdinsert = "insert into stock values ('" + datar.ItemArray[0] + "'," + datar.ItemArray[1] + ",'" + datar.ItemArray[2] + "','" + Convert.ToDateTime(datar.ItemArray[3]).ToString("yyyyMMdd") + "')";
                SqlCommand com4 = new SqlCommand(cmdinsert, myConnection);
                SqlDataReader dr2;
                myConnection.Open();
                dr2 = com4.ExecuteReader();
                dr2.Read();
                dr2.Close();
                myConnection.Close();
            }
        }

        protected static void ActualizarDespiece()
        {
            DataSet ds = new DataSet();

            ds.ReadXml(HttpContext.Current.Server.MapPath("~/despiece.xml"));

            string cmddelete = "delete from despiece";

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

            SqlCommand com = new SqlCommand(cmddelete, myConnection);
            SqlDataReader dr;
            myConnection.Open();
            dr = com.ExecuteReader();
            dr.Read();
            dr.Close();
            myConnection.Close();

            foreach (DataRow datar in ds.Tables["Despiece"].Rows)
            {
                string cmdinsert = "insert into despiece values ('" + datar.ItemArray[0] + "','" + datar.ItemArray[1] + "'," + datar.ItemArray[2] + ")";
                SqlCommand com2 = new SqlCommand(cmdinsert, myConnection);
                SqlDataReader dr2;
                myConnection.Open();
                dr2 = com2.ExecuteReader();
                dr2.Read();
                dr2.Close();
                myConnection.Close();
            }
        }

    }
}
