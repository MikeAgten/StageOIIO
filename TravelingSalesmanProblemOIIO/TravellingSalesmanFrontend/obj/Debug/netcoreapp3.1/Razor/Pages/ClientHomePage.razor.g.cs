#pragma checksum "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\ClientHomePage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9ba831bdf367ec7fbcd7f503b59f3d57a425fac"
// <auto-generated/>
#pragma warning disable 1591
namespace TravellingSalesmanFrontend.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\_Imports.razor"
using TravellingSalesmanFrontend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\_Imports.razor"
using TravellingSalesmanFrontend.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/clienthome/{ContactId}")]
    public partial class ClientHomePage : ClientHomePageBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, "Welkom ");
            __builder.AddContent(2, 
#nullable restore
#line 4 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\ClientHomePage.razor"
            Contact.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(3, "\r\n");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "btn-danger");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\ClientHomePage.razor"
                                     (() => Logout())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(7, "Logout");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n");
            __builder.AddMarkupContent(9, "<button><img src=\"~/Resources/plusPng.png\" width=\"500\" height=\"500\"></button>");
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\ClientHomePage.razor"
           
    public void Logout()
    {
        NavigationManager.NavigateTo("/", true);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
