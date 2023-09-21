using Microsoft.EntityFrameworkCore;
using MoneyMate.Data.DataEntities;
using MoneyMate.Data.Entities;
using MoneyMate.Models.Budget;

namespace MoneyMate.Services.BudgetService;

public class BudgetService : IBudgetService
{
    private readonly ApplicationDbContext _context;

    public BudgetService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ExpenseCategory>> GetAllExpenseCategories()
    {
        return await _context.ExpenseCategories.ToListAsync();
    }

    public async Task<List<CategoryTotal>> GetCategoryTotals()
    {
        var categoryTotals = await _context.Expenses
            .GroupBy(e => new { e.Category.CategoryName, e.CategoryId })
            .Select(group => new CategoryTotal
            {
                CategoryName = group.Key.CategoryName,
                CategoryId = group.Key.CategoryId,
                TotalAmount = group.Sum(e => e.Amount),
                ExpenseCount = 0
            })
            .ToListAsync();

        
        foreach (var categoryTotal in categoryTotals)
        {
            categoryTotal.ExpenseCount = GetExpenseCountForCategory(categoryTotal.CategoryId);
        }

        return categoryTotals;
    }

    public int GetExpenseCountForCategory(int categoryId)
    {
        int expenseCount = _context.Expenses
            .Where(e => e.CategoryId == categoryId)
            .Count();

        return expenseCount;
    }

}
