using MoneyMate.Models.Expense;
using Microsoft.EntityFrameworkCore;
using MoneyMate.Data.DataEntities;
using MoneyMate.Data.Entities;

namespace MoneyMate.Services.ExpenseService;

public class ExpenseService : IExpenseService
{
    private readonly ApplicationDbContext _context;

    public ExpenseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ExpenseListItem>> GetAllExpenses()
    {
        List<ExpenseListItem> expenses = await _context.Expenses
            .Include(e => e.Category)
            .Select(e => new ExpenseListItem()
            {
                Id = e.ExpenseId,
                Amount = e.Amount,
                Description = e.Description,
                Date = e.Date,
                ExpenseCategory = e.Category.CategoryName,
            }).ToListAsync();

        return expenses;
    }

    public async Task<bool> CreateExpense(ExpenseCreate model)
    {
        var currency = await _context.Currencies.FindAsync(model.CurrencyId);
        if (currency == null)
        {
            return false;
        }
        var paymet = await _context.PaymentMethods.FindAsync(model.PaymentId);
        if (paymet == null)
        {
            return false;
        }
        var category = await _context.ExpenseCategories.FindAsync(model.CategoryId);
        if (category == null)
        {
            return false;
        }

        var expense = new Expense()
        {
            Amount = model.Amount,
            Description = model.Description,
            Date = model.Date,
            CategoryId = model.CategoryId,
            PaymentId = model.PaymentId,
            CurrencyId = model.CurrencyId,
        };

        expense.Category = category;
        expense.PaymentMethod = paymet;
        expense.Currency = currency;

        _context.Expenses.Add(expense);

        var savedChanges = await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ExpenseDetail> GetExpenseById(int id)
    {
        var expense = await _context.Expenses
            .Include(e => e.Category)
            .Include(e => e.PaymentMethod)
            .Include(e => e.Currency)
            .FirstOrDefaultAsync(e => e.ExpenseId == id);

        if (expense == null)
        {
            return null;
        }

        var model = new ExpenseDetail()
        {
            ExpenseId = expense.ExpenseId,
            Amount = expense.Amount,
            Date = expense.Date,
            Description = expense.Description,
            ExpenseCategory = expense.Category.CategoryName != null ? expense.Category.CategoryName : "Unknown",
            PaymentMethod = expense.PaymentMethod != null ? expense.PaymentMethod.PaymentName : "Unknown",
            Currency = expense.Currency != null ? expense.Currency.Code : "Unknown",
        };

        return model;
    }

    public async Task<bool> UpdateExpense(ExpenseEdit model)
    {
        var expense = await _context.Expenses.FindAsync(model.ExpenseId);

        if (expense == null)
        {
            return false;
        }

        expense.Amount = model.Amount;
        expense.Date = model.Date;
        expense.Description = model.Description;
        expense.CategoryId = model.CategoryId;
        expense.PaymentId = model.PaymentId;
        expense.CurrencyId = model.CurrencyId;

        _context.Entry(expense).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
    }

    public async Task<bool> DeleteExpense(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
        {
            return false;
        }

        try
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            return false;
        }
    }


    public async Task<List<ExpenseCategory>> GetAllExpenseCategories()
    {
        return await _context.ExpenseCategories.ToListAsync();
    }

    public async Task<List<PaymentMethod>> GetAllPaymentMethods()
    {
        return await _context.PaymentMethods.ToListAsync();
    }

    public async Task<List<Currency>> GetAllCurrencies()
    {
        return await _context.Currencies.ToListAsync();
    }


}

