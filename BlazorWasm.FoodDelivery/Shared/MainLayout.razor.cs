using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Shared;

public partial class MainLayout
{
    protected override void OnInitialized()
    {
        _notificationStateContainer.OnChange += StateHasChanged;
        _menuStateContainer.OnChange += StateHasChanged;
    }
    
    public void Dispose()
    {
        _notificationStateContainer.OnChange -= StateHasChanged;
        _menuStateContainer.OnChange -= StateHasChanged;
    }

    void GoToPage(EnumPageType pageType)
    {
        _menuStateContainer.PageType = pageType;
        NavigationManager.NavigateTo(_menuStateContainer.PageType == EnumPageType.Home ? "" : pageType.ToString());
    }
}