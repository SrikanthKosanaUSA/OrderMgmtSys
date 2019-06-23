<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemDDL.aspx.cs" Inherits="UsaMarketingNtier.ItemDDL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 410px">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" style="z-index: 1; left: 31px; top: 53px; position: absolute; height: 22px; width: 61px" Text="ItemName:"></asp:Label>
        <asp:DropDownList ID="ddlItem" runat="server" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" style="z-index: 1; left: 126px; top: 49px; position: absolute" Width="200px">
        </asp:DropDownList>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
               <asp:AsyncPostBackTrigger ControlID="ddlItem" EventName="SelectedIndexChanged"/>
            </Triggers>
            <ContentTemplate>
            <asp:GridView ID="gvLineItem" 
              runat="server" 
              AutoGenerateColumns="False" 
              DataKeyNames="LineItemID" style="z-index: 1; left: 26px; top: 113px; position: absolute; height: 133px; width: 577px"
               OnRowCommand="gvLineItem_RowCommand" 
              OnRowDataBound="gvLineItem_RowDataBound">
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
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>
    </form>
</body>
</html>
