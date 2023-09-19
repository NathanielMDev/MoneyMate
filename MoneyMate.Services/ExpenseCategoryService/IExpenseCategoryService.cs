using MoneyMate.Data.Entities;
using MoneyMate.Models.ExpenseCategory;

namespace MoneyMate.Services.ExpenseCategoryService;

public interface IExpenseCategoryService
{
    Task<List<ExpenseCategory>> GetAllExpenseCategories();

    Task<bool> CreateExpenseCategory(ExpenseCategoryCreate model);

    Task<ExpenseCategoryDetail> GetExpenseCategoryById(int id);

    Task<bool> DeleteExpenseCategory(int id);
}
