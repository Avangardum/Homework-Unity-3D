using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public bool IsPaused { get; private set; }

    private GameObject _pauseMenu;

    private void Awake()
    {
        _pauseMenu = Object.FindObjectOfType<PauseMenu>().gameObject;
        Unpause();
    }

    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        IsPaused = false;
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }

    public void Switch()
    {
        if (IsPaused)
            Unpause();
        else
            Pause();
    }
}
