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
                    "Miscellaneous",
                    "Pet Care",
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
        new { Amount = 75.00, Date = DateTime.Now.AddDays(-5), Description = "Clothing shopping", CategoryId = 7, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 40.00, Date = DateTime.Now.AddDays(-12), Description = "Gasoline", CategoryId = 5, PaymentId = 3, CurrencyId = 1 },
        new { Amount = 300.00, Date = DateTime.Now.AddDays(-18), Description = "Concert tickets", CategoryId = 6, PaymentId = 2, CurrencyId = 2 },
        new { Amount = 800.00, Date = DateTime.Now.AddDays(-25), Description = "Mortgage payment", CategoryId = 4, PaymentId = 4, CurrencyId = 1 },
        new { Amount = 90.00, Date = DateTime.Now.AddDays(-3), Description = "Lunch with friends", CategoryId = 6, PaymentId = 2, CurrencyId = 1 },
        new { Amount = 25.00, Date = DateTime.Now.AddDays(-6), Description = "Coffee and snacks", CategoryId = 6, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 120.00, Date = DateTime.Now.AddDays(-14), Description = "New shoes", CategoryId = 7, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 65.00, Date = DateTime.Now.AddDays(-17), Description = "Haircut", CategoryId = 22, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 250.00, Date = DateTime.Now.AddDays(-23), Description = "Home repair", CategoryId = 15, PaymentId = 5, CurrencyId = 1 },
        new { Amount = 150.00, Date = DateTime.Now.AddDays(-28), Description = "Gym membership", CategoryId = 18, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 20.00, Date = DateTime.Now.AddDays(-4), Description = "Bus fare", CategoryId = 5, PaymentId = 7, CurrencyId = 1 },
        new { Amount = 180.00, Date = DateTime.Now.AddDays(-11), Description = "Internet bill", CategoryId = 2, PaymentId = 8, CurrencyId = 1 },
        new { Amount = 50.00, Date = DateTime.Now.AddDays(-19), Description = "Gift for friend", CategoryId = 19, PaymentId = 11, CurrencyId = 1 },
        new { Amount = 95.00, Date = DateTime.Now.AddDays(-27), Description = "Dental checkup", CategoryId = 7, PaymentId = 9, CurrencyId = 1 },
        new { Amount = 110.00, Date = DateTime.Now.AddDays(-9), Description = "Weekend getaway", CategoryId = 17, PaymentId = 10, CurrencyId = 1 },
        new { Amount = 75.00, Date = DateTime.Now.AddDays(-13), Description = "Pet supplies", CategoryId = 23, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 300.00, Date = DateTime.Now.AddDays(-21), Description = "Furniture", CategoryId = 15, PaymentId = 12, CurrencyId = 1 },
        new { Amount = 180.00, Date = DateTime.Now.AddDays(-29), Description = "Electricity bill", CategoryId = 2, PaymentId = 8, CurrencyId = 1 },
        new { Amount = 40.00, Date = DateTime.Now.AddDays(-7), Description = "Fast food", CategoryId = 6, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 65.00, Date = DateTime.Now.AddDays(-16), Description = "Laundry", CategoryId = 22, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 250.00, Date = DateTime.Now.AddDays(-24), Description = "Car maintenance", CategoryId = 5, PaymentId = 14, CurrencyId = 1 },
        new { Amount = 150.00, Date = DateTime.Now.AddDays(-12), Description = "Music streaming", CategoryId = 6, PaymentId = 8, CurrencyId = 1 },
        new { Amount = 60.00, Date = DateTime.Now.AddDays(-5), Description = "Office supplies", CategoryId = 15, PaymentId = 6, CurrencyId = 1 },
        new { Amount = 85.00, Date = DateTime.Now.AddDays(-9), Description = "Gardening tools", CategoryId = 24, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 35.00, Date = DateTime.Now.AddDays(-15), Description = "Lunch at work", CategoryId = 6, PaymentId = 2, CurrencyId = 1 },
        new { Amount = 70.00, Date = DateTime.Now.AddDays(-12), Description = "Pet grooming", CategoryId = 23, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 95.00, Date = DateTime.Now.AddDays(-8), Description = "Mobile phone bill", CategoryId = 2, PaymentId = 8, CurrencyId = 1 },
        new { Amount = 120.00, Date = DateTime.Now.AddDays(-6), Description = "Home decor", CategoryId = 15, PaymentId = 12, CurrencyId = 1 },
        new { Amount = 55.00, Date = DateTime.Now.AddDays(-11), Description = "Hair coloring", CategoryId = 22, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 250.00, Date = DateTime.Now.AddDays(-18), Description = "Auto insurance", CategoryId = 14, PaymentId = 13, CurrencyId = 1 },
        new { Amount = 70.00, Date = DateTime.Now.AddDays(-14), Description = "Dental cleaning", CategoryId = 7, PaymentId = 9, CurrencyId = 1 },
        new { Amount = 65.00, Date = DateTime.Now.AddDays(-7), Description = "Fast food", CategoryId = 6, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 180.00, Date = DateTime.Now.AddDays(-4), Description = "Gas and electricity", CategoryId = 2, PaymentId = 8, CurrencyId = 1 },
        new { Amount = 45.00, Date = DateTime.Now.AddDays(-10), Description = "Bus fare", CategoryId = 5, PaymentId = 7, CurrencyId = 1 },
        new { Amount = 110.00, Date = DateTime.Now.AddDays(-9), Description = "Weekend getaway", CategoryId = 17, PaymentId = 10, CurrencyId = 1 },
        new { Amount = 85.00, Date = DateTime.Now.AddDays(-15), Description = "Library fines", CategoryId = 6, PaymentId = 15, CurrencyId = 1 },
        new { Amount = 30.00, Date = DateTime.Now.AddDays(-12), Description = "Coffee with friends", CategoryId = 6, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 70.00, Date = DateTime.Now.AddDays(-8), Description = "Movie tickets", CategoryId = 6, PaymentId = 3, CurrencyId = 1 },
        new { Amount = 200.00, Date = DateTime.Now.AddDays(-6), Description = "Home security", CategoryId = 15, PaymentId = 12, CurrencyId = 1 },
        new { Amount = 150.00, Date = DateTime.Now.AddDays(-11), Description = "Concert tickets", CategoryId = 6, PaymentId = 2, CurrencyId = 2 },
        new { Amount = 80.00, Date = DateTime.Now.AddDays(-7), Description = "Gym membership", CategoryId = 18, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 65.00, Date = DateTime.Now.AddDays(-14), Description = "Car wash", CategoryId = 5, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 45.00, Date = DateTime.Now.AddDays(-13), Description = "Snack vending machine", CategoryId = 6, PaymentId = 1, CurrencyId = 1 },
        new { Amount = 40.00, Date = DateTime.Now.AddDays(-3), Description = "Bus fare", CategoryId = 5, PaymentId = 7, CurrencyId = 1 },
        new { Amount = 180.00, Date = DateTime.Now.AddDays(-6), Description = "Internet bill", CategoryId = 2, PaymentId = 8, CurrencyId = 1 },
        new { Amount = 50.00, Date = DateTime.Now.AddDays(-8), Description = "Gift for family", CategoryId = 19, PaymentId = 11, CurrencyId = 1 }

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
