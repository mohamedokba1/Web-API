using System.ComponentModel.DataAnnotations;

namespace API01.CustomValidator
{
    public class MinProductionDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        => value is DateTime date && date< DateTime.Now;
    }
}
