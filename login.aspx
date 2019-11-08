<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

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
    <td><asp:TextBox ID="t1" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
    <td>Enter Password</td>
    <td><asp:TextBox ID="t2" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>

    <tr>
    <td colspan="2" align="left">
        <asp:Button ID="b1" runat="server" Text="Login" onclick="b1_Click" />
    </td>
    </tr>

    <tr>
    <td colspan="2" align="left">
        <asp:Button ID="b2" runat="server" Text="Register" onclick="b2_Click" />
    </td>
    </tr>

    <tr>
    <td colspan="2">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </td>
    </tr>
        
    </table>
    </div>
    </form>
</body>
</html>
