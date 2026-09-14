namespace ITI_Project.ModelView
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime MembershipStartDate { get; set; }
        public DateTime MembershipExpiryDate { get; set; }
        public bool IsBlocked { get; set; }
        public int ActiveLoansCount { get; set; }
        public decimal TotalUnpaidFines { get; set; }
    }
}
