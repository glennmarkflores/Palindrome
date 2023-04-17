using Microsoft.AspNetCore.Mvc;
using Palindrome.Models;
using System.Diagnostics;
using System.Text;

namespace Palindrome.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reverse()
        {
            PalindromeModel palindrome = new PalindromeModel();
            return View(palindrome);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reverse(PalindromeModel palindrome)
        {
            string inputWord = palindrome.InputWord;
            StringBuilder reversedBuilder = new StringBuilder(inputWord.Length);

            for (int i = inputWord.Length - 1; i >= 0; i--)
            {
                reversedBuilder.Append(inputWord[i]);

                if (i < inputWord.Length / 2 && inputWord[i] != inputWord[inputWord.Length - i - 1])
                {
                    palindrome.IsPalindrome = false;
                    palindrome.Message = $"{inputWord} is not a Palindrome";
                } else
                {
                    palindrome.Message = $"{inputWord} is a Palindrome";
                }
            }

            palindrome.ReverseWord = reversedBuilder.ToString();

            return View(palindrome);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}