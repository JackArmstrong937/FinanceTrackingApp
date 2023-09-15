namespace FinanceTrackingApp.Models
{
    public class UserModel
    {
        public Guid userGuid { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userEmailAddress { get; set; }
        public string userPassword { get; set; }
        public int userIsActive { get; set; }
    }
}
