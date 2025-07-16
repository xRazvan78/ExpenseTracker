namespace ExpenseTracker.Components.Data.Models
{
    public enum PlannedType
    {
        Planned,
        Unplanned
    }

    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public PlannedType Planned { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
