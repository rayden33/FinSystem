using FinSystem.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FinSystem.Controllers;

public class TransactionController(ILogger<TransactionController> logger) : BaseController
{
    /// <summary>
    /// Creating new transaction
    /// </summary>
    /// <param name="transaction">Transaction data</param>
    /// <returns>Created</returns>
    [HttpPost]
    public IActionResult Create(TransactionRequestDto transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        
        logger.LogInformation("Transaction created");
        
        return Created();
    }
}
