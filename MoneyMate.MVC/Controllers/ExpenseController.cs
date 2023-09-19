using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyMate.Data.Entities;
using MoneyMate.Models.Expense;
using MoneyMate.Services.ExpenseService;

namespace MoneyMate.Controllers;

public class ExpenseController : Controller
{
    private readonly IExpenseService _service;

    public ExpenseController(IExpenseService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {

        List<ExpenseListItem> expenses = await _service.GetAllExpenses();
        return View(expenses);
    }


    public async Task<IActionResult> Create()
    {


        var categories = await _service.GetAllExpenseCategories();
        var paymentMethods = await _service.GetAllPaymentMethods();
        var currencies = await _service.GetAllCurrencies();

        if (categories == null || paymentMethods == null || currencies == null)
        {
            return NotFound();
        }

        var model = new ExpenseCreate
        {
            Amount = 0.00,
            Date = DateTime.Now,
            Description = "What did you purchase?",
        };

        GetSelectLists(categories, paymentMethods, currencies);

        return View(model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ExpenseCreate model)
    {
        if (ModelState.IsValid)
        {
            await _service.CreateExpense(model);

            return RedirectToAction(nameof(Index));
        }

        var categories = await _service.GetAllExpenseCategories();
        var paymentMethods = await _service.GetAllPaymentMethods();
        var currencies = await _service.GetAllCurrencies();

        GetSelectLists(categories, paymentMethods, currencies);

        return View(model);
    }


    [ActionName("Details")]
    public async Task<IActionResult> Detail(int id)
    {
        var expense = await _service.GetExpenseById(id);

        if (expense == null)
        {
            return NotFound();
        }

        ExpenseDetail model = new ExpenseDetail
        {
            ExpenseId = expense.ExpenseId,
            Amount = expense.Amount,
            Date = expense.Date,
            Description = expense.Description,
            CategoryId = expense.CategoryId,
            PaymentId = expense.PaymentId,
            CurrencyId = expense.CurrencyId,
        };

        return View(expense);

    }

    public async Task<IActionResult> Edit(int id)
    {
        var expense = await _service.GetExpenseById(id);
        if (expense == null)
        {
            return RedirectToAction(nameof(Index));
        }

        var categories = await _service.GetAllExpenseCategories();
        var paymentMethods = await _service.GetAllPaymentMethods();
        var currencies = await _service.GetAllCurrencies();

        GetSelectLists(categories, paymentMethods, currencies);

        ExpenseEdit expenseEdit = new ExpenseEdit()
        {
            ExpenseId = expense.ExpenseId,
            Amount = expense.Amount,
            Date = expense.Date,
            Description = expense.Description,
            CategoryId = expense.CategoryId,
            PaymentId = expense.PaymentId,
            CurrencyId = expense.CurrencyId,
        };

        return View(expenseEdit);
    }



    [HttpPost]
    public async Task<IActionResult> Edit(ExpenseEdit model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _service.GetAllExpenseCategories();
            var paymentMethods = await _service.GetAllPaymentMethods();
            var currencies = await _service.GetAllCurrencies();

            GetSelectLists(categories, paymentMethods, currencies);

            return View(model);
        }

        if (await _service.UpdateExpense(model))
        {
            return RedirectToAction("Details", new { id = model.ExpenseId });
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Failed to update expense.");

            var categories = await _service.GetAllExpenseCategories();
            var paymentMethods = await _service.GetAllPaymentMethods();
            var currencies = await _service.GetAllCurrencies();

            GetSelectLists(categories, paymentMethods, currencies);

            return View(model);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        var expense = await _service.GetExpenseById(id);

        if (expense == null)
        {
            return NotFound();
        }

        ExpenseDetail ExpenseDetail = new ExpenseDetail()
        {
            ExpenseId = expense.ExpenseId,
            Amount = expense.Amount,
            Date = expense.Date,
            Description = expense.Description,
        };

        return View(ExpenseDetail);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(ExpenseDetail model)
    {
        ExpenseDetail expense = await _service.GetExpenseById(model.ExpenseId);

        if (expense == null)
        {
            return RedirectToAction(nameof(Index));
        }

        if (await _service.DeleteExpense(model.ExpenseId))
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Failed to delete expense.");
            return View(nameof(Delete), new ExpenseDetail { ExpenseId = model.ExpenseId });
        }
    }

    private void GetSelectLists(List<ExpenseCategory> categories, List<PaymentMethod> paymentMethods, List<Currency> currencies)
    {
        ViewData["CategoryList"] = new SelectList(categories, "CategoryId", "CategoryName");
        ViewData["PaymentMethodList"] = new SelectList(paymentMethods, "PaymentId", "PaymentName");
        ViewData["CurrencyCodeList"] = new SelectList(currencies, "CurrencyId", "Code");
    }

}