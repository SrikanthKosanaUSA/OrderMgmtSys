<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs" Inherits="UsaMarketingNtier.Item" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 390px; width: 818px">
    
        <asp:HyperLink ID="hlAdd" runat="server" style="z-index: 1; left: 17px; top: 64px; position: absolute" NavigateUrl="~/ItemEdit.aspx?mode=add">Create New</asp:HyperLink>
        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" style="z-index: 1; left: 15px; top: 101px; position: absolute; height: 133px; width: 187px" OnRowCommand="gvItem_RowCommand" OnRowDataBound="gvItem_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ItemID" HeaderText="ItemID" InsertVisible="False" ReadOnly="True" SortExpression="ItemID" />
                <asp:BoundField DataField="ItemNumber" HeaderText="ItemNumber" SortExpression="ItemNumber" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="ItemID" DataNavigateUrlFormatString="~/ItemEdit.aspx?mode=edit&amp;itemID={0}" />
                <asp:HyperLinkField Text="Details" DataNavigateUrlFields="ItemID" DataNavigateUrlFormatString="~/ItemEdit.aspx?mode=read&amp;itemID={0}" />
                <asp:ButtonField CommandName="DeleteItem" Text="Delete" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>