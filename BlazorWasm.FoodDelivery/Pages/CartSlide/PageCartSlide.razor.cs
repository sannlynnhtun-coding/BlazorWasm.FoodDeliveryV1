using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Pages.CartSlide;

public partial class PageCartSlide
{
    private List<FoodSaleDataModel> FoodList { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        FoodList = await DbService.GetFoodsList();
        VoucherStateContainer.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        VoucherStateContainer.OnChange -= StateHasChanged;
    }

    async Task Close()
    {
        FoodList = await DbService.GetFoodsList();
        VoucherStateContainer.Property = EnumCartType.Disable;
    }

    async Task AddItem(FoodSaleDataModel item)
    {
        await DbService.ItemIncrement(item);
        VoucherStateContainer.FoodList = await DbService.GetFoodsList();
    }

    async Task RemoveItem(FoodSaleDataModel item)
    {
        await DbService.ItemDecreasement(item);
        VoucherStateContainer.FoodList = await DbService.GetFoodsList();
        StateContainer.Count = VoucherStateContainer.FoodList != null
            ? VoucherStateContainer.FoodList
                .Select(x => x.Qty)
                .Sum()
                .ToString()
            : "0";
    }

    async Task Remove(FoodSaleDataModel item)
    {
        await DbService.RemoveItem(item);
        VoucherStateContainer.FoodList = await DbService.GetFoodsList();
        StateContainer.Count = VoucherStateContainer.FoodList != null
            ? VoucherStateContainer.FoodList
                .Select(x => x.Qty)
                .Sum()
                .ToString()
            : "0";
    }

    async Task Checkout()
    {
        VoucherStateContainer.FoodList = await DbService.GetFoodsList();
        StateContainer.Count = VoucherStateContainer.FoodList != null
            ? VoucherStateContainer.FoodList
                .Select(x => x.Qty)
                .Sum()
                .ToString()
            : "0";
        VoucherStateContainer.Property = EnumCartType.Disable;
        NavigationManager.NavigateTo("checkout");
    }
}