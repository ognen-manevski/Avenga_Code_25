using System.Text.RegularExpressions;
using TimeTrackingApp.Helpers.Results;

namespace TimeTrackingApp.Helpers;

public static class ValidationHelper
{
    //===============================
    // USER - account creation
    //===============================


    //Username should not be shorter than 5 characters
    //returns a result object with validation result and ERROR MESSAGE if invalid
    public static ValidationResult ValidateUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return new ValidationResult(false, "Username cannot be empty.");
        }

        if (username.Length < 5)
        {
            return new ValidationResult(false, "Username must be at least 5 characters long.");
        }

        return new ValidationResult(true, string.Empty);
    }


    //Password should not be shorter than 6 characters
    //BONUS: Password should contain at least one capital letter
    //BONUS: Password should contain at least one number
    public static ValidationResult ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return new ValidationResult(false, "Password cannot be empty.");
        }

        if (password.Length < 6)
        {
            return new ValidationResult(false, "Password must be at least 6 characters long.");
        }

        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            return new ValidationResult(false, "Password must contain at least one uppercase letter.");
        }

        if (!Regex.IsMatch(password, @"\d"))
        {
            return new ValidationResult(false, "Password must contain at least one number.");
        }

        return new ValidationResult(true, string.Empty);
    }

    //First Name and Last Name should not be shorter than 2 characters
    public static ValidationResult ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return new ValidationResult(false, "Name cannot be empty.");
        }

        if (name.Length < 2)
        {
            return new ValidationResult(false, "Name must be at least 2 characters long.");
        }

        if (Regex.IsMatch(name, @"\d"))
        {
            return new ValidationResult(false, "Name cannot contain numbers.");
        }

        return new ValidationResult(true, string.Empty);
    }

    //Age should not be less than 18 years or over 120
    public static ValidationResult ValidateAge(int age)
    {
        if (age < 18)
        {
            return new ValidationResult(false, "You must be at least 18 years old to register.");
        }

        if (age > 120)
        {
            return new ValidationResult(false, "Age cannot be greater than 120 years.");
        }

        return new ValidationResult(true, string.Empty);
    }

    //===============================
    // MENU INT INPUT VALIDATION
    //===============================

    public static ValidationResult ValidateMenuInput(string input, int min, int max)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return new ValidationResult(false, "Input cannot be empty.");
        }

        bool tryChoice = int.TryParse(input, out int choice);

        if (!tryChoice)
        {
            return new ValidationResult(false, "Please enter a valid number.");
        }

        if (choice < min || choice > max)
        {
            return new ValidationResult(false, $"Please enter a number between {min} and {max}.");
        }

        return new ValidationResult(true, string.Empty);
    }
}
