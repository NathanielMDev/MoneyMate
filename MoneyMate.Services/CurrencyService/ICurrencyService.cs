using MoneyMate.Models.Currency;
using MoneyMate.Data.Entities;

namespace MoneyMate.Services.CurrencyService;

public interface ICurrencyService
{
    Task<bool> CreateCurrency(CurrencyCreate model);

    Task<List<Currency>> GetAllCurrencies();

    Task<CurrencyDetail> GetCurrencyById(int id);

    Task<bool> UpdateCurrency(CurrencyEdit model);

    Task<bool> DeleteCurrency(int id);
}
