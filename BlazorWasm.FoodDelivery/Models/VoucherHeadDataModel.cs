namespace BlazorWasm.FoodDelivery.Models;

public class VoucherHeadDataModel
{
    public Guid SaleVoucherHeadId { get; set; }
    public Guid SaleVoucherNo { get; set; }
    public int SaleTotalAmount { get; set; }
    public DateTime SaleDate { get; set; }
}