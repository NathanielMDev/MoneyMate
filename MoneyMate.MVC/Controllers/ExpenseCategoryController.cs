using Microsoft.AspNetCore.Mvc;
using MoneyMate.Data.Entities;
using MoneyMate.Models.ExpenseCategory;
using MoneyMate.Services.ExpenseCategoryService;

namespace MoneyMate.Controllers;

public class ExpenseCategoryController : Controller
{
    private readonly IExpenseCategoryService _service;

    public ExpenseCategoryController(IExpenseCategoryService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        List<ExpenseCategory> expenseCategories = _service.GetAllExpenseCategories().Result;

        var viewModel = expenseCategories.Select(e => new ExpenseCategoryListItem
        {
            CategoryId = e.CategoryId,
            CategoryName = e.CategoryName,

        }).ToList();
        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        var model = new ExpenseCategoryCreate();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ExpenseCategoryCreate model)
    {
        if (ModelState.IsValid)
        {
            await _service.CreateExpenseCategory(model);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var expenseCategory = await _service.GetExpenseCategoryById(id);
        if (expenseCategory == null)
        {
            return NotFound();
        }

        ExpenseCategoryDetail deleteModel = new ExpenseCategoryDetail
        {
            CategoryId = expenseCategory.CategoryId,
            CategoryName = expenseCategory.CategoryName,
        };

        return View(deleteModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ExpenseCategoryDetail model)
    {
        ExpenseCategoryDetail expenseCategory = await _service.GetExpenseCategoryById(model.CategoryId);

        if (expenseCategory == null)
        {
            return RedirectToAction(nameof(Index));
        }

        if (await _service.DeleteExpenseCategory(model.CategoryId))
        {
            return RedirectToAction(nameof(Index));
        }

        else
        {
            ModelState.AddModelError("", "Expense category could not be deleted.");
            return View(nameof(Delete), new ExpenseCategoryDetail { CategoryId = model.CategoryId });
        }
    }



}