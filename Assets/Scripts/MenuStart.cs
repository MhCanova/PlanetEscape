using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    [SerializeField] Canvas startMenuCanvas;

    void Start()
    {
        startMenuCanvas.enabled = true;
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
}
