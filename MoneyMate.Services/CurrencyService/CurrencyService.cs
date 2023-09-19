using MoneyMate.Data.Entities;
using MoneyMate.Models.Currency;
using Microsoft.EntityFrameworkCore;
using MoneyMate.Data.DataEntities;


namespace MoneyMate.Services.CurrencyService;

public class CurrencyService : ICurrencyService
{
    private readonly ApplicationDbContext _context;

    public CurrencyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Currency>> GetAllCurrencies()
    {
        List<Currency> currencies = await _context.Currencies
            .Select(e => new Currency()
            {
                CurrencyId = e.CurrencyId,
                CurrencyName = e.CurrencyName,
                Code = e.Code,
            }).ToListAsync();

        return currencies;
    }

    public async Task<CurrencyDetail> GetCurrencyById(int id)
    {
        var currency = await _context.Currencies.FindAsync(id);
        if (currency == null)
        {
            return null;
        }

        var currencyDetail = new CurrencyDetail()
        {
            CurrencyId = currency.CurrencyId,
            CurrencyName = currency.CurrencyName,
            Code = currency.Code,
        };

        return currencyDetail;
    }

    public async Task<bool> CreateCurrency(CurrencyCreate model)
    {
        var entity = new Currency
        {
            CurrencyName = model.CurrencyName,
            Code = model.Code,
        };

        _context.Currencies.Add(entity);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> UpdateCurrency(CurrencyEdit model)
    {
        var entity = await _context.Currencies.FindAsync(model.CurrencyId);
        if (entity == null)
        {
            return false;
        }

        entity.CurrencyName = model.CurrencyName;
        entity.Code = model.Code;

        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteCurrency(int id)
    {
        var entity = await _context.Currencies.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        try
        {
            _context.Currencies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        };

    }
}