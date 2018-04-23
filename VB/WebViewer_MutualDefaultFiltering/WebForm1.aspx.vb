Imports System
Imports System.Linq
Imports DevExpress.DashboardWeb

Namespace WebViewer_MutualDefaultFiltering
    Partial Public Class WebForm1
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub ASPxDashboardViewer1_MasterFilterDefaultValues(ByVal sender As Object, _
                                                                     ByVal e As MasterFilterDefaultValuesWebEventArgs)
            If e.ItemComponentName = "gridDashboardItem1" Then
                e.FilterValues = e.AvailableFilterValues.Where(Function(v) CStr(v("CategoryName")) = "Beverages" _
                                                                   OrElse CStr(v("CategoryName")) = "Condiments")
            End If

            ' Use the SetMasterFilter client-side method (see WebForm1.aspx) instead of the code below as a workaround to
            ' apply filtering to the 'cardDashboardItem1'.
            If e.ItemComponentName = "cardDashboardItem1" Then
                e.FilterValues = e.AvailableFilterValues.Where(Function(v) CStr(v("Country")) = "UK")
            End If
        End Sub
    End Class
End Namespace