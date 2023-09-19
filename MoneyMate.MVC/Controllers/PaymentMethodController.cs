using Microsoft.AspNetCore.Mvc;
using MoneyMate.Data.Entities;
using MoneyMate.Models.PaymentMethod;
using MoneyMate.Services.PaymentService;

namespace MoneyMate.Controllers;

public class PaymentMethodController : Controller
{
    private readonly IPaymentMethodService _service;

    public PaymentMethodController(IPaymentMethodService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        List<PaymentMethod> paymentMethods = _service.GetAllPaymentMethods().Result;

        var viewModel = paymentMethods.Select(e => new PaymentMethodListItem
        {
            PaymentId = e.PaymentId,
            PaymentName = e.PaymentName,

        }).ToList();
        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        var model = new PaymentMethodCreate();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PaymentMethodCreate model)
    {
        if (ModelState.IsValid)
        {
            await _service.CreatePaymentMethod(model);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var paymentMethod = await _service.GetPaymentMethodById(id);
        if (paymentMethod == null)
        {
            return NotFound();
        }

        PaymentMethodEdit editModel = new PaymentMethodEdit
        {
            PaymentName = paymentMethod.PaymentName,
        };

        return View(editModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PaymentMethodEdit model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var paymentMethod = await _service.GetPaymentMethodById(model.PaymentId);

        if (paymentMethod == null)
        {
            return RedirectToAction(nameof(Index));
        }

        await _service.UpdatePaymentMethod(model);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var paymentMethod = await _service.GetPaymentMethodById(id);
        if (paymentMethod == null)
        {
            return NotFound();
        }

        PaymentMethodDetail deleteModel = new PaymentMethodDetail
        {
            PaymentId = paymentMethod.PaymentId,
            PaymentName = paymentMethod.PaymentName,
        };

        return View(deleteModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(PaymentMethodDetail model)
    {
        PaymentMethodDetail paymentMethod = await _service.GetPaymentMethodById(model.PaymentId);

        if (paymentMethod == null)
        {
            return RedirectToAction(nameof(Index));
        }

        await _service.DeletePaymentMethod(model.PaymentId);

        return RedirectToAction(nameof(Index));
    }
}