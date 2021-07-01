using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHuben.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            Console.WriteLine(Convert.ToString(value));
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            Console.WriteLine(isValid);

            return (isValid && dateTime > DateTime.Now);
            //return base.IsValid(value);
        }
    }
}