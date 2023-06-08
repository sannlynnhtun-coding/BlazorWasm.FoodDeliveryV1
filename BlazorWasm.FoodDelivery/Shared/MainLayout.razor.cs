namespace BlazorWasm.FoodDelivery.Shared;

public partial class MainLayout
{
    protected override void OnInitialized()
    {
        StateContainer.OnChange += StateHasChanged;
    }
    
    public void Dispose()
    {
        StateContainer.OnChange -= StateHasChanged;
    }
}