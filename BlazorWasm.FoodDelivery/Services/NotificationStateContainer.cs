namespace BlazorWasm.FoodDelivery.Services
{
    public class NotificationStateContainer
    {
        private string? _enable;

        public string Property
        {
            get => _enable ?? "0";
            set
            {
                _enable = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}