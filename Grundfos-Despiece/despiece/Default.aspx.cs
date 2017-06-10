using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace Grundfos_Despiece
{
    public partial class _Default : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Focus();
                TextBox2.Text = DateTime.Today.ToShortDateString();
                TextBox3.Text = "0";
            }
        }

        private DataSet Calculo(string producto, DateTime fechahoy, DateTime fechapedido)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

            SqlCommand com = new SqlCommand("sp_despiece", myConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@producto", SqlDbType.VarChar).Value = producto;
            com.Parameters.Add("@cantidad", SqlDbType.Int).Value = 1;
            
            DataSet calc = new DataSet();
            calc.Tables.Add("Calculo");
            calc.Tables["Calculo"].Columns.Add("CantidadNecesaria");
            calc.Tables["Calculo"].Columns.Add("Parte");
            calc.Tables["Calculo"].Columns.Add("Stock");
            calc.Tables["Calculo"].Columns.Add("CantidadDisponible");

            SqlDataReader drcalc;
            myConnection.Open();
            drcalc = com.ExecuteReader();

            while (drcalc.Read())
            {
                int cant = Convert.ToInt32(drcalc[2]);
                string product = drcalc[1].ToString();

                SqlConnection myConnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
                
                SqlCommand comcalc2 = new SqlCommand("sp_stockalternativo", myConnection2);
                comcalc2.CommandType = CommandType.StoredProcedure;
                comcalc2.Parameters.Add("@producto", SqlDbType.VarChar).Value = producto;

                SqlDataReader drcalc2;
                myConnection2.Open();
                drcalc2 = comcalc2.ExecuteReader();
                while (drcalc2.Read())
                {
                    string prueba = drcalc2[2].ToString();
                    if (fechapedido >= (Convert.ToDateTime(drcalc2[2])) && (Convert.ToDateTime(drcalc2[2]) != Convert.ToDateTime("9999-12-31")) && (Convert.ToDateTime(drcalc2[2]) != Convert.ToDateTime("1900-01-01")))
                    {
                        int ordcomp = 0;

                        SqlConnection myConnection3 = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
                        
                        SqlCommand comcalc3 = new SqlCommand("sp_ordcompras", myConnection3);
                        comcalc3.CommandType = CommandType.StoredProcedure;
                        comcalc3.Parameters.Add("@producto", SqlDbType.VarChar).Value = producto;
                        comcalc3.Parameters.Add("@fechahoy", SqlDbType.DateTime).Value = fechahoy;
                        comcalc3.Parameters.Add("@fechafinal", SqlDbType.DateTime).Value = fechapedido.AddDays(-3);

                        SqlDataReader drcalc3;
                        myConnection3.Open();
                        drcalc3 = comcalc3.ExecuteReader();
                        while (drcalc3.Read())
                        {
                            ordcomp = Convert.ToInt32(drcalc3[0]) + ordcomp;
                        }
                        drcalc3.Close();
                        myConnection3.Close();

                        cant = Convert.ToInt32(drcalc2[1]) + ordcomp;
                        product = drcalc2[0].ToString();
                    }
                    else if (fechapedido <= (Convert.ToDateTime(drcalc2[2])) || (Convert.ToDateTime(drcalc2[2]) == Convert.ToDateTime("99991231")) || (Convert.ToDateTime(drcalc2[2]) == Convert.ToDateTime("19000101")))
                    {
                        int ordcomp = 0;

                        SqlConnection myConnection3 = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

                        SqlCommand comcalc3 = new SqlCommand("sp_ordcompras", myConnection3);
                        comcalc3.CommandType = CommandType.StoredProcedure;
                        comcalc3.Parameters.Add("@producto", SqlDbType.VarChar).Value = drcalc2[0].ToString();
                        comcalc3.Parameters.Add("@fechahoy", SqlDbType.DateTime).Value = fechahoy;
                        comcalc3.Parameters.Add("@fechafinal", SqlDbType.DateTime).Value = fechapedido.AddDays(-3);
                                                
                        SqlDataReader drcalc3;
                        myConnection3.Open();
                        drcalc3 = comcalc3.ExecuteReader();
                        while (drcalc3.Read())
                        {
                            ordcomp = Convert.ToInt32(drcalc3[0]) + ordcomp;
                        }
                        drcalc3.Close();
                        
                        SqlCommand comcalc4 = new SqlCommand("sp_ordcompras", myConnection3);
                        comcalc4.CommandType = CommandType.StoredProcedure;
                        comcalc4.Parameters.Add("@producto", SqlDbType.VarChar).Value = drcalc[1].ToString();
                        comcalc4.Parameters.Add("@fechahoy", SqlDbType.DateTime).Value = fechahoy;
                        comcalc4.Parameters.Add("@fechafinal", SqlDbType.DateTime).Value = fechapedido.AddDays(-3);
                        
                        SqlDataReader drcalc4;
                        drcalc4 = comcalc4.ExecuteReader();
                        while (drcalc4.Read())
                        {
                            ordcomp = Convert.ToInt32(drcalc4[0]) + ordcomp;
                        }
                        drcalc4.Close();
                        myConnection3.Close();

                        cant = Convert.ToInt32(drcalc[2]) + Convert.ToInt32(drcalc2[1]) + ordcomp;
                        product = drcalc[1].ToString();
                    }
                    
                }
                if(drcalc2.HasRows == false)
                {
                    int ordcomp = 0;

                    SqlConnection myConnection3 = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

                    SqlCommand comcalc3 = new SqlCommand("sp_ordcompras", myConnection3);
                    comcalc3.CommandType = CommandType.StoredProcedure;
                    comcalc3.Parameters.Add("@producto", SqlDbType.VarChar).Value = drcalc[1].ToString();
                    comcalc3.Parameters.Add("@fechahoy", SqlDbType.DateTime).Value = fechahoy;
                    comcalc3.Parameters.Add("@fechafinal", SqlDbType.DateTime).Value = fechapedido.AddDays(-3);

                    SqlDataReader drcalc3;
                    myConnection3.Open();
                    drcalc3 = comcalc3.ExecuteReader();
                    while (drcalc3.Read())
                    {
                        ordcomp = Convert.ToInt32(drcalc3[0]) + ordcomp;
                    }
                    drcalc3.Close();
                    myConnection3.Close();

                    cant = Convert.ToInt32(drcalc[2]) + ordcomp;
                    product = drcalc[1].ToString();
                }
                drcalc2.Close();
                myConnection2.Close();

                calc.Tables["Calculo"].Rows.Add(drcalc[0], product, cant, cant / Convert.ToInt32(drcalc[0]));
            }
            drcalc.Close();
            myConnection.Close();

            
            
            return calc;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View1);
        }

        protected void BotonBuscar_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox1.Text.Trim() != "")
            {
                if (RadioButtonList1.SelectedValue == "1")
                {
                    ListBox2.Items.Clear();

                    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

                    SqlCommand com = new SqlCommand("sp_busqproductos", myConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@producto", SqlDbType.VarChar).Value = "%" + TextBox1.Text + "%";

                    SqlDataReader dr;
                    myConnection.Open();
                    dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        ListItem li = new ListItem(dr[1].ToString() + "  |  " + dr[0].ToString(), dr[1].ToString());
                        ListBox2.Items.Add(li);
                    }
                    dr.Close();
                    myConnection.Close();
                }
                else if (RadioButtonList1.SelectedValue == "2")
                {
                    ListBox2.Items.Clear();

                    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

                    SqlCommand com = new SqlCommand("sp_busqproductos2", myConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@producto", SqlDbType.VarChar).Value = "%" + TextBox1.Text + "%";

                    SqlDataReader dr;
                    myConnection.Open();
                    dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        ListItem li = new ListItem(dr[1].ToString() + "  |  " + dr[0].ToString(), dr[1].ToString());
                        ListBox2.Items.Add(li);
                    }
                    dr.Close();
                    myConnection.Close();
                }

            }

        }

        protected void BotonSeleccionar_Click(object sender, ImageClickEventArgs e)
        {
            if (ListBox2.SelectedItem != null)
            {
                TextBox1.Text = ListBox2.SelectedValue;
                Label2.Visible = true;
                TextBox2.Visible = true;
                Label3.Visible = true;
                TextBox3.Visible = true;
                Label5.Text = ListBox2.SelectedItem.ToString();
                Label5.Visible = true;
                MultiView1.SetActiveView(View2);
            }
        }

        protected void BotonConsultarStock_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
            {
                DateTime fechapedido = Convert.ToDateTime(TextBox2.Text);
                DateTime fechahoy = Convert.ToDateTime("07/11/2008");

                SqlConnection myConnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

                SqlCommand comcalc2 = new SqlCommand("sp_stock", myConnection2);
                comcalc2.CommandType = CommandType.StoredProcedure;
                comcalc2.Parameters.Add("@producto", SqlDbType.VarChar).Value = TextBox1.Text;

                SqlDataReader drcalc2;
                myConnection2.Open();
                drcalc2 = comcalc2.ExecuteReader();
                int cantdisp3 = 0;
                while (drcalc2.Read())
                {
                    cantdisp3 = cantdisp3 + Convert.ToInt32(drcalc2[1]);
                }
                drcalc2.Close();
                myConnection2.Close();

                DataSet calc = Calculo(TextBox1.Text, fechahoy, fechapedido);

                if (calc.Tables["Calculo"].Rows.Count != 0)
                {
                    int cantdisp = 10000;
                    DateTime entrega = fechapedido;
                    DataSet final = new DataSet();
                    final.Tables.Add("Final");
                    final.Tables["Final"].Columns.Add("Fecha");
                    final.Tables["Final"].Columns.Add("Cantidad");

                    foreach (DataRow datar in calc.Tables["Calculo"].Rows)
                    {
                        if (cantdisp == 0)
                            break;
                        if (Convert.ToInt32(datar.ItemArray[3]) < cantdisp)
                            cantdisp = Convert.ToInt32(datar.ItemArray[3]);
                    }
                    if (cantdisp < Convert.ToInt32(TextBox3.Text))
                    {
                        TimeSpan span = fechapedido.Subtract(fechahoy);
                        if (cantdisp > 0)
                            final.Tables["Final"].Rows.Add(entrega.ToShortDateString(), cantdisp + cantdisp3);
                        for (int cont = 1; cantdisp < Convert.ToInt32(TextBox3.Text) && cont <= 84 - span.Days; cont++)
                        {
                            int cantdisp2 = cantdisp;
                            DataSet calc2 = Calculo(TextBox1.Text, fechahoy, fechapedido.AddDays(cont));
                            cantdisp = 10000;
                            entrega = fechapedido.AddDays(cont);
                            foreach (DataRow datar in calc2.Tables["Calculo"].Rows)
                            {
                                if (cantdisp == 0)
                                    break;
                                if (Convert.ToInt32(datar.ItemArray[3]) < cantdisp)
                                    cantdisp = Convert.ToInt32(datar.ItemArray[3]);
                            }
                            if (cantdisp2 != cantdisp)
                                if (cantdisp > 0)
                                    final.Tables["Final"].Rows.Add(fechapedido.AddDays(cont).ToShortDateString(), cantdisp + cantdisp3);
                        }
                    }
                    if (cantdisp == 0)
                        final.Tables["Final"].Rows.Add(fechahoy.AddDays(84).ToShortDateString(), TextBox3.Text);
                    else
                    {
                        if (final.Tables["Final"].Rows.Count == 0)
                            if (cantdisp > 0)
                                final.Tables["Final"].Rows.Add(entrega.ToShortDateString(), cantdisp + cantdisp3);
                        if (cantdisp < Convert.ToInt32(TextBox3.Text))
                            final.Tables["Final"].Rows.Add(fechahoy.AddDays(84).ToShortDateString(), TextBox3.Text);
                    }


                    GridView1.DataSource = final;
                    GridView1.DataBind();
                    Label6.Visible = false;
                    Label8.Visible = false;
                    Label9.Visible = false;

                    SqlCommand comcalc = new SqlCommand("sp_seguimiento", myConnection2);
                    comcalc.CommandType = CommandType.StoredProcedure;
                    comcalc.Parameters.Add("@usuario", SqlDbType.UniqueIdentifier).Value = Membership.GetUser().ProviderUserKey;
                    comcalc.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Today;
                    comcalc.Parameters.Add("@busqueda", SqlDbType.VarChar).Value = TextBox1.Text;
                    comcalc.Parameters.Add("@fechabusqueda", SqlDbType.DateTime).Value = TextBox2.Text;
                    comcalc.Parameters.Add("@cantidadbusqueda", SqlDbType.Int).Value = TextBox3.Text;
                    comcalc.Parameters.Add("@ip", SqlDbType.BigInt).Value = ConvertIp( HttpContext.Current.Request.UserHostAddress);

                    SqlDataReader drcalc;
                    myConnection2.Open();
                    drcalc = comcalc.ExecuteReader();
                    drcalc.Read();
                    drcalc.Close();
                    myConnection2.Close();

                }
                else
                {
                    Label6.Text = "¡Ingrese un Producto Valido!";
                    Label6.Visible = true;
                }

            }
            else if (TextBox1.Text == "")
            {
                Label6.Visible = true;
                Label6.Text = "¡Ingrese un producto!";
            }
            else if (TextBox2.Text == "")
                Label8.Visible = true;
            else if (TextBox3.Text == "")
                Label9.Visible = true;
        }

        public static long ConvertIp(string ip)
        {

            string[] parts = ip.Split('.');

            string strhexip = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}",

              int.Parse(parts[0]), int.Parse(parts[1]),

              int.Parse(parts[2]), int.Parse(parts[3]));

            return Convert.ToInt64(strhexip, 16);

        }
    }
}
