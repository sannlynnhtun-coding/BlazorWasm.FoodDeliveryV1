using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Pages.Cart;

public partial class PageCart
{
    private List<FoodSaleDataModel> FoodList { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        FoodList = await DbService.GetFoodsList();
    }

    void GoToPage()
    {
        _menuStateContainer.PageType = EnumPageType.Home;
        NavigationManager.NavigateTo("");
    }
}