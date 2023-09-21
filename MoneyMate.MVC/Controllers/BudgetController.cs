using Microsoft.AspNetCore.Mvc;
using MoneyMate.Models.Budget;
using MoneyMate.Services.BudgetService;
using Newtonsoft.Json;

namespace MoneyMate.Controllers;

public class BudgetController : Controller
{
    private readonly IBudgetService _service;

    public BudgetController(IBudgetService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var categoryTotals = await _service.GetCategoryTotals();
        var viewModel = new BudgetViewModel
        {
            CategoryTotals = categoryTotals,
        };

        return View(viewModel);
    }

    
}