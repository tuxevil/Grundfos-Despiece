<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Grundfos_Despiece.users.changepassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8"
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" ChangePasswordButtonText="Cambiar Contraseña"
        ChangePasswordFailureText="Contraseña incorrecta o Nueva contraseña invalida. Longitud minima de nueva contraseña: {0}. Caracteres alfanumericos requeridos: {1}."
        ChangePasswordTitleText="Cambie su contraseña" ConfirmNewPasswordLabelText="Confirmar nueva contraseña:"
        ConfirmPasswordCompareErrorMessage="La confirmacion de la nueva contraseña debe coincidir con la nueva contraseña introducida."
        ConfirmPasswordRequiredErrorMessage="Se requiere confirmacion de la nueva contraseña."
        ContinueButtonText="Continuar" Font-Names="Verdana" Font-Size="0.8em" NewPasswordLabelText="Nueva Contraseña:"
        NewPasswordRegularExpressionErrorMessage="Por favor ingrese una contraseña diferente:"
        NewPasswordRequiredErrorMessage="Se requiere contraseña nueva." PasswordLabelText="Contraseña:"
        PasswordRequiredErrorMessage="Se requiere contraseña." SuccessText="Su contraseña ha sido cambiada."
        SuccessTitleText="Cambio de contraseña completado." UserNameLabelText="Usuario:"
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
