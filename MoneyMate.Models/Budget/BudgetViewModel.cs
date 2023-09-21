
namespace MoneyMate.Models.Budget;

public class BudgetViewModel
{
    public List<CategoryTotal> CategoryTotals { get; set; }

    public double ExpenseTotal
    {
        get
        {
            double total = 0.0;
            foreach(CategoryTotal item in CategoryTotals)
            {
                total += item.TotalAmount;
            }

            return total;
        }
    }


}

