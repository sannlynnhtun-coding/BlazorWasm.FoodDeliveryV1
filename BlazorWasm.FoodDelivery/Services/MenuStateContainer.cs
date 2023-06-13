using BlazorWasm.FoodDelivery.Models;

namespace BlazorWasm.FoodDelivery.Services;

public class MenuStateContainer
{
    private EnumPageType? pageType;
    public EnumPageType PageType
    {
        get => pageType ?? EnumPageType.Home;
        set
        {
            pageType = value;
            NotifyStateChanged();
        }
    }
    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}