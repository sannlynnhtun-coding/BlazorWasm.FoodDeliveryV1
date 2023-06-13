namespace BlazorWasm.FoodDelivery.Models;

public class CartHeadDataModel
{
    public Guid CartHeadId { get; set; }
    public Guid CartNo { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime HeadDate { get; set; }
}

public class ReceiptResponseModel
{
    public CartHeadDataModel Head { get; set; }
    public List<CartDetailDataModel> Details { get; set; }
}