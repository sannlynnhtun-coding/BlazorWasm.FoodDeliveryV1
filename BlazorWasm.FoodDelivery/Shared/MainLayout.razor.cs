using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Shared;

public partial class MainLayout
{
    private EnumPageType _pageType = EnumPageType.Home; 
    protected override void OnInitialized()
    {
        StateContainer.OnChange += StateHasChanged;
    }
    
    public void Dispose()
    {
        StateContainer.OnChange -= StateHasChanged;
    }

    void GoToPage(EnumPageType pageType)
    {
        _pageType = pageType;
        NavigationManager.NavigateTo(_pageType == EnumPageType.Home ? "" : pageType.ToString());
    }
}