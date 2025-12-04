namespace EmailValidation.Models
{
    public class BlockedEmailInfo
    {
        public required string Email { get; set; }
        public required string Domain { get; set; }
        public required string HostName { get; set; }
        public required string IPAddress { get; set; }
        public required string TriggerTime { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
