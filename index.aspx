﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

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
    <td colspan="2">
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </td>
    </tr>

    <tr>
    <td colspan="2" align="left">
        <asp:Button ID="b4" runat="server" Text="Trade" onclick="b4_Click" />
    </td>
    </tr>

    <tr>
    <td colspan="2" align="left">
        <asp:Button ID="b3" runat="server" Text="Logout" onclick="b3_Click" />
    </td>
    </tr>

    </table>
    </div>
    </form>
</body>
</html>
