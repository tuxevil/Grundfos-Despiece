<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Grundfos_Despiece.users.changepassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8"
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" ChangePasswordButtonText="Cambiar Contrase�a"
        ChangePasswordFailureText="Contrase�a incorrecta o Nueva contrase�a invalida. Longitud minima de nueva contrase�a: {0}. Caracteres alfanumericos requeridos: {1}."
        ChangePasswordTitleText="Cambie su contrase�a" ConfirmNewPasswordLabelText="Confirmar nueva contrase�a:"
        ConfirmPasswordCompareErrorMessage="La confirmacion de la nueva contrase�a debe coincidir con la nueva contrase�a introducida."
        ConfirmPasswordRequiredErrorMessage="Se requiere confirmacion de la nueva contrase�a."
        ContinueButtonText="Continuar" Font-Names="Verdana" Font-Size="0.8em" NewPasswordLabelText="Nueva Contrase�a:"
        NewPasswordRegularExpressionErrorMessage="Por favor ingrese una contrase�a diferente:"
        NewPasswordRequiredErrorMessage="Se requiere contrase�a nueva." PasswordLabelText="Contrase�a:"
        PasswordRequiredErrorMessage="Se requiere contrase�a." SuccessText="Su contrase�a ha sido cambiada."
        SuccessTitleText="Cambio de contrase�a completado." UserNameLabelText="Usuario:"
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
