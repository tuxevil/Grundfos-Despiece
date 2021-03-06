<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Grundfos_Despiece.users.changepassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8"
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" ChangePasswordButtonText="Cambiar Contraseņa"
        ChangePasswordFailureText="Contraseņa incorrecta o Nueva contraseņa invalida. Longitud minima de nueva contraseņa: {0}. Caracteres alfanumericos requeridos: {1}."
        ChangePasswordTitleText="Cambie su contraseņa" ConfirmNewPasswordLabelText="Confirmar nueva contraseņa:"
        ConfirmPasswordCompareErrorMessage="La confirmacion de la nueva contraseņa debe coincidir con la nueva contraseņa introducida."
        ConfirmPasswordRequiredErrorMessage="Se requiere confirmacion de la nueva contraseņa."
        ContinueButtonText="Continuar" Font-Names="Verdana" Font-Size="0.8em" NewPasswordLabelText="Nueva Contraseņa:"
        NewPasswordRegularExpressionErrorMessage="Por favor ingrese una contraseņa diferente:"
        NewPasswordRequiredErrorMessage="Se requiere contraseņa nueva." PasswordLabelText="Contraseņa:"
        PasswordRequiredErrorMessage="Se requiere contraseņa." SuccessText="Su contraseņa ha sido cambiada."
        SuccessTitleText="Cambio de contraseņa completado." UserNameLabelText="Usuario:"
        UserNameRequiredErrorMessage="Se requiere Usuario:">
        <CancelButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <PasswordHintStyle Font-Italic="True" ForeColor="#888888" />
        <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <ChangePasswordButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        <TextBoxStyle Font-Size="0.8em" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
    </asp:ChangePassword>
</asp:Content>
