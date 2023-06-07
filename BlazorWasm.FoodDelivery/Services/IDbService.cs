using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Services;

public interface IDbService
{
    Task<List<FoodSaleDataModel>> GetFoods();
    Task SetFoods(FoodSaleDataModel item);
}