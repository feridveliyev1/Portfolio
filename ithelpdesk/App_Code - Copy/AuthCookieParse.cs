using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for AuthCookieParse
/// </summary>
public class AuthCookieParse
{

    public static int UserID()
    {
        string UserString = HttpContext.Current.User.Identity.Name;
        if (UserString.Length != 0)
        {
            Regex Regul = new Regex(@"\||\|");
            return Convert.ToInt32(Regul.Split(UserString)[0]);
        }
        else
            return -1;
    }


    public static string UserLogin()
    {
        string UserString = HttpContext.Current.User.Identity.Name;
        if (UserString.Length != 0)
        {
            Regex Regul = new Regex(@"\||\|");
            return Regul.Split(UserString)[2];
        }
        else
            return "not found";
    }

    public static string UserFIO()
    {
        string UserString = HttpContext.Current.User.Identity.Name;
        if (UserString.Length != 0)
        {
            Regex Regul = new Regex(@"\||\|");
            return Regul.Split(UserString)[1];
        }
        else
            return "not found";
    }

    public static string UserStatus()
    {
        string UserString = HttpContext.Current.User.Identity.Name;
        if (UserString.Length != 0)
        {
            Regex Regul = new Regex(@"\||\|");
            return Regul.Split(UserString)[3];
        }
        else
            return "";
    }

    public static string UserPhoneNumber()
    {
        string UserString = HttpContext.Current.User.Identity.Name;
        if (UserString.Length != 0)
        {
            Regex Regul = new Regex(@"\||\|");
            return Regul.Split(UserString)[4];
        }
        else
            return "";
    }
    public static string UserLanguage()
    {
        string UserString = HttpContext.Current.User.Identity.Name;
        if (UserString.Length != 0)
        {
            Regex Regul = new Regex(@"\||\|");
            return Regul.Split(UserString)[5];
        }
        else
            return "not found";
    }
}
