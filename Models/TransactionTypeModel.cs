namespace FinanceTrackingApp.Models
{
    public class TransactionTypeModel
    {
        public Guid transTypeGuid { get; set; }
        public string transTypeName { get; set; }
        public string transTypeAbbrev { get; set; }
        public int transTypeIsActive { get; set; }
    }
}
