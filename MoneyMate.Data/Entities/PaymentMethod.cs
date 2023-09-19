using System.ComponentModel.DataAnnotations;

namespace MoneyMate.Data.Entities;

public class PaymentMethod
{
    [Key]
    public int PaymentId { get; set; }

    public string PaymentName { get; set; }
}