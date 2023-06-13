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

    async Task AddItem(FoodSaleDataModel item)
    {
        await DbService.ItemIncrement(item);
        VoucherStateContainer.FoodLst = await DbService.GetFoodsList();
    }

    async Task RemoveItem(FoodSaleDataModel item)
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

    async Task Remove(FoodSaleDataModel item)
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

    async Task Checkout()
    {
        await DbService.CheckOut();
        VoucherStateContainer.FoodLst = await DbService.GetFoodsList();
        StateContainer.Property = VoucherStateContainer.FoodLst != null
            ? VoucherStateContainer.FoodLst
                .Select(x => x.Qty)
                .Sum()
                .ToString()
            : "0";
        VoucherStateContainer.Property = EnumCartType.Disable;
        NavigationManager.NavigateTo("checkout");
    }
}