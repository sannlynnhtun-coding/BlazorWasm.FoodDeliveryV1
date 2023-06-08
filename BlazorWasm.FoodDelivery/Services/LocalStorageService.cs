using Blazored.LocalStorage;
using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Services;

public class LocalStorageService : IDbService
{
    private readonly ILocalStorageService _localStorageService;
    private List<FoodSaleDataModel> _list = new();

    public LocalStorageService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<List<FoodSaleDataModel>> GetFoodsList()
    {
        List<FoodSaleDataModel> lst = await _localStorageService.GetItemAsync<List<FoodSaleDataModel>>("FoodSale");
        lst ??= new();
        return lst;
    }

    public async Task SetFoods(FoodSaleDataModel item)
    {
        var lst = await GetFoodsList();
        lst ??= new();
        if (lst == null || lst.Count == 0)
        {
            lst.Add(item);
            await _localStorageService.SetItemAsync("FoodSale", lst);
        }
        else
        {
            var existFood = lst.FirstOrDefault(x => x.FoodName == item.FoodName);
            if (existFood == null)
            {
                lst.Add(item);
                await _localStorageService.SetItemAsync("FoodSale", lst);
            }
            else
            {
                var commonItem = lst
                    .FirstOrDefault(x => x.FoodName == item.FoodName);
                commonItem.Qty += item.Qty;
                var index = lst.FindIndex(x => x.FoodName == item.FoodName);
                lst[index] = commonItem;
                await _localStorageService.SetItemAsync("FoodSale", lst);
            }
        }
    }
}