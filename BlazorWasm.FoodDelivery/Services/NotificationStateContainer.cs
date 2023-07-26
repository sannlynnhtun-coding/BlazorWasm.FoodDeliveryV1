namespace BlazorWasm.FoodDelivery.Services
{
    public class NotificationStateContainer
    {
        private string? _count;

        public string Count
        {
            get => _count ?? "0";
            set
            {
                _count = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}