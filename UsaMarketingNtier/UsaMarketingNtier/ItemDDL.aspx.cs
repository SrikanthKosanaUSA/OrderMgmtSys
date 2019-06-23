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
    public partial class ItemDDL : System.Web.UI.Page
    {

        public const int DeleteCol = 7; 
        string ConnectionString = WebConfigurationManager.ConnectionStrings["USAMarketing"].ConnectionString;
                
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetFormMode();    //this will make our methods more thin cohesive means if it is not post back then only this method will be called, in this way the performance will be integrated...
            }
        }
        #region "Click event handlers for page controllers"
       
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItem.SelectedValue == "0")
            {
                gvLineItem.DataSource = null;
                gvLineItem.DataBind();
            }
            else
            {
                PopulateLineItemList(ConnectionString);
            }
        }
        protected void gvLineItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteLineItem")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int LineItemID = Convert.ToInt32(gvLineItem.DataKeys[index].Value);
                //DeleteLineItem(LineItemID);
                //PopulateLineItemList(ConnectionString);
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

        protected void SetFormMode()
        {
            PopulateItemList(ConnectionString);
            ddlItem.SelectedIndex = 0;
        }   
        protected void PopulateItemList(string ConnectionString)
        {
            daUSAMarketing daItem = new daUSAMarketing();     //this loc helps presentation tier to get access the data access tier

            ddlItem.DataSource = daItem.GetItemModel(ConnectionString);  //this loc is equivalent to 'Choose data source' if the gv of table.
            ddlItem.AppendDataBoundItems = true;
            ddlItem.Items.Add(new ListItem("Select an Item", "0"));
            ddlItem.DataTextField = "ItemNumber";
            ddlItem.DataValueField = "ItemID";
            ddlItem.DataBind();
        }

        protected void PopulateLineItemList(string ConnectionString)
        {
            daUSAMarketing daLineItem = new daUSAMarketing();     //this loc helps presentation tier to get access the data access tier
            DataTable dtLineItem = new DataTable();
            dtLineItem = daLineItem.GetLineItemModel(ConnectionString);
            DataView dvLineItem = dtLineItem.DefaultView;

            dvLineItem.RowFilter = "ItemID = " + ddlItem.SelectedValue.ToString();   //this loc is equivalent to the LINQ expression in MVC in which we used to filter the model... 

            gvLineItem.DataSource = dvLineItem;
            gvLineItem.DataBind();
        }

        #endregion
    }
}