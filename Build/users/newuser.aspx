<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="newuser.aspx.cs" Inherits="Grundfos_Despiece.newuser" Title="Creacion de Cuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" CompleteSuccessText="Su cuenta ha sido creada satisfactoriamente." ConfirmPasswordCompareErrorMessage="La contraseña y la confirmacion deben coincidir." ConfirmPasswordLabelText="Confirmar Contraseña" ConfirmPasswordRequiredErrorMessage="Se requiere confirmacion de contraseña" ContinueButtonText="Continuar" CreateUserButtonText="Crear Usuario" DuplicateEmailErrorMessage="El e-mail que ingreso ya esta en uso. Por favor ingrese uno diferente." DuplicateUserNameErrorMessage="Por favor ingrese su usuario." EmailRegularExpressionErrorMessage="Por favor ingrese un e-mail diferente." EmailRequiredErrorMessage="E-Mail requerido." FinishCompleteButtonText="Terminar" FinishPreviousButtonText="Anterior" Font-Names="Verdana" Font-Size="0.8em" InvalidAnswerErrorMessage="Por favor ingrese una respuesta de seguridad diferente." InvalidEmailErrorMessage="Por favor ingrese una e-mail valido." InvalidPasswordErrorMessage="Longitud minima de contraseña: {0}. Caracteres no alfanumericos requeridos: {1}." InvalidQuestionErrorMessage="Por favor ingrese una pregunta de seguridad diferente." PasswordRegularExpressionErrorMessage="Por favor ingrese una contraseña diferente." PasswordRequiredErrorMessage="Contraseña requerida." QuestionRequiredErrorMessage="Pregunta de seguridad requerida." OnCreatedUser="CreateUserWizard1_CreatedUser">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server">
                <ContentTemplate>
                    <table border="0" style="font-size: 100%; font-family: Verdana">
                        <tr>
                            <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d">
                                Creacion de Cuentas</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="text4">Usuario:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="Usuario requerido." ToolTip="Usuario requerido." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="text4">Contraseña:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Contraseña requerida." ToolTip="Contraseña requerida." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword" CssClass="text4">Confirmar Contraseña:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                    ErrorMessage="Confirmacion de contraseña requerida." ToolTip="Confirmacion de contraseña requerida."
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email" CssClass="text4">E-mail:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                    ErrorMessage="E-mail requerido." ToolTip="E-mail requerido." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question" CssClass="text4">Pregunta de Seguridad:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                    ErrorMessage="Pregunta de seguridad requerida." ToolTip="Pregunta de seguridad requerida."
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" CssClass="text4">Respuesta de Seguridad:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                    ErrorMessage="Respuesta de seguridad requerida." ToolTip="Respuesta de seguridad requerida."
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="La contraseña y la confirmacion deben coincidir."
                                    ValidationGroup="CreateUserWizard1" CssClass="text4"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color: red">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
        <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
        <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
        <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em"
            ForeColor="White" HorizontalAlign="Center" />
        <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <StepStyle BorderWidth="0px" />
    </asp:CreateUserWizard>
</center>
</asp:Content>
