using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Services;

public interface IDbService
{
    Task<List<FoodSaleDataModel>> GetFoodsList();
    Task SetFoods(FoodSaleDataModel item);
}