using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Services;

public class VoucherStateContainer
{
    private EnumCartType? savedString;
    private List<FoodSaleDataModel> saveFoodLst;
    public EnumCartType Property
    {
        get => savedString ?? EnumCartType.Disable;
        set
        {
            savedString = value;
            NotifyStateChanged();
        }
    }
    public List<FoodSaleDataModel> FoodList
    {
        get => saveFoodLst ?? new();
        set
        {
            saveFoodLst = value;
            NotifyStateChanged();
        }
    }
    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}