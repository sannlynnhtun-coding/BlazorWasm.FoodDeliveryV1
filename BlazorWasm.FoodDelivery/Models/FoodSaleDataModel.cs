namespace BlazorWasm.FoodDelivery.Models;

public class FoodSaleDataModel
{
    public Guid SaleId { get; set; }
    public string FoodName { get; set; }
    public decimal FoodPrice { get; set; }
    public int Qty { get; set; }
    public string img { get; set; }
}