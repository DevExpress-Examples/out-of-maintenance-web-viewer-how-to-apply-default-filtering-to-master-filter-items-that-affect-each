using System;
using System.Linq;
using DevExpress.DashboardWeb;

namespace WebViewer_MutualDefaultFiltering {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ASPxDashboardViewer1_MasterFilterDefaultValues(object sender, MasterFilterDefaultValuesWebEventArgs e) {
            if (e.ItemComponentName == "gridDashboardItem1")
                e.FilterValues = e.AvailableFilterValues.Where(v => (string)v["CategoryName"] == "Beverages" ||
                    (string)v["CategoryName"] == "Condiments");

            // Use the SetMasterFilter client-side method (see WebForm1.aspx) instead of the code below as a workaround to
            // apply filtering to the 'cardDashboardItem1'.
            if (e.ItemComponentName == "cardDashboardItem1")
                e.FilterValues = e.AvailableFilterValues.Where(v => (string)v["Country"] == "UK");
        }
    }
}