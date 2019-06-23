using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAMarketingNtier.DataAccessLayer;
using System.Web.Configuration;

namespace UsaMarketingNtier
{
    public partial class Item : System.Web.UI.Page
    {
        public const int ItemIDCol = 0;
        public const int DeleteCol = 6;    // this helps us to avoid hard coding the numbers in our data row bound method...
        string ConnectionString = WebConfigurationManager.ConnectionStrings["USAMarketing"].ConnectionString; 
        //In general, event handlers should only contain two things
        //1. Calls to the methods
        //2. Direct Input/Output interactions
        //like controllers in mvc, Our eventhandlers should be very thin and cohesive.

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateItemList(ConnectionString);
            }
        }
       
        #region "Click event handlers for page controllers"

        protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="DeleteItem")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int ItemID = Convert.ToInt32(gvItem.DataKeys[index].Value);
                DeleteItem(ItemID);
                PopulateItemList(ConnectionString);
            }
        }

        protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[DeleteCol].Attributes.Add("onClick", "return confirm('Do you want to delete this Item?')");  //Attributes are key-value pairs...
            }
        }

        #endregion

        #region "Local Methods"
       
        protected void PopulateItemList(string ConnectionString)
        {
            daUSAMarketing daItem = new daUSAMarketing();     //this loc helps presentation tier to get access the data access tier

            gvItem.DataSource = daItem.GetItemModel(ConnectionString);  //this loc is equivalent to 'Choose data source' if the gv of table.
            gvItem.DataBind();
        }

        private void DeleteItem(Int32 ItemID)
        {
            daUSAMarketing daItem = new daUSAMarketing();
            daItem.DeleteItem(ItemID, ConnectionString);
        }

        #endregion

       
        
    }
}