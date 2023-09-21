using System.ComponentModel.DataAnnotations;

namespace MoneyMate.Data.Entities;

public class ExpenseCategory
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public double TotalExpenses { get; set; }
}

