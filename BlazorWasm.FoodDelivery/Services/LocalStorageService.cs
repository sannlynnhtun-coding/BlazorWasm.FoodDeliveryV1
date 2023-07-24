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

    public async Task ItemIncrement(FoodSaleDataModel item)
    {
        var lst = await GetFoodsList();
        var existFood = lst.FirstOrDefault(x => x.FoodName == item.FoodName);
        existFood.Qty += 1;
        existFood.FoodPrice = item.Price * existFood.Qty;
        var index = lst.FindIndex(x => x.FoodName == item.FoodName);
        lst[index] = existFood;
        await _localStorageService.SetItemAsync("FoodSale", lst);
    }

    public async Task ItemIncrement(FoodModel item)
    {
        var lst = await GetFoodsList();
        var existFood = lst.FirstOrDefault(x => x.FoodName == item.FoodName);
        if (existFood is null)
        {
            existFood = new FoodSaleDataModel()
            {
                Price = item.FoodPrice,
                Qty = 1,
                FoodName = item.FoodName,
                FoodPhoto = $"assets/img/food/{item.FoodId}.jpg",
            };
        }
        else
        {
            existFood.Qty += 1;
        }

        existFood.FoodPrice = existFood.Price * existFood.Qty;
        var index = lst.FindIndex(x => x.FoodName == item.FoodName);
        if (index == -1)
        {
            lst.Add(existFood);
        }
        else
        {
            lst[index] = existFood;
        }

        await _localStorageService.SetItemAsync("FoodSale", lst);
    }

    public async Task ItemDecreasement(FoodSaleDataModel item)
    {
        var lst = await GetFoodsList();
        var existFood = lst.FirstOrDefault(x => x.FoodName == item.FoodName);
        var index = lst.FindIndex(x => x.FoodName == item.FoodName);
        existFood.Qty -= 1;
        if (existFood.Qty != 0)
        {
            existFood.FoodPrice = item.Price * existFood.Qty;
            lst[index] = existFood;
            await _localStorageService.SetItemAsync("FoodSale", lst);
        }
        else
        {
            lst.RemoveAt(index);
            await _localStorageService.SetItemAsync("FoodSale", lst);
        }
    }

    public async Task RemoveItem(FoodSaleDataModel item)
    {
        var lst = await GetFoodsList();
        var removeItem = lst.FirstOrDefault(x => x.FoodName == item.FoodName);
        var index = lst.FindIndex(x => x.FoodName == item.FoodName);
        lst.RemoveAt(index);
        await _localStorageService.SetItemAsync("FoodSale", lst);
    }

    public async Task<List<CartDetailDataModel>> GetCartDeatil()
    {
        var lst = await _localStorageService.GetItemAsync<List<CartDetailDataModel>>("CartDetail");
        lst ??= new();
        return lst;
    }

    public async Task<List<CartHeadDataModel>> GetCartHead()
    {
        var lst = await _localStorageService.GetItemAsync<List<CartHeadDataModel>>("CartHead");
        lst ??= new();
        return lst;
    }

    public async Task SetCartDeatil(CartDetailDataModel item)
    {
        var lst = await _localStorageService.GetItemAsync<List<CartDetailDataModel>>("CartDetail");
        lst ??= new();
        lst.Add(item);
        await _localStorageService.SetItemAsync("CartDetail", lst);
    }

    public async Task SetCartHead(CartHeadDataModel item)
    {
        var lst = await _localStorageService.GetItemAsync<List<CartHeadDataModel>>("CartHead");
        lst ??= new();
        lst.Add(item);
        await _localStorageService.SetItemAsync("CartHead", lst);
    }

    public async Task<ReceiptResponseModel> CheckOut()
    {
        ReceiptResponseModel model = new ReceiptResponseModel();
        Guid cartHeadId = Guid.NewGuid();

        CartHeadDataModel head = new();
        List<CartDetailDataModel> details = new();

        var lstFood = await GetFoodsList();
        if (lstFood != null && lstFood.Count() > 0)
        {
            foreach (var item in lstFood)
            {
                CartDetailDataModel detailModel = new();
                detailModel.CartDetailId = Guid.NewGuid();
                detailModel.CartHeadId = cartHeadId;
                detailModel.FoodName = item.FoodName;
                detailModel.FoodPrice = item.FoodPrice;
                detailModel.Qty = item.Qty;
                detailModel.DetailDate = DateTime.Now;
                // await SetCartDeatil(detailModel);
                details.Add(detailModel);
            }

            head.CartHeadId = cartHeadId;
            head.CartNo = Guid.NewGuid();
            head.TotalAmount = lstFood.Select(x => x.FoodPrice).Sum();
            head.HeadDate = DateTime.Now;
            // await SetCartHead(headModel);
            await _localStorageService.RemoveItemAsync("FoodSale");
        }

        model.Head = head;
        model.Details = details;

        return model;
    }
}