#pragma checksum "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85c35b3cf3034a5c0fd390177e0aa143b3dd7032"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_Details), @"mvc.1.0.view", @"/Views/Ticket/Details.cshtml")]
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
#nullable restore
#line 1 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
using BugTracker.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85c35b3cf3034a5c0fd390177e0aa143b3dd7032", @"/Views/Ticket/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"415cd50ac37814e1a4fb76bf7d07627084cdfa27", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BugTracker.Models.TicketModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "/Views/Ticket/_TicketPopup.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

    var devFirst = UserManager.FindByIdAsync(Model.AssignedDevId).Result.FirstName;
    var devLast = UserManager.FindByIdAsync(Model.AssignedDevId).Result.LastName;

    var submitterFirst = UserManager.FindByIdAsync(Model.SubmitterId).Result.FirstName;
    var submitterLast = UserManager.FindByIdAsync(Model.SubmitterId).Result.LastName;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""card m-3 col-6"">
        <div class=""card-header row bg-info"">
            <div class=""col-6"">
                <h5 class=""font-weight-bold font-italic"">Ticket Details</h5>
                <p class=""m-0"">All you need to know about this ticket</p>
            </div>
");
#nullable restore
#line 25 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
             if (User.IsInRole("Admin")||User.IsInRole("Demo Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row col-4\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85c35b3cf3034a5c0fd390177e0aa143b3dd70324996", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <a");
            BeginWriteAttribute("id", " id=\"", 1138, "\"", 1152, 1);
#nullable restore
#line 29 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
WriteAttributeValue("", 1143, Model.Id, 1143, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"updateTicketBtn btn\">Edit</a>\r\n                </div>\r\n");
#nullable restore
#line 31 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n        <div class=\"card-body\" id=\"ticketCard\">\r\n            <div class=\"row\">\r\n                <div class=\"col-6\">\r\n                    <h5 class=\"font-weight-bold font-italic\">Title</h5>\r\n                    <p class=\"ticketTitle\">");
#nullable restore
#line 38 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                      Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"col-6 \">\r\n                    <h5 class=\"font-weight-bold font-italic\">Description</h5>\r\n                    <p class=\"ticketDescription\">");
#nullable restore
#line 42 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                            Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <hr />
            <div class=""row"">
                <div class=""col-6"">
                    <h5 class=""font-weight-bold font-italic"">Status</h5>
                    <p class=""ticketStatus"">");
#nullable restore
#line 49 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                       Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"col-6 \">\r\n                    <h5 class=\"font-weight-bold font-italic\">Type</h5>\r\n                    <p class=\"ticketType\">");
#nullable restore
#line 53 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                     Write(Model.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <hr />
            <div class=""row"">
                <div class=""col-6"">
                    <h5 class=""font-weight-bold font-italic"">Assigned To</h5>
                    <p class=""ticketDev"">");
#nullable restore
#line 60 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                    Write(devFirst);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 60 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                              Write(devLast);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"col-6 \">\r\n                    <h5 class=\"font-weight-bold font-italic\">Priority</h5>\r\n                    <p class=\"ticketPriority\">");
#nullable restore
#line 64 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                         Write(Model.Priority);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <hr />
            <div class=""row"">
                <div class=""col-6"">
                    <h5 class=""font-weight-bold font-italic"">Created</h5>
                    <p class=""ticketCreated"">");
#nullable restore
#line 71 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                        Write(Model.Created);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"col-6 \">\r\n                    <h5 class=\"font-weight-bold font-italic\">Submitted By</h5>\r\n                    <p class=\"ticketSubmitter\">");
#nullable restore
#line 75 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                          Write(submitterFirst);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 75 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                                          Write(submitterLast);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <hr />
        </div>
    </div>

    <div class=""col-5 m-3 ml-4 overflow-auto"" id=""commentDiv"" style=""max-height:550px"">
        <h5 class=""mt-4"">Comments</h5>
        <div class=""input-group mb-3"">
            <input type=""text"" class=""form-control form-control-lg"" id=""commentText"" placeholder=""Leave a comment here"" aria-label=""Comment"" aria-describedby=""button-addon2"">
            <button class=""btn btn-outline-secondary commentBtn"" type=""button""");
            BeginWriteAttribute("id", " id=\"", 3671, "\"", 3685, 1);
#nullable restore
#line 86 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
WriteAttributeValue("", 3676, Model.Id, 3676, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Button</button>\r\n        </div>\r\n");
#nullable restore
#line 88 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
         if(Model.Comments!=null)
        {
            foreach(var comment in Model.Comments)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"m-3 mt-4\">\r\n                        <h5 class=\"font-weight-bold\">");
#nullable restore
#line 93 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                                Write(UserManager.FindByIdAsync(comment.UserId).Result.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 93 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                                                                                            Write(UserManager.FindByIdAsync(comment.UserId).Result.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <small class=\"text-muted\">");
#nullable restore
#line 94 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                                 Write(comment.Date.ToString("dddd, dd MMMM yyyy H:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                        </h5>\r\n                        <p>");
#nullable restore
#line 96 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                      Write(comment.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <hr />\r\n                    </div>\r\n");
#nullable restore
#line 99 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 104 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
         if (Model.Status == TicketModel.StatusType.Finished)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1 class=\"m-4\"><i class=\"fas fa-check-circle\"></i><strong>Finished: </strong>");
#nullable restore
#line 106 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
                                                                                     Write(Model.Finished);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 107 "C:\Programowanie\C#\BugTracker\Views\Ticket\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BugTracker.Models.TicketModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
