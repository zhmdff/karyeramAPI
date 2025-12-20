//namespace KaryeramAPI.Models
//{
//    public class Notification
//    {
//        public int Id { get; set; }
//        public NotificationType Type { get; set; }
//        public string? SenderId { get; set; }           // who triggered it
//        public string? RecieverId { get; set; }           // who triggered it
//        public int? JobId { get; set; }             // related job
//        public int? ApplicationId { get; set; }     // related application
//        public string? Status { get; set; }         // e.g. "Accepted" / "Declined"
//        public required string Message { get; set; }        // optional text
//        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

//        public ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
//    }

//    public class UserNotification
//    {
//        public int Id { get; set; }
//        public int NotificationId { get; set; }
//        public Notification Notification { get; set; } = null!;

//        //public string UserId { get; set; }
//        public bool IsRead { get; set; } = false;
//        public DateTime? DeliveredAt { get; set; }
//        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

//        public string Channel { get; set; } = "inapp";
//    }

//    public class NotificationPreference
//    {
//        //public string UserId { get; set; }
//        public string Preferences { get; set; } = "{}";
//    }

//    public enum NotificationTyape
//    {
//        JobApplication,
//        ApplicationResponse,
//        System
//    }
//}
