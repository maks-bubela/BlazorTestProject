#pragma checksum "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f45fa14450ce0e196fd4623feb3741494d9cddc"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorTestProject.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using BlazorTestProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using BlazorTestProject.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
using BlazorTestProject.Models.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
using System.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
using BlazorTestProject.Providers;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/signin")]
    public partial class SignIn : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Sign In</h3>\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 9 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
                 userLogin

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 9 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
                                           UserLogin

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(4, "class", "card card-body bg-light mt-5");
            __builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(7);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(8, "\r\n    ");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "form-group row");
                __builder2.AddMarkupContent(11, "\r\n        ");
                __builder2.AddMarkupContent(12, "<label for=\"username\" class=\"col-md-2 col-form-label\">Username:</label>\r\n        ");
                __builder2.OpenElement(13, "div");
                __builder2.AddAttribute(14, "class", "col-md-10");
                __builder2.AddMarkupContent(15, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(16);
                __builder2.AddAttribute(17, "id", "username");
                __builder2.AddAttribute(18, "class", "form-control");
                __builder2.AddAttribute(19, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
                                                                       userLogin.Username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userLogin.Username = __value, userLogin.Username))));
                __builder2.AddAttribute(21, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userLogin.Username));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(22, "\r\n            ");
                __Blazor.BlazorTestProject.Pages.SignIn.TypeInference.CreateValidationMessage_0(__builder2, 23, 24, 
#nullable restore
#line 15 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
                                      () => userLogin.Username

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(25, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(26, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(27, "\r\n    ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "class", "form-group row");
                __builder2.AddMarkupContent(30, "\r\n        ");
                __builder2.AddMarkupContent(31, "<label for=\"password\" class=\"col-md-2 col-form-label\">Password:</label>\r\n        ");
                __builder2.OpenElement(32, "div");
                __builder2.AddAttribute(33, "class", "col-md-10");
                __builder2.AddMarkupContent(34, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(35);
                __builder2.AddAttribute(36, "type", "password");
                __builder2.AddAttribute(37, "id", "password");
                __builder2.AddAttribute(38, "class", "form-control");
                __builder2.AddAttribute(39, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 21 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
                                                                                       userLogin.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userLogin.Password = __value, userLogin.Password))));
                __builder2.AddAttribute(41, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userLogin.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(42, "\r\n            ");
                __Blazor.BlazorTestProject.Pages.SignIn.TypeInference.CreateValidationMessage_1(__builder2, 43, 44, 
#nullable restore
#line 22 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
                                      () => userLogin.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(45, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(46, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(47, "\r\n    ");
                __builder2.OpenElement(48, "label");
                __builder2.AddContent(49, 
#nullable restore
#line 25 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
            errorMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(50, "\r\n    ");
                __builder2.AddMarkupContent(51, "<div class=\"col-md-12 text-right\">\r\n        <button type=\"submit\" class=\"btn btn-success\">Create</button>\r\n    </div>\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
       
    private UserLoginModel userLogin = new UserLoginModel();
    private static string errorMessage = "";
    private const string ErrorMessage = "Wrong password or username";
    protected override async Task OnInitializedAsync()
    {
        errorMessage = "";
        StateHasChanged();

    }
    private async Task UserLogin()
    {
        var response = await authStateProvider.Login(userLogin);
        if (response.StatusCode == HttpStatusCode.Created)
            NavigationManager.NavigateTo($"/");
        errorMessage = ErrorMessage;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthStateProvider authStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
namespace __Blazor.BlazorTestProject.Pages.SignIn
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
