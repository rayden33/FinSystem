using System.ComponentModel.DataAnnotations;

namespace FinSystem.Models.DTOs;

/// <summary>
/// DTO for creating of transaction
/// </summary>
public class TransactionRequestDto
{
    /// <example>9860123412341234</example>>
    [Required]
    [RegularExpression(@"^\d{16}$", ErrorMessage = "Card pan must be 16 digits")]
    public string CardPan { get; set; }
    
    /// <example>12000.50</example>>
    [Required]
    [Range(0.01,double.MaxValue,ErrorMessage = "Amount must be greeter than 0.01")]
    public decimal Amount { get; set; }
    
    /// <example>CR</example>>
    [Required]
    [CRDROnly(ErrorMessage = "Valid values: CR or DR")]
    public string OperationType { get; set; } = "CR";
}
