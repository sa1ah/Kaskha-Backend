using Kashkha.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentManager _paymentManager;

    public PaymentController(PaymentManager paymentManager)
    {
        _paymentManager = paymentManager;
    }

    [HttpPost("create-checkout-session")]
    public async Task<IActionResult> CreateCheckoutSession(int orderId)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var session = await _paymentManager.CreateCheckoutSessionAsync(orderId, userId);
        return Ok(new { SessionId = session.Id });
    }
}