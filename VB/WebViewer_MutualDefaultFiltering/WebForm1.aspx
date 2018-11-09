<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="WebForm1.aspx.vb" 
Inherits="WebViewer_MutualDefaultFiltering.WebForm1" %>

<%@ Register Assembly="DevExpress.Dashboard.v16.2.Web, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" 
            DashboardSource="WebViewer_MutualDefaultFiltering.Dashboard1"
            Height="480px" Width="800px" 
            onmasterfilterdefaultvalues="ASPxDashboardViewer1_MasterFilterDefaultValues">            
            <ClientSideEvents Loaded="function(s, e) {	s.SetMasterFilter('cardDashboardItem1', [['UK']]); }" />
        </dx:ASPxDashboardViewer>
    </div>
    </form>
</body>
</html>