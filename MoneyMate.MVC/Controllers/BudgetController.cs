using Microsoft.AspNetCore.Mvc;
using MoneyMate.Data.DataEntities;
namespace MoneyMate.Controllers;

public class BudgetController : Controller
{
    private readonly ApplicationDbContext _context;

    public BudgetController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
}
