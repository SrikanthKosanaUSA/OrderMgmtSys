<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemEdit.aspx.cs" Inherits="UsaMarketingNtier.ItemEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 159px;
        }
        .auto-style3 {
            height: 23px;
            width: 159px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 406px">
    
        <asp:HyperLink ID="hlBackToItem" runat="server" NavigateUrl="~/ItemList.aspx" style="z-index: 1; left: 624px; top: 31px; position: absolute">Back to Item List</asp:HyperLink>
        <asp:GridView ID="gvLineItem" runat="server" AutoGenerateColumns="False" DataKeyNames="LineItemID" style="z-index: 1; left: 16px; top: 237px; position: absolute; height: 133px; width: 577px">
            <Columns>
                <asp:BoundField DataField="LineItemID" HeaderText="LineItemID" InsertVisible="False" ReadOnly="True" SortExpression="LineItemID" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" SortExpression="InvoiceID" />
                <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                <asp:HyperLinkField DataNavigateUrlFields="LineItemID" DataNavigateUrlFormatString="~/LineItemEdit.aspx?mode=edit&amp;lineitemID={0}" Text="Edit" />
                <asp:ButtonField CommandName="DeleteLineItem" Text="Delete" />
            </Columns>
        </asp:GridView>
    
        <table style="width: 58%; z-index: 1; left: 17px; top: 91px; position: absolute; height: 31px;">
            <tr>
                <td class="auto-style3">ItemID:</td>
                <td class="auto-style1">
                    <asp:Label ID="lblItemID" runat="server"></asp:Label>
                </td>
               
            </tr>
            <tr>
                <td class="auto-style2">ItemNumber:</td>
                <td>
                    <asp:TextBox ID="txtItemNumber" runat="server" Width="212px"></asp:TextBox>
                </td>
              
            </tr>
            <tr>
                <td class="auto-style2">Description:</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Width="210px"></asp:TextBox>
                </td>
               
            </tr>
             <tr>
                <td class="auto-style3">UnitPrice:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtUnitPrice" runat="server" Width="217px"></asp:TextBox>
                 </td>
               
            </tr>
        </table>
    
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" style="z-index: 1; left: 19px; top: 201px; position: absolute" Text="Save Changes" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" style="z-index: 1; left: 151px; top: 201px; position: absolute" Text="Cancel" />
    
    </div>
    </form>
</body>
</html>

