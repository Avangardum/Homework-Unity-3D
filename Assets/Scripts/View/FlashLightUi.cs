using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class FlashLightUi : MonoBehaviour
    {
        [SerializeField] private Color _enabled;
        [SerializeField] private Color _disabled;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void SetFillAmount(float percentage)
        {
            _image.fillAmount = percentage;
        }

        public void ToggleFlashlightActiveness(bool value)
        {
            if (value)
                _image.color = _enabled;
            else
                _image.color = _disabled;
        }

        public void SetActive(bool value)
        {
            _image.gameObject.SetActive(value);
        }
    }
}
