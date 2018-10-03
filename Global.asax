<%@ Application Language="C#" %>
<%@ Import Namespace="TrainingSite" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Web.Http" %>



<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
       
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        //GlobalConfiguration.Configure(WebApiConfig.Register);
        //add custom into script manager as reference
        ScriptManager.ScriptResourceMapping.AddDefinition("custom", new ScriptResourceDefinition
        {
            Path = "~/Scripts/custom.js",
            DebugPath = "~/Scripts/custom.js",
            CdnSupportsSecureConnection = true,

        });

    }


</script>
