using BlazorWasm.FoodDelivery.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.FoodDelivery.Pages.PopularFood;

public partial class PagePopularFood
{
    private List<FoodCategoryModel> FoodCategoryList { get; set; } = new();
    private List<FoodModel> FoodList { get; set; } = new();
    private FoodPaginationResponseModel? _foodPagination;
    private int _categoryId = 0;
    private string? _keyword = "";

    protected override void OnInitialized()
    {
        FoodCategoryList = FoodService.FoodCategoryList;
        FindFoodByCategory();
    }

    void FindFoodByCategory(int categoryId = 0)
    {
        _categoryId = categoryId;
        _foodPagination = FoodService.GetFoods(categoryId);
        StateHasChanged();
    }

    async Task AddToCard(FoodModel item)
    {
        // FoodSaleDataModel model = new()
        // {
        //     SaleId = Guid.NewGuid(),
        //     FoodName = item.FoodName,
        //     Price = item.FoodPrice,
        //     FoodPhoto = $"assets/img/food/{item.FoodId}.jpg",
        //     Qty = 1
        // };
        // await DbService.SetFoods(model);
        // var result = await DbService.GetFoodsList();
        // StateContainer.Count = result.Select(x=> x.Qty).Sum().ToString();
        // model = new();
        
        await DbService.ItemIncrement(item);
        var result = await DbService.GetFoodsList();
        StateContainer.Count = result.Select(x=> x.Qty).Sum().ToString();
    }

    void Search(ChangeEventArgs e)
    {
        _keyword = e.Value?.ToString();
    }

    void PageChanged(int pageNo)
    {
        _foodPagination = FoodService.GetFoods(_categoryId = 0, pageNo);
    }
}