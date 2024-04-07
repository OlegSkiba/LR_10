using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Pages.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Ім'я та прізвище є обов'язковими.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email є обов'язковим.")]
        [EmailAddress(ErrorMessage = "Неправильний формат Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Будь ласка, виберіть бажану дату консультації.")]
        [FutureDate(ErrorMessage = "Дата має бути в майбутньому.")]
        [NotWeekend(ErrorMessage = "Дата консультації не може бути у вихідні дні.")]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Будь ласка, виберіть продукт для консультації.")]
        [NotBasicOnMonday(ErrorMessage = "Консультація щодо продукту «Основи» не може проходити по понеділках.")]
        public string SelectedProduct { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);
            return date >= DateTime.Now;
        }
    }

    public class NotWeekendAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
    public class NotBasicOnMondayAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var selectedProduct = value as string;
            var consultationDate = DateTime.Now;

            if (selectedProduct == "Основи" && consultationDate.DayOfWeek == DayOfWeek.Monday)
            {
                return false;
            }
            return true;
        }
    }
}
