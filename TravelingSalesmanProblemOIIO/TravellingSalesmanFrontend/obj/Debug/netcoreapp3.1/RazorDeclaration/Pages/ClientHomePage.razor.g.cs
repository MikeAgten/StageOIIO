#pragma checksum "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\ClientHomePage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9ba831bdf367ec7fbcd7f503b59f3d57a425fac"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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