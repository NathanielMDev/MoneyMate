using MoneyMate.Data.Entities;
using MoneyMate.Models.Expense;

namespace MoneyMate.Services.ExpenseService;

public interface IExpenseService
{
    Task<bool> CreateExpense(ExpenseCreate model);

    Task<List<ExpenseListItem>> GetAllExpenses();

    Task<ExpenseDetail> GetExpenseById(int id);

    Task<bool> UpdateExpense(ExpenseEdit model);

    Task<bool> DeleteExpense(int id);

    Task<List<ExpenseCategory>> GetAllExpenseCategories();

    Task<List<PaymentMethod>> GetAllPaymentMethods();

    Task<List<Currency>> GetAllCurrencies();

}

