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
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int week = 46;
            int year = 2008;

            string connectionString = "data source=dbserver;User ID=grundfos;Password=grundfos;database=Grundfos_StockForecast";
            SqlConnection myConnection = new SqlConnection(connectionString);

            string sqlproducts = "SELECT dbo.Product.Id, dbo.Product.ProductCode, dbo.Product.Description";
            sqlproducts += " FROM dbo.Forecast";
            sqlproducts += " INNER JOIN dbo.Product";
            sqlproducts += " ON dbo.Product.Id = dbo.Forecast.ProductID";
            sqlproducts += " WHERE (dbo.Forecast.Sale > 0) and dbo.Product.ProductCode not in (SELECT distinct Grundfos_StockViewer.dbo.despiece.productcode from Grundfos_StockViewer.dbo.despiece)";
            sqlproducts += " GROUP BY dbo.Product.Id, dbo.Product.ProductCode, dbo.Product.Description";
            sqlproducts += " ORDER BY dbo.Product.ProductCode";

            DataSet ds = new DataSet();
            ds.Tables.Add("Datos");
            ds.Tables["Datos"].Columns.Add("ID");
            ds.Tables["Datos"].Columns.Add("Codigo");
            ds.Tables["Datos"].Columns.Add("Descripcion");

            for(;((week > 45) && (year == 2008))||((week < 11)&&(year == 2009));)
            {
                ds.Tables["Datos"].Columns.Add(week.ToString() + "/" + year.ToString());
                
                if(week==52)
                {
                    week = 1;
                    year = 2009;
                }
                else
                    week++;
            }
            
                        
            SqlCommand comcalc = new SqlCommand(sqlproducts, myConnection);
            SqlDataReader drcalc;
            myConnection.Open();
            drcalc = comcalc.ExecuteReader();

            

            while (drcalc.Read())
            {
                int cont = 3;
                
                string sqldatos = "select FinalStock";
                sqldatos += " from Forecast";
                sqldatos += " inner join Product";
                sqldatos += " on Product.Id = Forecast.ProductID";
                sqldatos += " where Product.ProductCode = '" + drcalc[0] + "' and Forecast.Sale > 0";
                sqldatos += " order by Product.ProductCode";

                DataRow fila = ds.Tables["Datos"].NewRow();
                
                fila[0] = drcalc[0].ToString();
                fila[1] = drcalc[1].ToString();
                fila[2] = drcalc[2].ToString();
                
                SqlConnection myConnection2 = new SqlConnection(connectionString);
                SqlCommand comcalc2 = new SqlCommand(sqldatos, myConnection2);
                SqlDataReader drcalc2;
                myConnection2.Open();
                drcalc2 = comcalc2.ExecuteReader();
                while (drcalc2.Read())
                {
                    fila[cont] = drcalc2[0].ToString();
                    cont++;
                }
                drcalc2.Close();
                myConnection2.Close();

                ds.Tables["Datos"].Rows.Add(fila);

                
            }
            drcalc.Close();
            myConnection.Close();
            
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int week = 46;
            int year = 2008;

            string connectionString = "data source=dbserver;User ID=grundfos;Password=grundfos;database=Grundfos_StockForecast";
            SqlConnection myConnection = new SqlConnection(connectionString);

            string sqlproducts = "SELECT dbo.Product.Id, dbo.Product.ProductCode, dbo.Product.Description";
            sqlproducts += " FROM dbo.Forecast";
            sqlproducts += " INNER JOIN dbo.Product";
            sqlproducts += " ON dbo.Product.Id = dbo.Forecast.ProductID";
            sqlproducts += " WHERE QuantitySuggested > 0 and week = 46 and Sale > 0 and dbo.Product.ProductCode not in (SELECT distinct Grundfos_StockViewer.dbo.despiece.productcode from Grundfos_StockViewer.dbo.despiece)";
            sqlproducts += " GROUP BY dbo.Product.Id, dbo.Product.ProductCode, dbo.Product.Description";
            sqlproducts += " ORDER BY dbo.Product.ProductCode";

            DataSet ds = new DataSet();
            ds.Tables.Add("Datos");
            ds.Tables["Datos"].Columns.Add("ID");
            ds.Tables["Datos"].Columns.Add("Codigo");
            ds.Tables["Datos"].Columns.Add("Descripcion");

            for (; ((week > 45) && (year == 2008)) || ((week < 11) && (year == 2009)); )
            {
                ds.Tables["Datos"].Columns.Add(week.ToString() + "/" + year.ToString());

                if (week == 52)
                {
                    week = 1;
                    year = 2009;
                }
                else
                    week++;
            }


            SqlCommand comcalc = new SqlCommand(sqlproducts, myConnection);
            SqlDataReader drcalc;
            myConnection.Open();
            drcalc = comcalc.ExecuteReader();



            while (drcalc.Read())
            {
                int cont = 3;

                string sqldatos = "select FinalStock";
                sqldatos += " from Forecast";
                sqldatos += " inner join Product";
                sqldatos += " on Product.Id = Forecast.ProductID";
                sqldatos += " where Product.ProductCode = '" + drcalc[1] + "' and Forecast.Sale > 0";
                sqldatos += " order by Product.ProductCode";

                DataRow fila = ds.Tables["Datos"].NewRow();

                fila[0] = drcalc[0].ToString();
                fila[1] = drcalc[1].ToString();
                fila[2] = drcalc[2].ToString();

                SqlConnection myConnection2 = new SqlConnection(connectionString);
                SqlCommand comcalc2 = new SqlCommand(sqldatos, myConnection2);
                SqlDataReader drcalc2;
                myConnection2.Open();
                drcalc2 = comcalc2.ExecuteReader();
                while (drcalc2.Read())
                {
                    fila[cont] = drcalc2[0].ToString();
                    cont++;
                }
                drcalc2.Close();
                myConnection2.Close();

                ds.Tables["Datos"].Rows.Add(fila);


            }
            drcalc.Close();
            myConnection.Close();

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}
