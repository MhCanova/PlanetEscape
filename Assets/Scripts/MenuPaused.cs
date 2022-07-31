using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPaused : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuCanvas;
    [SerializeField] Canvas notificationCanvas;
    [SerializeField] Canvas controllsCanvas;

    void Awake() 
    {
        pauseMenuCanvas.enabled = false;
        controllsCanvas.enabled = false;
    }
    void Start()
    {
        StartCoroutine(notificationPopup());
    }
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        
    }

    void GoMainMenu()
    {
        PauseService.UnPause();
        SceneManager.LoadScene(0);
    }

    void ControllsMenuButton()
    {
        pauseMenuCanvas.enabled = false;
        controllsCanvas.enabled = true;
    }

    void ControllsBackButton()
    {
        controllsCanvas.enabled = false;
        pauseMenuCanvas.enabled = true;
    }

    void PauseGame()
    {
        pauseMenuCanvas.enabled = true;
        controllsCanvas.enabled = false;
        notificationCanvas.enabled = false;
        PauseService.Pause();
    }

    void ContinueGame()
    {
        pauseMenuCanvas.enabled = false;
        PauseService.UnPause();
    }

    IEnumerator notificationPopup()
    {
        yield return new WaitForSeconds (5);
        notificationCanvas.enabled = false;
    }
    
}
