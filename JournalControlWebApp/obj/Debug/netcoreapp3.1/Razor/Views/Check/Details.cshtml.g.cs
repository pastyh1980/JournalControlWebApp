#pragma checksum "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a5cde7a3c3ef8bebe8c3e544413edd0346ea459"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Check_Details), @"mvc.1.0.view", @"/Views/Check/Details.cshtml")]
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
#line 1 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\_ViewImports.cshtml"
using JournalControlWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\_ViewImports.cshtml"
using JournalControlWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a5cde7a3c3ef8bebe8c3e544413edd0346ea459", @"/Views/Check/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c15d8571a191ab446c56ab70c84e53fd9d20f6d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Check_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JournalControlWebApp.Models.dbo.Check>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Subshow", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Deactivate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Incorrect", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Check</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FailCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => model.FailCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RegDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => model.RegDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Проверяющее подразделение\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => model.RegWorkerNavigation.Sector.Subunit.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RegWorkerNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n");
#nullable restore
#line 34 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
           string regFio = Model.RegWorkerNavigation.Family + " " + Model.RegWorkerNavigation.Name[0] + "." + Model.RegWorkerNavigation.Otch[0] + ".";

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => regFio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n");
#nullable restore
#line 38 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
           string dateStr = Model.CheckDate.ToShortDateString();

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 40 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CheckDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 43 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => dateStr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Проверяемое подразделение\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 49 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => model.Sector.Subunit.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Проверяемый участок\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 55 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => model.Sector.SectorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 58 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TdKd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 61 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => model.TdKd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 64 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ControlIndicator));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 67 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => model.ControlIndicator));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 70 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FailDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 73 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
       Write(Html.DisplayFor(model => model.FailDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n");
#nullable restore
#line 78 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
 if (Model.Events.Where(e => e.IsCorrect && e.IsActive).Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th>ФИО разработчика</th>
                <th>Причина несоответствия</th>
                <th>Описание мероприятия</th>
                <th>Ответственный</th>
                <th>Срок исполнения</th>
                <th>Отчет</th>
                <th>Подтверждающая информация</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 93 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
             foreach (var ev in Model.Events)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                 if (ev.IsActive && ev.IsCorrect)
                {
                    string FIO = ev.DeveloperNavigation.Family + " " + ev.DeveloperNavigation.Name[0] + "." + ev.DeveloperNavigation.Otch[0] + ".";
                    string dueStr = ev.DueDate.ToShortDateString();

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 101 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(FIO);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 104 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(ev.FailReason);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 107 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(ev.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 110 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(ev.ResponsWorker);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 113 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(dueStr);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 116 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(ev.Report);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 119 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(ev.ProofInf);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 122 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 122 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 126 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 128 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
 if (Model.Shows.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th>Дата ознакомления</th>
                <th>ФИО сотрудника</th>
                <th>Должность</th>
                <th>Подразделение</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 140 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
             foreach (var sh in Model.Shows)
            {
                string FIO = sh.Worker.Family + " " + sh.Worker.Name[0] + "." + sh.Worker.Otch[0] + ".";
                string showDateStr = sh.Date.ToShortDateString();

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 146 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(showDateStr);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 149 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(FIO);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 152 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(sh.Worker.Post);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 155 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                   Write(sh.Worker.Sector.Subunit.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 158 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 161 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 163 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
 if (User.IsInRole("SUBSHOW") && (ViewBag.Worker.SectorId == Model.SectorId
|| ViewBag.Worker.Sector.SubunitId == Model.Sector.SubunitId && ViewBag.Worker.Sector.IsMain)
&& !Model.Shows.Any(s => s.WorkerId == ViewBag.Worker.Id))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a5cde7a3c3ef8bebe8c3e544413edd0346ea45919253", async() => {
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Ознакомиться\" class=\"btn btn-primary\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-checkId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 167 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                                                    WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["checkId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-checkId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["checkId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 170 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 172 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
 if (User.IsInRole("SUBSHOW") && Model.Shows.Count > 0
  && (ViewBag.Worker.SectorId == Model.SectorId || ViewBag.Worker.Sector.SubunitId == Model.Sector.SubunitId && ViewBag.Worker.Sector.IsMain)
  && (!Model.IsFail || Model.Events.Where(e => e.IsCorrect).Count() > 0 && !Model.Events.Any(e => e.IsActive && e.IsCorrect)))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a5cde7a3c3ef8bebe8c3e544413edd0346ea45922732", async() => {
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Зарегистрировать устранение несоответствия\" class=\"btn btn-primary\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 176 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                                                  WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 179 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 181 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
 if (Model.Shows.Count == 0 && Model.Events.Count == 0
   && (ViewBag.Worker.Id == Model.RegWorker 
    || (User.IsInRole("SUBSHOW") && (ViewBag.Worker.SectorId == Model.RegWorkerNavigation.SectorId 
    || ViewBag.Worker.Sector.SubunitId == Model.RegWorkerNavigation.Sector.SubunitId && ViewBag.Worker.Sector.IsMain))))
{

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a5cde7a3c3ef8bebe8c3e544413edd0346ea45926182", async() => {
                WriteLiteral("\r\n    <input type=\"submit\" value=\"Зарегистрировать ошибку в несоответствии\" class=\"btn btn-primary\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 186 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
                                             WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 189 "E:\VSprojects\JournalControlWebApp\JournalControlWebApp\Views\Check\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a5cde7a3c3ef8bebe8c3e544413edd0346ea45929137", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JournalControlWebApp.Models.dbo.Check> Html { get; private set; }
    }
}
#pragma warning restore 1591
