using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailButton : LinkButton
{
    protected override string fullLink => GetFullLink();

    string GetFullLink()
    {
        string email = "zhengyi.hu.98@gmail.com";
        string subject = MyEscapeURL("Contact From Portfolio");
        string body = MyEscapeURL("");
        return "mailto:" + email + "?subject=" + subject + "&body=" + body;
    }

    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }
}
