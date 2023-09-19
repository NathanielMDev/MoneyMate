using MoneyMate.Models.PaymentMethod;
using MoneyMate.Data.Entities;

namespace MoneyMate.Services.PaymentService;

public interface IPaymentMethodService
{
    Task<bool> CreatePaymentMethod(PaymentMethodCreate model);

    Task<List<PaymentMethod>> GetAllPaymentMethods();

    Task<PaymentMethodDetail> GetPaymentMethodById(int id);

    Task<bool> UpdatePaymentMethod(PaymentMethodEdit model);

    Task<bool> DeletePaymentMethod(int id);
}
