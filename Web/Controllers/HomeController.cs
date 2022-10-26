using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Facade;
using Web.Models;
using Web.Utils;

namespace Web.Controllers;

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
    
    [HttpPost]
    public IActionResult Index(CreditCard creditCard)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(creditCard.Number))
                throw new Exception("Please enter a credit card number");

            var cardNumber = creditCard.Number.RemoveWhiteSpace();
            
            if (!cardNumber.IsNumeric())
                throw new Exception("The credit card number must only consists of digits.");

            if (Validator.CheckIfCardNoAlreadyCaptured(cardNumber, new CreditCardManager().Items))
                throw new Exception("The credit card number has already been captured.");

            var providers = new CreditCardProviderManager().Items;

            if (!Validator.ValidateMII(cardNumber, providers))
                throw new Exception("The credit card number you have entered contains a MII which is not associated with an existing credit card provider.");

            if (!Validator.ValidateCardNo(cardNumber))
                throw new Exception("The credit card number entered you have entered is not valid.");
            
            var provider = Validator.GetCreditCardProvider(cardNumber, providers);

            if (provider == null)
                throw new Exception($"The provider associated with credit card number [{cardNumber}] could not be found.");

            creditCard = new CreditCard { Number = cardNumber, CreditCardProviderName = provider.Name };
            
            new CreditCardManager().Add(creditCard);
            
            ViewData["SuccessMessage"] = $"The [{creditCard.CreditCardProviderName}] credit card number [{creditCard.Number}] has been successfully captured.";
            
            return View(creditCard);
        }
        catch (Exception exception)
        {
            ViewData["Exception"] = exception.Message;
            return View(creditCard);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}