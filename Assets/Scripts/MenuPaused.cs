using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPaused : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuCanvas;
    [SerializeField] Canvas notificationCanvas;

    void Awake() 
    {
        pauseMenuCanvas.enabled = false;
    }
    void Start()
    {
        StartCoroutine(notificationPopup());
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        pauseMenuCanvas.enabled = true;
        notificationCanvas.enabled = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinueGame()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1;
    }

    IEnumerator notificationPopup()
    {
        yield return new WaitForSeconds (5);
        notificationCanvas.enabled = false;
    }

}
