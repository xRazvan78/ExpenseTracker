using ExpenseTracker.Components.Data;
using ExpenseTracker.Components.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private readonly ExpenseTrackerContext _context;

        public ExpenseService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public List<Expense> GetExpenses()
        {
            return _context.Expenses
                .Include(e => e.Category)
                .ToList();
        }

        public Expense AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return expense;
        }

        public Expense UpdateExpenseDetails(Expense expense)
        {
            expense.Date = DateTime.SpecifyKind(expense.Date, DateTimeKind.Unspecified);
            _context.Entry(expense).State = EntityState.Modified;
            _context.SaveChanges();
            return expense;
        }

        public Expense GetExpenseData(int id)
        {
            try
            {
                Expense? expense = _context.Expenses.Find(id);
                if (expense != null)
                {
                    return expense;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteExpense(int id)
        {
            try
            {
                Expense? expense = _context.Expenses.Find(id);
                if (expense != null)
                {
                    _context.Expenses.Remove(expense);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
