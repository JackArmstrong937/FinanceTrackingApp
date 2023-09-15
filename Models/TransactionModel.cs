namespace FinanceTrackingApp.Models
{
    public class TransactionModel
    {
        public Guid transactionGuid { get; set; }
        public Guid userGuid { get; set; }
        public DateTime transDate { get; set; }
        public string transPayedTo { get; set; }
        public string transNote { get; set; }
        public Guid transCategoryGuid { get; set; }
        public float transAmount { get; set; }
        public int transIsActive { get; set; }
    }
}
