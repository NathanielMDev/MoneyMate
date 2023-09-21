using MoneyMate.Models.PaymentMethod;
using Microsoft.EntityFrameworkCore;
using MoneyMate.Data.DataEntities;
using MoneyMate.Data.Entities;

namespace MoneyMate.Services.PaymentService;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly ApplicationDbContext _context;

    public PaymentMethodService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PaymentMethod>> GetAllPaymentMethods()
    {
        List<PaymentMethod> paymentMethods = await _context.PaymentMethods
            .Select(e => new PaymentMethod()
            {
                PaymentId = e.PaymentId,
                PaymentName = e.PaymentName,
            }).ToListAsync();

        return paymentMethods;
    }

    public async Task<PaymentMethodDetail> GetPaymentMethodById(int id)
    {
        var paymentMethod = await _context.PaymentMethods.FindAsync(id);
        if (paymentMethod == null)
        {
            return null;
        }

        var paymentMethodDetail = new PaymentMethodDetail()
        {
            PaymentId = paymentMethod.PaymentId,
            PaymentName = paymentMethod.PaymentName,
        };

        return paymentMethodDetail;
    }

    public async Task<bool> CreatePaymentMethod(PaymentMethodCreate model)
    {
        var entity = new PaymentMethod
        {
            PaymentName = model.PaymentName,
        };

        _context.PaymentMethods.Add(entity);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> UpdatePaymentMethod(PaymentMethodEdit model)
    {
        var entity = await _context.PaymentMethods.FindAsync(model.PaymentId);

        if (entity is null)
        {
            return false;
        }

        entity.PaymentName = model.PaymentName;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletePaymentMethod(int id)
    {
        var entity = await _context.PaymentMethods.FindAsync(id);
        if (entity is null)
        {
            return false;
        }

        try
        {
            _context.PaymentMethods.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException)
        {
            return false;
        };

    }
}
