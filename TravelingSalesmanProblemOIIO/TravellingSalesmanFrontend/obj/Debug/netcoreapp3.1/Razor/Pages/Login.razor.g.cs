#pragma checksum "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4265b561326683f98171159186b1678544ebf6dd"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Login : LoginBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Login page</h1>\r\n");
            __builder.AddMarkupContent(1, "<p>Dit zijn alle contacten</p>\r\n");
#nullable restore
#line 8 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
 if (Contacts == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(2, "    ");
            __builder.AddMarkupContent(3, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 11 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "    ");
            __builder.OpenElement(5, "select");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "option");
            __builder.AddContent(8, "Tenant");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n        ");
            __builder.OpenElement(10, "option");
            __builder.AddContent(11, "Client");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.OpenElement(14, "select");
            __builder.AddAttribute(15, "id", "NameSelection");
            __builder.AddAttribute(16, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 18 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
                                          (() => ChangeCurrentContact(4))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(17, "\r\n");
#nullable restore
#line 19 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
         foreach (var contact in Contacts)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(18, "            ");
            __builder.OpenElement(19, "option");
            __builder.AddContent(20, 
#nullable restore
#line 21 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
                     contact.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(21, " ");
            __builder.AddContent(22, 
#nullable restore
#line 21 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
                                        contact.Surname

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n");
#nullable restore
#line 22 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n    ");
            __builder.OpenElement(26, "button");
            __builder.AddAttribute(27, "class", "btn-danger");
            __builder.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 24 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
                                         (() => LoginButtonClick())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(29, "Login");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n");
#nullable restore
#line 40 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 28 "C:\OIIORepo\StageOIIO\TravelingSalesmanProblemOIIO\TravellingSalesmanFrontend\Pages\Login.razor"
          
        private void LoginButtonClick()
        {
            string url = "/clienthome/" + CurrentContactId;
            NavigationManager.NavigateTo(url, true);
        }

        private void ChangeCurrentContact(int id)
        {
            CurrentContactId = id;
            Console.WriteLine(id);
        }
    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
