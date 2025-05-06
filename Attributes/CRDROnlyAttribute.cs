using System.ComponentModel.DataAnnotations;

public class CRDROnlyAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is string str) return str is "CR" or "DR";
        return false;
    }

    public override string FormatErrorMessage(string name) => $"{name} can be only CR or DR";
}