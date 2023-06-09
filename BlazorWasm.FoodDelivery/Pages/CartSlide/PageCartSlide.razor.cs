using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Pages.CartSlide;

public partial class PageCartSlide
{
    private List<FoodSaleDataModel> LstFood { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        LstFood = await DbService.GetFoodsList();
        VoucherStateContainer.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        VoucherStateContainer.OnChange -= StateHasChanged;
    }

    async Task Close()
    {
        LstFood = await DbService.GetFoodsList();
        VoucherStateContainer.Property = EnumCartType.Disable;
    }

    async Task ItemIncreasement(FoodSaleDataModel item)
    {
        await DbService.ItemIncrement(item);
        VoucherStateContainer.FoodLst = await DbService.GetFoodsList();
    }

    async Task ItemDecreasement(FoodSaleDataModel item)
    {
        await DbService.ItemDecreasement(item);
        VoucherStateContainer.FoodLst = await DbService.GetFoodsList();
        StateContainer.Property = VoucherStateContainer.FoodLst != null
            ? VoucherStateContainer.FoodLst
                .Select(x => x.Qty)
                .Sum()
                .ToString()
            : "0";
    }

    async Task RemoveItem(FoodSaleDataModel item)
    {
        await DbService.RemoveItem(item);
        VoucherStateContainer.FoodLst = await DbService.GetFoodsList();
        StateContainer.Property = VoucherStateContainer.FoodLst != null
            ? VoucherStateContainer.FoodLst
                .Select(x => x.Qty)
                .Sum()
                .ToString()
            : "0";
    }

    void Checkout()
    {
        VoucherStateContainer.Property = EnumCartType.Disable;
        NavigationManager.NavigateTo("checkout");
    }
}