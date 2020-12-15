<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Part4.CompanyClient.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family:Arial">
    <table style="border:1px solid black">
    <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Get Public Information" 
            Width="300px" onclick="Button1_Click"/>
    </td>
    <td>
        <asp:Label ID="Label1" runat="server" Font-Bold="true"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="Button2" runat="server" Text="Get Confidential Information" 
            Width="300px" onclick="Button2_Click" style="height: 21px" />
    </td>
    <td>
        <asp:Label ID="Label2" runat="server"  Font-Bold="true"></asp:Label>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
