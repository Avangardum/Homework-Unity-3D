using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    private Language _language;

    public Language Language
    {
        get => _language;
        set
        {
            _language = value;
            var buttons = FindObjectsOfType<TextButton>();
            foreach (var button in buttons)
                button.SetLanguage(_language);
        }
    }

    private void Awake()
    {
        Language = Language.English;
    }

    
}
