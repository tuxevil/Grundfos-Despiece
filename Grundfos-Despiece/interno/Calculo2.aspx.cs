using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Grundfos_Despiece
{
    public partial class Calculo2 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=dbserver;User ID=grundfos;Password=grundfos;database=Grundfos_Scala1107";

            int dias = -5;
            DateTime fecha = DateTime.Today.AddDays(dias);
            

            string sqldisponible = "select SC06002 as Producto, floor(min(A.Cant/SC06004)) as CantPosible";
            sqldisponible += " from SC060100";
            sqldisponible += " inner join (select SC03001 as Producto, sum(SC03003-SC03004) as Cant";
            sqldisponible += " from SC030100";
            sqldisponible += " where (SC03002='01' or SC03002='03' or SC03002='05' or SC03002='08' or SC03002='09') and SC03003-SC03004>=0";
            sqldisponible += " group by SC03001";
            sqldisponible += ") A";
            sqldisponible += " on SC060100.SC06003 = A.Producto";
            sqldisponible += " where SC06001='B' and SC06004 > 0";
            sqldisponible += " group by SC06002";
            sqldisponible += " order by SC06002";
            
            string sqlfuturo = "select floor(min((A.Cant+isnull(B.PurchaseOrders, 0))/SC06004)) as CantPosible";
            sqlfuturo += " from SC060100";
	        sqlfuturo += " inner join (select SC03001 as Producto, sum(SC03003-SC03004) as Cant";
			sqlfuturo += " from SC030100";
			sqlfuturo += " where (SC03002='01' or SC03002='03' or SC03002='05' or SC03002='08' or SC03002='09')";
			sqlfuturo += " group by SC03001";
			sqlfuturo += " ) A";
	        sqlfuturo += " on SC060100.SC06003 = A.Producto";
        	sqlfuturo += " left outer join (SELECT dbo.PC030100.PC03005 AS Producto, SUM(dbo.PC030100.PC03010) AS PurchaseOrders";
			sqlfuturo += " FROM dbo.PC010100 INNER JOIN";
			sqlfuturo += " dbo.PC030100 ON dbo.PC010100.PC01001 = dbo.PC030100.PC03001";
			sqlfuturo += " WHERE (dbo.PC010100.PC01015 > '" + DateTime.Today.AddDays(dias) + "') AND (dbo.PC010100.PC01015 <= '" + fecha + "')";
			sqlfuturo += " GROUP BY dbo.PC030100.PC03005";
		    sqlfuturo += " ) B";
		    sqlfuturo += " on B.Producto = SC060100.SC06003";
	        sqlfuturo += " where SC06001='B' and SC06004 > 0";
	        sqlfuturo += " group by SC06002";
	        sqlfuturo += " order by SC06002";

            SqlConnection myConnection = new SqlConnection(connectionString);
            
            SqlDataAdapter dadisponible = new SqlDataAdapter(sqldisponible, myConnection);

            DataSet ds = new DataSet();
            
            ds.Tables.Add("Disponible");
            
            dadisponible.Fill(ds.Tables["Disponible"]);
            DataTable dt = ds.Tables["Disponible"];

            for (; fecha <= DateTime.Today; fecha = fecha.AddDays(1))
            {
                SqlCommand com = new SqlCommand(sqlfuturo, myConnection);
                SqlDataReader dr;
                myConnection.Open();
                dr = com.ExecuteReader();

                dt.Columns.Add(fecha.AddDays(-(dias)).ToShortDateString());
                while (dr.Read())
                {
                    dt.Columns[fecha.AddDays(-(dias)).ToShortDateString()].Table.Rows.Add(dr[0]);
                }

                dr.Close();
                myConnection.Close();
            }
            
            ds.WriteXml("c:/PruebasDesarme/all.xml");
            
            
        }
    }
}