using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    [SerializeField] Canvas startMenuCanvas;
    [SerializeField] Canvas controllsCanvas;

    void Awake()
    {
        startMenuCanvas.enabled = true;
        controllsCanvas.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You quit the game");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ControllsMenuButton()
    {
        startMenuCanvas.enabled = false;
        controllsCanvas.enabled = true;
    }

    public void ControllsBackButton()
    {
        controllsCanvas.enabled = false;
        startMenuCanvas.enabled = true;
    }
}
