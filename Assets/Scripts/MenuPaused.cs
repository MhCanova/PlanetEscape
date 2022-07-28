using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPaused : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuCanvas;

    void Start()
    {
        pauseMenuCanvas.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You quit the game");
    }

    public void PauseGame()
    {
        pauseMenuCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinueGame()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1;
    }

    
}
