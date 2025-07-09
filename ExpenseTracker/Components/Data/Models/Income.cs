﻿namespace ExpenseTracker.Components.Data.Models
{
    public enum IncomeType
    {
        Salary,
        Scholarship,
        Gift,
        Lucky,
        Winnings

    }
    public class Income
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public IncomeType Type { get; set; }


    }
}
