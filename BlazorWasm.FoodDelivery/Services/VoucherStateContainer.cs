namespace BlazorWasm.FoodDelivery.Services;

public class VoucherStateContainer
{
    private string? savedString;

    public string Property
    {
        get => savedString ?? "0";
        set
        {
            savedString = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}