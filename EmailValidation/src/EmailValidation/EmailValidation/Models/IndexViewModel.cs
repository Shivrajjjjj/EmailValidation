namespace EmailValidation.Models
{
    public class IndexViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Auto-calculated after splitting email
        public string Domain { get; set; } = string.Empty;
    }
}
