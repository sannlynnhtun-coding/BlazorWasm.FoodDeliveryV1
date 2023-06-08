using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Services;

public class VoucherStateContainer
{
    private EnumCartType? savedString;

    public EnumCartType Property
    {
        get => savedString ?? EnumCartType.Disable;
        set
        {
            savedString = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}