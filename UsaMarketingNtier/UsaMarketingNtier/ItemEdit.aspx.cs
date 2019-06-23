using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAMarketingNtier.DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace UsaMarketingNtier
{
    public partial class ItemEdit : System.Web.UI.Page
    {
        public const int DeleteCol = 7;
        string ConnectionString = WebConfigurationManager.ConnectionStrings["USAMarketing"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateItemInfo();    //this will make our methods more thin cohesive means if it is not post back then only this method will be called, in this way the performance will be integrated...
            }
        }
       
        #region "Click event handlers for page controllers"

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "add")
            {
                AddItem();
                Response.Redirect("ItemList.aspx");
            }
            else if (Request.QueryString["mode"] == "edit")
            {
                UpdateItem();
                Response.Redirect("ItemList.aspx");
                
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetFormMode();
        }

        protected void gvLineItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="DeleteLineItem")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int LineItemID = Convert.ToInt32(gvLineItem.DataKeys[index].Value);
                DeleteLineItem(LineItemID);
                PopulateLineItemList(ConnectionString);
            }
        }
        protected void gvLineItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[DeleteCol].Attributes.Add("onClick", "return confirm('Do you want to delete this LineItem?')");  //Attributes are key-value pairs...
            }
        }
        #endregion

        #region "Local Methods"

        protected void SetFormMode()        //this method will initializes the page..
        {

            if (Request.QueryString["mode"] == "add")   //we have this setformmode method o keep our Event handlers thin..
            {
                lblItemID.Text = "";
                txtItemNumber.Text = "";
                txtDescription.Text = "";
                txtUnitPrice.Text = "";
            }
            else if (Request.QueryString["mode"] == "edit")
            {
                PopulateItemInfo();
                PopulateLineItemList(ConnectionString);
            }
            else if (Request.QueryString["mode"] == "read")
            {
                PopulateItemInfo();
                txtItemNumber.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtUnitPrice.ReadOnly = true;
                PopulateLineItemList(ConnectionString);
            }
        }

        private void PopulateItemInfo()
        {
            daUSAMarketing daItem = new daUSAMarketing();     //this loc helps presentation tier to get access the data access tier
            DataTable dtItem = new DataTable();
            dtItem = daItem.GetItemModel(ConnectionString);
            DataView dvItem = dtItem.DefaultView;

            dvItem.RowFilter = "ItemID = " + Request.QueryString["itemID"].ToString();   //this loc is equivalent to the LINQ expression in MVC in which we is used to filter the model... 

            lblItemID.Text = dvItem[0]["ItemID"].ToString();
            txtItemNumber.Text = dvItem[0]["ItemNumber"].ToString();
            txtDescription.Text = dvItem[0]["Description"].ToString();
            txtUnitPrice.Text = dvItem[0]["UnitPrice"].ToString();

        }

        protected void PopulateLineItemList(string ConnectionString)
        {
            daUSAMarketing daLineItem = new daUSAMarketing();     //this loc helps presentation tier to get access the data access tier
            DataTable dtLineItem = new DataTable();
            dtLineItem = daLineItem.GetLineItemModel(ConnectionString);
            DataView dvLineItem = dtLineItem.DefaultView;

            dvLineItem.RowFilter = "ItemID = " + Request.QueryString["itemID"].ToString();   //this loc is equivalent to the LINQ expression in MVC in which we used to filter the model... 

            gvLineItem.DataSource = dvLineItem;
            gvLineItem.DataBind();
        }

        private void AddItem()
        {
            daUSAMarketing daItem = new daUSAMarketing();
            daItem.AddItem(txtItemNumber.Text, txtDescription.Text, txtUnitPrice.Text, ConnectionString);
        }

        private void UpdateItem()
        {
            daUSAMarketing daItem = new daUSAMarketing();
            daItem.UpdateItem(Convert.ToInt32(lblItemID.Text), txtItemNumber.Text, txtDescription.Text, txtUnitPrice.Text, ConnectionString);
        }

        private void DeleteLineItem(Int32 LineItemID)
        {
            daUSAMarketing daLineItem = new daUSAMarketing();
            daLineItem.DeleteLineItem(LineItemID, ConnectionString);
        }
       
        #endregion

       
        //protected void dvItemDetails_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        //{
        //    Response.Redirect("ItemList.aspx");
        //}

        //protected void dvItemDetails_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        //{
        //    Response.Redirect("ItemList.aspx");
        //}
    }
}