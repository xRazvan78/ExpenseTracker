using ExpenseTracker.Components.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Services
{
    public class IncomeService
    {
        private readonly ExpenseTrackerContext _context;

        public IncomeService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public List<Income> GetIncomes()
        {
            return _context.Incomes.ToList();
        }

        public Income AddIncome(Income income)
        {
            income.Date = DateTime.SpecifyKind(income.Date, DateTimeKind.Utc);

            _context.Incomes.Add(income);
            _context.SaveChanges();
            return income;
        }

        public Income UpdateIncomeDetails(Income income)
        {
            income.Date = DateTime.SpecifyKind(income.Date, DateTimeKind.Utc);

            _context.Entry(income).State = EntityState.Modified;
            _context.SaveChanges();
            return income;
        }

        public Income GetIncomeData(int id)
        {
            try
            {
                Income? income = _context.Incomes.Find(id);
                if (income != null) {
                    return income;
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

        public void DeleteIncome(int id)
        {
            try
            {
                Income? income = _context.Incomes.Find(id);
                if (income != null)
                {
                    _context.Incomes.Remove(income);
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
