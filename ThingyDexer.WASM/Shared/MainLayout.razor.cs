using BlazorBootstrap;
using Microsoft.AspNetCore.Components.Routing;

namespace ThingyDexer.WASM.Shared
{
    public partial class MainLayout
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private IEnumerable<NavItem> navItems;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private Sidebar? sidebar;
        protected bool ToggleSidebarIcon { get; set; } = true;
        private void ToogleSidebar()
        {
            sidebar?.ToggleSidebar();
            ToggleSidebarIcon = !ToggleSidebarIcon;
            StateHasChanged();
        }
        private async Task<SidebarDataProviderResult> SidebarDataProvider(SidebarDataProviderRequest request)
        {
            navItems ??= GetNavItems();
            return await Task.FromResult(request.ApplyTo(navItems));
        }

        private IEnumerable<NavItem> GetNavItems()
        {
            navItems = new List<NavItem>{
                    new NavItem  {   Id = "1", Href = "/", IconName = IconName.HouseDoorFill, Text = "Home", Match = NavLinkMatch.All},
                    new NavItem { Id = "2", Href = "/CreateCult", IconName = IconName.Dice1, Text = "Create a Cult"},
            };
            return navItems;
        }
    }
}