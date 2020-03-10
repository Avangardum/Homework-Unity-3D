using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : TextButton
{
    [SerializeField] private string _sceneName;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(_sceneName));
    }
}
