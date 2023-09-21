namespace MoneyMate.Models.Budget;

public class CategoryTotal
{
    public string CategoryName { get; set; }

    public int CategoryId { get; set; }

    public double TotalAmount { get; set; }

    public int ExpenseCount { get; set; }

    public double AverageExpense
    {
        get
        {
            if (ExpenseCount > 0)
            {
                return TotalAmount / ExpenseCount;
            }
            return 0;
        }
    }
}


