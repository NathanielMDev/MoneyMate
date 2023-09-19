using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyMate.Models.Expense;

public class ExpenseDetail
{
    [Key]
    public int ExpenseId { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public string ExpenseCategory { get; set; }

    public string PaymentMethod { get; set; }

    public string Currency { get; set; }

    public int CategoryId { get; set; }

    public int PaymentId { get; set; }

    public int CurrencyId { get; set; }

}


