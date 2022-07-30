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
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        
    }

    public void GoMainMenu()
    {
        PauseService.UnPause();
        SceneManager.LoadScene(0);
    }

    void PauseGame()
    {
        pauseMenuCanvas.enabled = true;
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
