using UnityEngine;
using UnityEngine.UI;

public class ExitButton : TextButton
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Application.Quit);
    }
}
