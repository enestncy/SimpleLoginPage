<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>

    <tr>
    <td>Enter Username</td>
    <td><asp:TextBox ID="t3" runat="server" ontextchanged="t3_TextChanged"></asp:TextBox></td>
    </tr>

    <tr>
    <td>Enter Password</td>
    <td><asp:TextBox ID="t4" runat="server" TextMode="Password" 
            ontextchanged="t4_TextChanged"></asp:TextBox></td>
    </tr>

    <tr>
    <td colspan="2" align="left">
        <asp:Button ID="b4" runat="server" Text="Register" onclick="b4_Click" 
            style="height: 29px" />
    </td>
    </tr>

     <tr>
    <td colspan="2" align="left">
        <asp:Button ID="b5" runat="server" Text="Back to Login" onclick="b5_Click" 
            style="height: 29px" />
    </td>
    </tr>

    <tr>
    <td colspan="2">
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </td>
    </tr>

    </table>
    </div>
    </form>
</body>
</html>
