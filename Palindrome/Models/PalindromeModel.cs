using System.ComponentModel.DataAnnotations;

namespace Palindrome.Models
{
    public class PalindromeModel
    {
        [Required]
        public string? InputWord { get; set; } 
        public string? ReverseWord { get; set; }
        public bool IsPalindrome { get; set; }
        public string? Message { get; set; }


    }
}
