using Microsoft.AspNetCore.Mvc;
using MoneyMate.Data.Entities;
using MoneyMate.Models.Currency;
using MoneyMate.Services.CurrencyService;

namespace MoneyMate.Controllers;

public class CurrencyController : Controller
{
    private readonly ICurrencyService _service;

    public CurrencyController(ICurrencyService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        List<Currency> currencies = _service.GetAllCurrencies().Result;

        var viewModel = currencies.Select(e => new CurrencyListItem
        {
            CurrencyId = e.CurrencyId,
            CurrencyName = e.CurrencyName,
            Code = e.Code,
        }).ToList();
        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        var model = new CurrencyCreate();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CurrencyCreate model)
    {
        if (ModelState.IsValid)
        {
            await _service.CreateCurrency(model);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var currency = await _service.GetCurrencyById(id);
        if (currency == null)
        {
            return NotFound();
        }

        CurrencyEdit editModel = new CurrencyEdit
        {
            CurrencyId = currency.CurrencyId,
            CurrencyName = currency.CurrencyName,
            Code = currency.Code,
        };

        return View(editModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CurrencyEdit model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var currency = await _service.GetCurrencyById(model.CurrencyId);

        if (currency == null)
        {
            return RedirectToAction(nameof(Index));
        }

        await _service.UpdateCurrency(model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var currency = await _service.GetCurrencyById(id);
        if (currency == null)
        {
            return NotFound();
        }

        CurrencyDetail deleteModel = new CurrencyDetail
        {
            CurrencyId = currency.CurrencyId,
            CurrencyName = currency.CurrencyName,
            Code = currency.Code,
        };

        return View(deleteModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(CurrencyDetail model)
    {
        CurrencyDetail currency = await _service.GetCurrencyById(model.CurrencyId);

        if (currency == null)
        {
            return RedirectToAction(nameof(Index));
        }

        await _service.DeleteCurrency(model.CurrencyId);

        return RedirectToAction(nameof(Index));
    }
}

