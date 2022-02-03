#pragma checksum "C:\Programowanie\C#\BugTracker\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47dfa05c5aa317bf93dfad73c0de556719d54790"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Programowanie\C#\BugTracker\Views\_ViewImports.cshtml"
using BugTracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Programowanie\C#\BugTracker\Views\_ViewImports.cshtml"
using BugTracker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47dfa05c5aa317bf93dfad73c0de556719d54790", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"415cd50ac37814e1a4fb76bf7d07627084cdfa27", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Programowanie\C#\BugTracker\Views\Home\Dashboard.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""offset-1 col-10""style=""height:35%"">
    <div id=""chartContainer""></div>
</div>

<div class=""row mt-5"">
    <div id=""chartContainer2"" class=""m-5 col-3"" style=""height:100%"">sadasdasd</div>
    <div id=""chartContainer3"" class=""m-5 col-3"" style=""height:100%"">sadasdasd</div>
    <div id=""chartContainer4"" class=""m-5 col-3"" style=""height:100%"">sadasdasd</div>
</div>




<script type=""text/javascript"">
	window.onload = function () {

		var chart = new CanvasJS.Chart(""chartContainer"", {
			animationEnabled: true,
			title: {
				text: ""Tickets By Projects""
            },

			axisY: {
				title: ""Number of tickets"",
				gridThickness: 0
			},
			data: [{
				bevelEnabled:false,
				type: ""bar"",
				indexLabel: ""{y}"",
				dataPoints: ");
#nullable restore
#line 35 "C:\Programowanie\C#\BugTracker\Views\Home\Dashboard.cshtml"
                       Write(Html.Raw(ViewBag.TicketsByProjectDataPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
		}]
		});

		var chart2 = new CanvasJS.Chart(""chartContainer2"", {
	animationEnabled: true,
	theme: ""light2"", // ""light1"", ""light2"", ""dark1"", ""dark2""
	title: {
		text: ""Tickets By Type""
	},
	axisY: {
		title: ""No. of Tickets""
	},
	data: [{
		type: ""column"",
		dataPoints: ");
#nullable restore
#line 50 "C:\Programowanie\C#\BugTracker\Views\Home\Dashboard.cshtml"
               Write(Html.Raw(ViewBag.TicketsByTypeDataPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
	}]
		});

			var chart3 = new CanvasJS.Chart(""chartContainer3"", {
	animationEnabled: true,
	theme: ""light2"", // ""light1"", ""light2"", ""dark1"", ""dark2""
	title: {
		text: ""Tickets By Priority""
	},
	axisY: {
		title: ""No. of Tickets""
	},
	data: [{
		type: ""column"",
		dataPoints: ");
#nullable restore
#line 65 "C:\Programowanie\C#\BugTracker\Views\Home\Dashboard.cshtml"
               Write(Html.Raw(ViewBag.TicketsByPriorityDataPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
	}]
			});

	var chart4 = new CanvasJS.Chart(""chartContainer4"", {
	animationEnabled: true,
	theme: ""light2"",
	title: {
		text: ""Tickets By Status""
	},

	data: [{
		type: ""pie"",
		
		toolTipContent: ""{name}: <strong>{y}%</strong>"",
		startAngle: -45,
		indexLabel: ""{label} ({y})"",
		indexLabelFontColor: ""#12122B"",
		indexLabelPlacement: ""inside"",
		indexLabelFontSize: 15,
		dataPoints: ");
#nullable restore
#line 85 "C:\Programowanie\C#\BugTracker\Views\Home\Dashboard.cshtml"
               Write(Html.Raw(ViewBag.TicketsByStatusDataPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t}]\r\n});\r\n\r\n\t\tchart.render();\r\n\t\tchart2.render();\r\n\t\tchart3.render();\r\n\t\tchart4.render();\r\n\t};\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591