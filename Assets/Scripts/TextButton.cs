using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public abstract class TextButton : MonoBehaviour
{
    [SerializeField] private string _textEN;
    [SerializeField] private string _textRU;

    private TextMeshProUGUI _text;

    private bool _textInitialized = false;

    public void SetLanguage(Language language)
    {
        if (!_textInitialized)
        {
            InitializeText();
        }
        switch (language)
        {
            case Language.English:
                _text.text = _textEN;
                break;
            case Language.Russian:
                _text.text = _textRU;
                break;
        }
    }

    private void Awake()
    {
        if(!_textInitialized)
        {
            InitializeText();
        }
    }

    private void InitializeText()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _textInitialized = true;
    }
}
