#pragma checksum "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_Details), @"mvc.1.0.view", @"/Views/Events/Details.cshtml")]
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
#line 1 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\_ViewImports.cshtml"
using JournalControlWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\_ViewImports.cshtml"
using JournalControlWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffc0ab2e765cc1014b4d24dda32e0d29e50e554e", @"/Views/Events/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c15d8571a191ab446c56ab70c84e53fd9d20f6d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Events_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JournalControlWebApp.Models.dbo.Event>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Выполнено", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Отменено", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Report", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Event</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Check.FailCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.Check.FailCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Check.CheckDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 23 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
              string checkDateStr = Model.Check.CheckDate.ToShortDateString();

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 24 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => checkDateStr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Check.Sector.Subunit.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.Check.Sector.Subunit.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Check.Sector.SectorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.Check.Sector.SectorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Check.RegWorkerNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 42 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
               string regFio = Model.Check.RegWorkerNavigation.Family + " " + Model.Check.RegWorkerNavigation.Name[0] + "." + Model.Check.RegWorkerNavigation.Otch[0] + ".";

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 43 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => regFio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 46 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Check.TdKd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 49 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.Check.TdKd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 52 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Check.ControlIndicator));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 55 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.Check.FailDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 58 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FailReason));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 61 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.FailReason));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 64 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 67 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 70 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ResponsWorker));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 73 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.ResponsWorker));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 76 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DueDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 79 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
               string dueDateStr = Model.DueDate.ToShortDateString();

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 80 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => dueDateStr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 83 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DevelopDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 86 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.DevelopDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 89 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DeveloperNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 92 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
               string developerFio = Model.DeveloperNavigation.Family + " " + Model.DeveloperNavigation.Name[0] + "." + Model.DeveloperNavigation.Otch[0] + ".";

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 93 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => developerFio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 96 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DeveloperNavigation.Sector.Subunit.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 99 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
       Write(Html.DisplayFor(model => model.DeveloperNavigation.Sector.Subunit.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n");
#nullable restore
#line 101 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
         if (!String.IsNullOrEmpty(Model.Report))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 104 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Report));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 107 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayFor(model => model.Report));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 110 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.ProofInf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 113 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayFor(model => model.ProofInf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 116 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.ReportDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 119 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayFor(model => model.ReportDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 122 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.ReportWorkerNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 125 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
                   string reportFio = Model.ReportWorkerNavigation.Family + " " + Model.ReportWorkerNavigation.Name[0] + "." + Model.ReportWorkerNavigation.Otch[0] + ".";

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
#nullable restore
#line 126 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayFor(model => reportFio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 129 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.ReportWorkerNavigation.Sector.Subunit.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 132 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
           Write(Html.DisplayFor(model => model.ReportWorkerNavigation.Sector.Subunit.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n");
#nullable restore
#line 134 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n");
#nullable restore
#line 136 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
     if (String.IsNullOrEmpty(Model.Report) && User.IsInRole("REPORT") && (ViewBag.Worker.Id == Model.DeveloperNavigation.Id || ViewBag.Worker.Sector.SubunitId == Model.DeveloperNavigation.Sector.SubunitId && User.IsInRole("SUBSHOW")))
    {

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e23368", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e23631", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 139 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Report);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <select name=\"Report\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e25278", async() => {
                    WriteLiteral("-");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e26505", async() => {
                    WriteLiteral("Выполнено");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e27740", async() => {
                    WriteLiteral("Отменено");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </select>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e28987", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 145 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProofInf);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e30600", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 146 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProofInf);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <input type=\"submit\" class=\"btn btn-primary\" value=\"Сохранить отчет\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 138 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
                            WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 149 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e34917", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 153 "D:\Users\pasty\Desktop\Универ\Диплом\JournalControlWebApp\JournalControlWebApp\Views\Events\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffc0ab2e765cc1014b4d24dda32e0d29e50e554e37088", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JournalControlWebApp.Models.dbo.Event> Html { get; private set; }
    }
}
#pragma warning restore 1591