// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "C:\WorkSpace\BlazorTestProject\BlazorTestProject\BlazorTestProject\Pages\SignIn.razor"
       
    private UserLoginModel userLogin = new UserLoginModel();
    private static string errorMessage = "";
    private const string ErrorMessage = "Wrong password or username";
    protected override async Task OnInitializedAsync()
    {
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
#pragma warning restore 1591
