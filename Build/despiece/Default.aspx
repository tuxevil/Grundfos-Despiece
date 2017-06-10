<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Grundfos_Despiece._Default" Title="Despiece de Productos Ensamblados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
<table width="100%" border="0" cellspacing="0" cellpadding="0" >
<tr class="fdo_tit">
    <td><asp:Label ID="Label4" runat="server" Text="Consulta de Productos Ensamblados" CssClass="text4" ForeColor="white" Font-Size="large"></asp:Label></td>
</tr>
<tr>
    <td valign="top">
        <table width="100%" border="0" cellspacing="0" cellpadding="5">
            <tr>
                <td>
                    <table width="100%" border="0" cellpadding="8" cellspacing="0">
                        <tr>
                            <td colspan="3" align="center" bgcolor="#4b7fa6"><span class="text2">Busqueda de stock del Producto</span></td>
                        </tr>
                        <tr>
                            <td colspan="3" bgcolor="e3e3e3">
                                &nbsp;<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="View1" runat="server">
                                    <table style="width: 550px">
                                            <tr valign="top">
                                                <td align="right" style="height: 41px" colspan="2"><asp:Label ID="Label1" runat="server" Text="Producto:" CssClass="text4"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 121px; height: 41px;"><asp:TextBox ID="TextBox1" runat="server" Width="200px" CssClass="text4" TabIndex="1"></asp:TextBox>
                                                    &nbsp;<br />
                                                    
                                                </td>
                                                <td style="width: 163px; text-align: left; height: 41px;"><asp:ImageButton ID="BotonBuscar" ImageUrl="~/images/btn_busc_producto.gif" runat="server" OnClick="BotonBuscar_Click" /><br />
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="text4" TabIndex="3">
                                                        <asp:ListItem Selected="True" Value="1">Descripci&#243;n</asp:ListItem>
                                                        <asp:ListItem Value="2">C&#243;digo</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td style="height: 110px" colspan="4">
                                            <asp:ListBox ID="ListBox2" runat="server" CssClass="text4" Rows="5" Width="500px" TabIndex="4" Height="120px"></asp:ListBox>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td style="height: 25px; text-align: left;" colspan="4">
                                                <asp:ImageButton ID="BotonSeleccionar" ImageUrl="~/images/btn_cons_stock.gif" runat="server" OnClick="BotonSeleccionar_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                    <table style="width: 550px">
                                            <tr>
                                                <td colspan="5" style="height: 25px; text-align: left">
                                                    &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CssClass="text4" ForeColor="Blue"
                                                        OnClick="LinkButton1_Click" TabIndex="9">Volver a Busqueda de Productos</asp:LinkButton></td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="5" style="text-align: center">
                                                    <asp:Label ID="Label5" runat="server" CssClass="text4" Font-Size="Small" Visible="False" Font-Bold="True"></asp:Label>
                                                    <asp:Label ID="Label6" runat="server" CssClass="text4" ForeColor="Red" Text="&#161;Ingrese un producto!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="text-align: right"><asp:Label ID="Label2" runat="server" Text="Fecha:" CssClass="text4"></asp:Label>
                                                    </td>
                                                <td align="right" style="text-align: left"><asp:TextBox ID="TextBox2" runat="server" Width="100px" CssClass="text4" TabIndex="6"></asp:TextBox></td>
                                                <td align="left" style="text-align: right">
                                                    &nbsp;<asp:Label ID="Label3" runat="server" Text="Cantidad:" CssClass="text4"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 147px;">
                                                    <asp:TextBox ID="TextBox3" runat="server" Width="100px" CssClass="text4" TabIndex="7"></asp:TextBox>
                                                    </td>
                                                <td style="width: 7px; text-align: left">
                                                    <asp:ImageButton ID="BotonConsultarStock" ImageUrl="~/images/btn_consultar.gif" runat="server" OnClick="BotonConsultarStock_Click" /></td>
                                            </tr>
                                            <tr>
                                            <td colspan="2">
                                            <asp:Label ID="Label8" runat="server" CssClass="text4" ForeColor="Red" Text="&#161;Ingrese una Fecha!" Visible="False"></asp:Label>
                                            </td>
                                                <td colspan="3">
                                            <asp:Label ID="Label9" runat="server" CssClass="text4" ForeColor="Red" Text="&#161;Ingrese una cantidad!" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                </asp:MultiView>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#0e4b88">
                                                                                                
                        <asp:GridView ID="GridView1" runat="server" CssClass="text4"  BackColor="#ecebeb" BorderColor="#999999" cellspacing="1" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="450px">
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#ECEBEB" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#0E4B88" CssClass="text2" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#E3E3E3" CssClass="text4" />
                    </asp:GridView>
                        <asp:Label ID="Label7" runat="server" CssClass="text4" Text="Plazo de Entrega: Minimo 7 dias"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</center>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday" TargetControlID="TextBox2" ></cc1:CalendarExtender>

</asp:Content>
