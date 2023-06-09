namespace BlazorWasm.FoodDelivery.Models;

public class CartDetailDataModel
{
    public Guid CartDetailId { get; set; }
    public Guid CartHeadId { get; set; }
    public string FoodName { get; set; }
    public decimal FoodPrice { get; set; }
    public int Qty { get; set; }
    public DateTime DetailDate { get; set; }
}