namespace BlazorWasm.FoodDelivery.Models
{
    public class FoodPaginationResponseModel
    {
        public List<FoodModel> FoodList { get; set; } = new List<FoodModel>();
        public int TotalPageNo { get; set; }
    }
}
