using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Services;

public interface IDbService
{
    Task<List<FoodSaleDataModel>> GetFoodsList();
    Task SetFoods(FoodSaleDataModel item);
    Task ItemIncrement(FoodSaleDataModel item);
    Task ItemIncrement(FoodModel item);
    Task ItemDecreasement(FoodSaleDataModel item);
    Task RemoveItem(FoodSaleDataModel item);
    Task<ReceiptResponseModel> CheckOut();
}