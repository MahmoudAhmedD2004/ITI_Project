namespace ITI_Project.ModelView
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public string BookTitle { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }
        public int QueuePosition { get; set; }
    }
}
