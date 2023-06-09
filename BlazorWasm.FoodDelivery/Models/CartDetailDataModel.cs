namespace BlazorWasm.FoodDelivery.Models;

public class CartDetailDataModel
{
    public Guid SaleVoucherDetailId { get; set; }
    public Guid SaleVoucherHeadId { get; set; }
    public string ProductName { get; set; }
    public int ProductPrice { get; set; }
    public int ProductQty { get; set; }
    public DateTime DetailDate { get; set; }
}