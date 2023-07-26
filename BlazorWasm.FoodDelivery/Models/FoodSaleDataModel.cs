namespace BlazorWasm.FoodDelivery.Models;

public class FoodSaleDataModel
{
    public Guid SaleId { get; set; }
    public string FoodName { get; set; }
    public decimal FoodPrice { get; set; }
    public decimal Price { get; set; }
    public string FoodPhoto { get; set; }
    public int Qty { get; set; }
}