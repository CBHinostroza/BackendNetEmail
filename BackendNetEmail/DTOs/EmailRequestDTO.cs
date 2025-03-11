using System.ComponentModel.DataAnnotations;

namespace BackendNetEmail.DTOs
{
    public class EmailRequestDTO
    {
        [MaxLength(100)]
        [EmailAddress]
        public string EmailTo { get; set; } = string.Empty;
    }
}
