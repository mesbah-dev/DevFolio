using Application.DTOs.Common;

namespace Application.Helpers
{
    public class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ValidationResult IsValidINput(PagingInput input)
        {
            if (input.PageIndex < 0 )
                return new ValidationResult(false, "Page index can not be negetive.");

            if (input.PageSize < 0)
                return new ValidationResult(false, "Page size can not be negetive.");

            if (input.PageSize > 50)
                input.PageSize = 50;

            if (input.PageIndex == 0)
                input.PageIndex = 1;

            return new ValidationResult(true, "");
        }
    }
}
