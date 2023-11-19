using Microsoft.AspNetCore.Mvc;
using AspNetMVC.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class RegistrationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public string Registration(RegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            return $"Дані пройшли валідацію:\nІм'я Користувача - {model.Name}\nЕлектронна адреса - {model.Email}\nДата реєстрації - {model.RegistrationDate}\nОбраний продукт - {model.SelectedProduct}";
        }

        string errorMessages = "";
        foreach (var item in ModelState)
        {
            if (item.Value.ValidationState == ModelValidationState.Invalid)
            {
                errorMessages = $"{errorMessages}\nПомилки властивості {item.Key}:\n";

                foreach (var error in item.Value.Errors)
                {
                    errorMessages = $"{errorMessages}{error.ErrorMessage}\n";
                }
            }
        }
            return errorMessages;
    }
}