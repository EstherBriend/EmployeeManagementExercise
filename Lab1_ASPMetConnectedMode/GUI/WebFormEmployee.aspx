<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployee.aspx.cs" Inherits="Lab1_ASPMetConnectedMode.GUI.WebFormEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin-top: 0px;
        }
        .auto-style2 {
            width: 227px;
        }
        .auto-style7 {
            width: 745px;
            height: 54px;
        }
        .auto-style8 {
            width: 745px;
        }
        .auto-style12 {
            height: 156px;
        }
        .auto-style13 {
            width: 202px;
        }
        .auto-style14 {
            height: 54px;
        }
        .auto-style15 {
            width: 227px;
            height: 48px;
        }
        .auto-style16 {
            width: 202px;
            height: 48px;
        }
        .auto-style17 {
            width: 140px;
            height: 48px;
        }
        .auto-style18 {
            width: 745px;
            height: 48px;
        }
        .auto-style19 {
            width: 140px;
        }
        .auto-style20 {
            width: 227px;
            height: 33px;
        }
        .auto-style21 {
            width: 202px;
            height: 33px;
        }
        .auto-style22 {
            width: 140px;
            height: 33px;
        }
        .auto-style23 {
            width: 745px;
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style14" colspan="3">
                        <asp:Label ID="lblFormTitle" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF6600" Text="Employee Maintenance"></asp:Label>
                    </td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblEmployeeID" runat="server" Text="Employee ID"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <asp:TextBox ID="txtEmployeeId" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style19">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="75px" />
                    </td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style19">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="75px" OnClick="btnUpdate_Click" />
                    </td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td class="auto-style21">
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style22">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="75px" OnClick="btnDelete_Click" />
                    </td>
                    <td class="auto-style23"></td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="lblJobTitle" runat="server" Text="Job Title"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style17">
                        <asp:Button ID="btnListAll" runat="server" OnClick="btnListAll_Click" Text="List All" Width="74px" />
                    </td>
                    <td class="auto-style18">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblSearchBy" runat="server" Text="Search By"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <asp:DropDownList ID="DropDownSearchBy" runat="server" Height="26px" Width="166px">
                            <asp:ListItem>ID</asp:ListItem>
                            <asp:ListItem>First Name</asp:ListItem>
                            <asp:ListItem>Last Name</asp:ListItem>
                            <asp:ListItem>Job Title</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style19">
                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblEmployeesList" runat="server" Font-Bold="True" ForeColor="Blue" Text="Employees List"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="auto-style12">
                        <asp:GridView ID="GridViewEmployees" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
