using AspNetCoreRegistrationForm.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

public class RegistrationModel
{
    [Required(ErrorMessage = "User name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email doesn`t exists")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Registration date is required")]
    [DataType(DataType.Date)]
    [FutureDate(ErrorMessage = "Please select a date in the future")]
    [NotOnMonday(ErrorMessage = "Please choose a date that is not a Weekend ")]
    public DateTime RegistrationDate { get; set; }

    [Required(ErrorMessage = "Product not selected")]
    public string SelectedProduct { get; set; }
}