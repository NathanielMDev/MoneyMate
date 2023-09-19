using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MoneyMate.Data.DataEntities;
using MoneyMate.Data.Entities;


namespace MoneyMate.Data;

public class Seed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            if (!context.ExpenseCategories.Any())
            {
                var expenseCategories = new string[]
                {
                    "Groceries",
                    "Utilities",
                    "Rent",
                    "Mortgage",
                    "Transportation",
                    "Entertainment",
                    "Healthcare",
                    "Clothing",
                    "Education",
                    "Charity",
                    "Donations",
                    "Savings",
                    "Investments",
                    "Debt Payment",
                    "Home Maintenance",
                    "Insurance",
                    "Taxes",
                    "Travel",
                    "Gifts",
                    "Child Care",
                    "Personal Care",
                    "Electronics",
                    "Miscellaneous"
                };

                foreach (var category in expenseCategories)
                {
                    context.ExpenseCategories.Add(new ExpenseCategory { CategoryName = category });
                }

                context.SaveChanges();
            }

            if (!context.PaymentMethods.Any())
            {
                var paymentMethods = new string[]
                {
                    "Credit Card",
                    "Debit Card",
                    "Cash",
                    "Check",
                    "Bank Transfer",
                    "Mobile Payment",
                    "PayPal",
                    "Online Banking",
                    "Electronic Funds Transfer (ETF)",
                    "Wire Transfer",
                    "Cryptocurrency",
                    "Money Order",
                    "Gift Card",
                    "Direct Deposit",
                    "Contactless Payment",
                    "ACH Payment",
                    "Bill Payment Service",
                    "Cash App",
                    "Venmo",
                    "Other"
                };

                foreach (var method in paymentMethods)
                {
                    context.PaymentMethods.Add(new PaymentMethod { PaymentName = method });
                }

                context.SaveChanges();
            }

            if (!context.Currencies.Any())
            {
                var currencies = new[]
                {

                    new { Code = "USD", Name = "Dollar" },
                    new { Code = "EUR", Name = "Euro" },
                    new { Code = "GBP", Name = "Pound Sterling" },
                    new { Code = "JPY", Name = "Japanese Yen" },
                    new { Code = "AUD", Name = "Australian Dollar" },
                    new { Code = "CAD", Name = "Canadian Dollar" },
                    new { Code = "CHF", Name = "Swiss Franc" },
                    new { Code = "CNY", Name = "Chinese Yuan" },
                    new { Code = "SEK", Name = "Swedish Krona" },
                    new { Code = "NZD", Name = "New Zealand Dollar" }

                };

                foreach (var currency in currencies)
                {
                    context.Currencies.Add(new Currency { Code = currency.Code, CurrencyName = currency.Name });
                }

                context.SaveChanges();
            }

            if (!context.Expenses.Any())
            {
                var expenses = new[]
                {
                    new { Amount = 50.00, Date = DateTime.Now.AddDays(-10), Description = "Grocery shopping", CategoryId = 1, PaymentId = 1, CurrencyId = 1 },
                    new { Amount = 30.00, Date = DateTime.Now.AddDays(-8), Description = "Movie night", CategoryId = 6, PaymentId = 3, CurrencyId = 1 },
                    new { Amount = 200.00, Date = DateTime.Now.AddDays(-15), Description = "Dinner at a restaurant", CategoryId = 6, PaymentId = 2, CurrencyId = 2 },
                    new { Amount = 1000.00, Date = DateTime.Now.AddDays(-20), Description = "Rent payment", CategoryId = 3, PaymentId = 4, CurrencyId = 1 },
                };

                foreach (var expense in expenses)
                {
                    context.Expenses.Add(new Expense
                    {
                        Amount = expense.Amount,
                        Date = expense.Date,
                        Description = expense.Description,
                        CategoryId = expense.CategoryId,
                        PaymentId = expense.PaymentId,
                        CurrencyId = expense.CurrencyId
                    });
                }

                context.SaveChanges();
            }

        }
    }
}
