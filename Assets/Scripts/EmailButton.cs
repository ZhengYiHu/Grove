using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailButton : LinkButton
{
    [SerializeField] string email = "zhengyi.hu.98@gmail.com";
    [SerializeField] string subject = "Question % 20on%20Awesome%20Game";

    protected override string fullLink => GetFullLink();

    string GetFullLink()
    {
        return $"mailto:{email}?subject={subject}";
    }
}
