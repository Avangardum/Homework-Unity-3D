using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Localization))]
public class LocalizationButton : MonoBehaviour
{
    private Localization _localization;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _localization = GetComponent<Localization>();
        GetComponent<Button>().onClick.AddListener(NextLanguage);
    }

    private void NextLanguage()
    {
        switch (_localization.Language)
        {
            case Language.English:
                _localization.Language = Language.Russian;
                _text.text = "EN";
                break;
            case Language.Russian:
                _localization.Language = Language.English;
                _text.text = "RU";
                break;
        }
    }
}
