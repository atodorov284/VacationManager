#pragma checksum "C:\Users\User\Documents\VacationManager\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f863fd54a0f1c5b14ef11398ca902ae235a88cd5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
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
#line 1 "C:\Users\User\Documents\VacationManager\Views\_ViewImports.cshtml"
using VacationManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Documents\VacationManager\Views\_ViewImports.cshtml"
using VacationManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f863fd54a0f1c5b14ef11398ca902ae235a88cd5", @"/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38cb6b5391271c4377a73c651ce73fff7290151e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VacationManager.ViewModels.Home.UserCreateVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Home/Login"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Documents\VacationManager\Views\Home\Login.cshtml"
  
    this.Layout = "/Views/Shared/_Layout.cshtml";
    ViewData["title"] = "LOGIN";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<fieldset>\n    <legend>LOGIN</legend>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f863fd54a0f1c5b14ef11398ca902ae235a88cd54135", async() => {
                WriteLiteral("\n        <div class=\"grid\">\n            <div class=\"row\">\n                <div class=\"col-1\">");
#nullable restore
#line 12 "C:\Users\User\Documents\VacationManager\Views\Home\Login.cshtml"
                              Write(Html.LabelFor(m => m.Username));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n                <div class=\"col-2\">\n                    ");
#nullable restore
#line 14 "C:\Users\User\Documents\VacationManager\Views\Home\Login.cshtml"
               Write(Html.TextBoxFor(m => m.Username));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n                <div class=\"col-2\">\n                    ");
#nullable restore
#line 17 "C:\Users\User\Documents\VacationManager\Views\Home\Login.cshtml"
               Write(Html.ValidationMessageFor(m => m.Username));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n            </div>\n            <div class=\"row\">\n                <div class=\"col-1\">");
#nullable restore
#line 21 "C:\Users\User\Documents\VacationManager\Views\Home\Login.cshtml"
                              Write(Html.LabelFor(m => m.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n                <div class=\"col-2\">\n                    ");
#nullable restore
#line 23 "C:\Users\User\Documents\VacationManager\Views\Home\Login.cshtml"
               Write(Html.PasswordFor(m => m.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n                <div class=\"col-2\">\n                    ");
#nullable restore
#line 26 "C:\Users\User\Documents\VacationManager\Views\Home\Login.cshtml"
               Write(Html.ValidationMessageFor(m => m.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n            </div>\n            <div class=\"row\">\n                <div class=\"col-1\"></div>\n                <div class=\"col-2\">\n                    ");
#nullable restore
#line 32 "C:\Users\User\Documents\VacationManager\Views\Home\Login.cshtml"
               Write(Html.ValidationMessage("authError", new { @style = "right" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>
            <div class=""row"">
                <div class=""col-1""></div>
                <div class=""col-2"">
                    <input type=""submit"" class=""right"" value=""Login"" />
                </div>
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</fieldset>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VacationManager.ViewModels.Home.UserCreateVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
