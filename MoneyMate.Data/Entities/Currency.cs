using System.ComponentModel.DataAnnotations;

namespace MoneyMate.Data.Entities;

public class Currency
{
    [Key]
    public int CurrencyId { get; set; }

    public string Code { get; set; }

    public string CurrencyName { get; set; }
}
