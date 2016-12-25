using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for ValidataionClass
/// </summary>
public class ValidataionClass
{
    public const String Emailpattern =
                   @"^([0-9a-zA-Z]" + //Start with a digit or alphabet
                   @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continues or ending +-_. chars in email
                   @")+" + @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";
    public const String name =
                   @"^([0-9a-zA-Z])$" ;//Start with a digit or alphabet
                  
    public bool checkValidation(string InputBox)
    {
        bool isValid = true;
        if (InputBox.Trim() == "")
        {
            isValid = false;
        }
        return isValid;
    }


    public bool isAlldigit(string inputbox)
    {
        return inputbox.All(Char.IsNumber);
    }

    public bool checkemail(string Inputbox) {
        bool isValid = true;
        isValid = Regex.Match(Inputbox, Emailpattern).Success;
        if (!isValid) {
            isValid = false;
        }
        return isValid;
    }
    public bool checkname(string Inputbox) {
        bool isValid = true;
        isValid = Regex.Match(Inputbox, name).Success;
        if (!isValid) {
            isValid = false;
        }
        return isValid;
    }
}