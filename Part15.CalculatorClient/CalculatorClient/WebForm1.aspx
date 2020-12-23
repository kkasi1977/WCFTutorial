<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CalculatorClient.WebForm1" %>

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
            <td>
                <asp:Label ID="Label1" runat="server" Text="Numerator:" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNumerator" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Denominator:" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDenominator" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnDivide" runat="server" Text="Device" Font-Bold="True" 
                    onclick="btnDivide_Click" />
            </td>
            <td>
                <asp:Label ID="lblResult" runat="server" Text="[lblResult]" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        </table>
      
    
    </div>
    </form>
</body>
</html>
