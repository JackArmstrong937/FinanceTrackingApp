namespace FinanceTrackingApp.Models
{
    public class CategoryModel
    {
        public Guid categoryGuid { get; set; }
        public string categoryName { get; set; }
        public int categorySortOrder { get; set; }
        public int categoryIsActive { get; set; }

        //calculated
        public float categoryAmount { get; set; }
    }
}
