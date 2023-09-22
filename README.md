# Money Mate

Welcome to Money Mate, your personal finance management application. Money Mate is designed to empower you to take control of your finances, simplifying expense tracking, budgeting, and more!

## Table of Contents
1. [Features](#features)
2. [Required Software](#required-software)
3. [Installation](#installation)
4. [Tour Money Mate](#tour-money-mate)
5. [Technologies](#technologies)
6. [Contributors](#contributors)

## Features
---

Money Mate offers a range of powerful features to help you manage your finances and achieve your financial goals:

##### Expense Tracking
- Easily track your daily expenses, including the amount spent, date, and description.
- Categorize your expenses for better organization and budgeting.

#####  Budget Setting
- Create and manage budgets to control your spending in different expense categories.
- Set budget amounts, start dates, and end dates to align with your financial goals.

#####  Currency Selection
- Choose your preferred currency for expense tracking, making it convenient for international users.

##### Payment Method Management
- Add, edit, and delete payment methods to record your payment preferences and methods.

#####  Investment Portfolio (Stretch Goal)
- Attach and track your investment portfolio to monitor your investment performance and net worth.

##### AI Category Help (Stretch Goal)
- Utilize AI-powered assistance to categorize your expenses accurately.

#####  Data Chart Reporting (Stretch Goal)
- Visualize your financial data with interactive charts and reports to gain insights into your spending habits.

#####  User Authentication (Stretch Goal)
- Securely register and manage your account with minimal personal information required.
- Safeguarded user data to ensure confidentiality and privacy.

Explore these features and take control of your finances with Money Mate!

## Required Software
- Docker (for containerization)
- Azure Data Studio (for database management)
- .NET Framework

## Installation
To install Money Mate, follow these steps:

1. **Clone the Money Mate repository.**
2. Ensure Docker is running on your server.
3. Ensure Azure Data Studio is running.
4. Install the required .NET framework.
5. In a terminal from the MVC Layer, run the following commands:
   - `dotnet ef migrations add InitialCreate --project ../MoneyMate.Data` (to create a Migrations folder)
   - `dotnet run SeedData` (this program will populate the database with information to get you started)
   - Hit `Control + C` to stop the program.
6. Next, run `dotnet ef database update` to apply the migrations to Azure Data Studio.
7. Use `dotnet run` to start the app.
8. Enjoy the app! Refer to the "Tour Money Mate" section for an overview of the app's functions.

## Tour Money Mate
1. **Expenses**
   - Click the `Expenses` tab on the navigation bar to:
     - View a list of your Expenses.
     - Sort them by Expense ID, Amount, Date, or Category.
     - Edit, Delete, or view Details for each Expense.
     - Click on the Expense Category to see all Expenses associated with the Category.

2. **Budgets**
   - Click the `Budgets` tab on the navigation bar to:
     - See more information based on your Expenses.
     - Explore categories, view each expense associated with the Category, and see related stats.
       - Expense Count: A count of how many Expenses are in a category.
       - Total Amount: The total of the Expenses in a category.
       - Average Purchase: The average purchase amount for each Expense in a category.
       - Expenditure Percentage: The percentage of all your spending.

3. **Utilities**
   - Access utility functions by clicking on the options in the Utilities drop-down menu:
     - **Expense Category:** Create, Edit, and Delete Categories.
     - **Payment Method:** Create, Edit, and Delete Payment Methods.
     - **Currency:** Create, Edit, and Delete Currencies.

4. **Enjoy using Money Mate!**
   - Feel free to delete existing expenses and add your own!

## Technologies
- Backend: Entity Framework
- Database: Azure Data Studio + Docker
- Hosting: Azure (for future releases)

## Contributors
- Nathaniel Matlack - [NathanielMDev](https://github.com/NathanielMDev)
