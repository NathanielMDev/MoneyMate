using MoneyMate.Models.ExpenseCategory;
using Microsoft.EntityFrameworkCore;
using MoneyMate.Data.DataEntities;
using MoneyMate.Data.Entities;

namespace MoneyMate.Services.ExpenseCategoryService;

public class ExpenseCategoryService : IExpenseCategoryService
{
    private readonly ApplicationDbContext _context;

    public ExpenseCategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ExpenseCategory>> GetAllExpenseCategories()
    {
        List<ExpenseCategory> expenseCategories = await _context.ExpenseCategories
            .Select(e => new ExpenseCategory()
            {
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName,
            }).ToListAsync();

        return expenseCategories;
    }

    public async Task<ExpenseCategoryDetail> GetExpenseCategoryById(int id)
    {
        var expenseCategory = await _context.ExpenseCategories.FindAsync(id);
        if (expenseCategory == null)
        {
            return null;
        }

        var expenseCategoryDetail = new ExpenseCategoryDetail()
        {
            CategoryId = expenseCategory.CategoryId,
            CategoryName = expenseCategory.CategoryName,
        };

        return expenseCategoryDetail;
    }

    public async Task<List<Expense>> GetExpensesByCategoryId(int categoryId)
    {
        var expenses = await _context.Expenses
            .Where(e => e.CategoryId == categoryId)
            .ToListAsync();

        return expenses;
    }


    public async Task<bool> CreateExpenseCategory(ExpenseCategoryCreate model)
    {
        var expenseCategory = new ExpenseCategory()
        {
            CategoryName = model.CategoryName,
        };

        _context.ExpenseCategories.Add(expenseCategory);
        int changes = await _context.SaveChangesAsync();

        return changes > 0;
    }

    public async Task<bool> UpdateExpenseCategory(ExpenseCategoryDetail model)
    {
        var entity = await _context.ExpenseCategories.FindAsync(model.CategoryId);

        if (entity is null)
        {
            return false;
        }

        entity.CategoryName = model.CategoryName;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteExpenseCategory(int id)
    {
        var expenseCategory = await _context.ExpenseCategories.FindAsync(id);
        if (expenseCategory == null)
        {
            return false;
        }

        try
        {
            _context.ExpenseCategories.Remove(expenseCategory);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException)
        {
            return false;
        };
    }
}

