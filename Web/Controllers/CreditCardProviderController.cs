using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Facade;
using Web.Models;
using Web.Utils;

namespace Web.Controllers
{
    public class CreditCardProviderController : Controller
    {
        public IActionResult Index()
        {
            return View(new CreditCardProviderManager().Items);
        }
        
        public IActionResult Update(int id)
        {
            try
            {
                return View(new CreditCardProviderManager().Items.FirstOrDefault(x => x.Id == id));
            }
            catch (Exception exception)
            {
                ViewData["Exception"] = exception.Message;
                return View();
            }
        }
        
        [HttpPost]
        public IActionResult Update(CreditCardProvider creditCardProvider)
        {
            try
            {
                var creditCardProviderManager = new CreditCardProviderManager();
                
                if (Validator.CheckIfCreditCardProviderNameAlreadyExists(creditCardProvider, creditCardProviderManager.Items))
                    throw new Exception("The [Name] entered already exists.");
                
                if (Validator.CheckIfMajorIndustryIdentifierAlreadyExists(creditCardProvider, creditCardProviderManager.Items))
                    throw new Exception("The [Major Industry Identifier] entered already exists.");
                
                creditCardProviderManager.Update(creditCardProvider);
                ViewData["SuccessMessage"] = "Credit Card Provider successfully updated.";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ViewData["Exception"] = exception.Message;
                return View(creditCardProvider);
            }
        }
        
        public IActionResult Delete(int id)
        {
            try
            {
                new CreditCardProviderManager().Remove(id);
                ViewData["SuccessMessage"] = "Credit Card Provider successfully deleted.";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ViewData["Exception"] = exception.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(CreditCardProvider creditCardProvider)
        {
            try
            {
                if (creditCardProvider.MajorIndustryIdentifier.ToString().Length != 1)
                    throw new Exception("The [Major Industry Identifier] must be one digit long.");
                
                var creditCardProviderManager = new CreditCardProviderManager();
                
                if (Validator.CheckIfCreditCardProviderNameAlreadyExists(creditCardProvider, creditCardProviderManager.Items))
                    throw new Exception("The [Name] entered already exists.");
                
                if (Validator.CheckIfMajorIndustryIdentifierAlreadyExists(creditCardProvider, creditCardProviderManager.Items))
                    throw new Exception("The [Major Industry Identifier] entered already exists.");
                
                creditCardProviderManager.Add(creditCardProvider);
                ViewData["SuccessMessage"] = "Credit Card Provider successfully added.";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ViewData["Exception"] = exception.Message;
                return View();
            }
        }
    }
}