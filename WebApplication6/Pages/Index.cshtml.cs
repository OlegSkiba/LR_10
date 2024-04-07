using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication6.Pages.Models;

namespace WebApplication6.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public RegistrationModel Registration { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Registration.SelectedProduct == "Основи" && Registration.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("Registration.SelectedProduct", "Консультація щодо продукту «Основи» не може проходити по понеділках.");
                return Page();
            }
            return RedirectToPage("/Success");
        }
    }
}
