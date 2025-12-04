namespace EmailValidation.Models
{
    public class BlockedEmailViewModel
    {
        public required string Email { get; set; }
        public required string Domain { get; set; }
        public required string Host { get; set; }
        public required string IPAddress { get; set; }
        public required string TriggerTime { get; set; }
        public required string Reason { get; set; }
    }
}
