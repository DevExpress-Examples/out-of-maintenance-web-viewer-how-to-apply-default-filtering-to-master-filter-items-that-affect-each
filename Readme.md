<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128580517/16.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T474935)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [WebForm1.aspx](./CS/WebViewer_MutualDefaultFiltering/WebForm1.aspx) (VB: [WebForm1.aspx](./VB/WebViewer_MutualDefaultFiltering/WebForm1.aspx))
* [WebForm1.aspx.cs](./CS/WebViewer_MutualDefaultFiltering/WebForm1.aspx.cs) (VB: [WebForm1.aspx.vb](./VB/WebViewer_MutualDefaultFiltering/WebForm1.aspx.vb))
<!-- default file list end -->
# Web Viewer - How to apply default filtering to master filter items that affect each other


The ASPxDashboardViewer control allows you to apply default filtering using the following events

* <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebASPxDashboardViewer_MasterFilterDefaultValuestopic">MasterFilterDefaultValues</a>.
* <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebASPxDashboardViewer_RangeFilterDefaultValuetopic">RangeFilterDefaultValue</a>.<br>- <strong>FilterElementDefaultValues</strong> (v16.1 and earlier).
* <strong>SingleFilterDefaultValue</strong> (v16.1 and earlier).<br>If your dashboard contains several master filter items that affect each other, filtering may not be applied to some items due to architectural limitations of DevExpress Dashboard. Let's consider the following scenario: a dashboard contains the Grid and Card dashboard items that affect each other. If you handle the MasterFilterDefaultValues event for both items, filtering will not be applied to the <em>Extended Price</em> column of Grid 1:<br><strong><strong>code:<br></strong></strong>


```cs
        protected void ASPxDashboardViewer1_MasterFilterDefaultValues(object sender, MasterFilterDefaultValuesWebEventArgs e) {
            if (e.ItemComponentName == "gridDashboardItem1") {
                e.FilterValues = e.AvailableFilterValues.Where(v => (string)v["CategoryName"] == "Beverages" ||
                    (string)v["CategoryName"] == "Condiments");
            }
            if (e.ItemComponentName == "cardDashboardItem1")
                e.FilterValues = e.AvailableFilterValues.Where(v => (string)v["Country"] == "UK");
        }
```


 <strong>result:</strong><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/web-viewer-how-to-apply-default-filtering-to-master-filter-items-that-affect-each-other-t474935/16.2.3+/media/43572027-e15b-11e6-80bf-00155d62480c.png"><br><br><br>As a workaround, you need to call the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboardViewer_SetMasterFiltertopic">SetMasterFilter</a> client-side method for Cards 1. In this case, filtering will be applied correctly:<br><strong><strong>code:<br></strong></strong>


```aspx
        <dx:ASPxDashboardViewer ...>            
            <ClientSideEvents Loaded="function(s, e) {	s.SetMasterFilter('cardDashboardItem1', [['UK']]); }" />
        </dx:ASPxDashboardViewer>
```




```cs
        protected void ASPxDashboardViewer1_MasterFilterDefaultValues(object sender, MasterFilterDefaultValuesWebEventArgs e) {
            if (e.ItemComponentName == "gridDashboardItem1") 
                e.FilterValues = e.AvailableFilterValues.Where(v => (string)v["CategoryName"] == "Beverages" ||
                    (string)v["CategoryName"] == "Condiments");
        }
```


<strong><br><br>result:</strong><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/web-viewer-how-to-apply-default-filtering-to-master-filter-items-that-affect-each-other-t474935/16.2.3+/media/6014919f-e157-11e6-80bf-00155d62480c.png">

<br/>


