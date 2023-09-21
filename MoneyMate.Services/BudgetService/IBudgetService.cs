using MoneyMate.Data.Entities;
using MoneyMate.Models.Budget;
using MoneyMate.Models.DataPoints;

namespace MoneyMate.Services.BudgetService;

public interface IBudgetService
{

    Task<List<ExpenseCategory>> GetAllExpenseCategories();

    Task<List<CategoryTotal>> GetCategoryTotals();
}

