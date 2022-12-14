using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.5f;
    [SerializeField] AudioClip sucess;
    [SerializeField] AudioClip crash;
    [SerializeField] GameObject successCanvas;
    [SerializeField] GameObject followCam;

    [SerializeField] ParticleSystem sucessParticles;
    [SerializeField] ParticleSystem crashParticles;


    AudioSource audioSource;
    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        successCanvas.SetActive(false);
        followCam.SetActive(true);
    }

    void Update()
    {
        //RespondToDebugKeys();
    }

    /*void RespondToDebugKeys()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadNextLevel();
            }
            else if(Input.GetKeyDown(KeyCode.C))
            {
                collisionDisabled = !collisionDisabled; // toggle collision bool
            }
        }*/
    
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionDisabled) { return; }
        
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartFinishSequence();
                break;
            case "Success":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartFinishSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(sucess);
        sucessParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
        followCam.SetActive(false);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(sucess);
        sucessParticles.Play();
        GetComponent<Movement>().enabled = false;
        successCanvas.SetActive(true);
        followCam.SetActive(false);
    }

    void StartCrashSequence()
{
    isTransitioning = true;
    audioSource.Stop();
    audioSource.PlayOneShot(crash);
    crashParticles.Play();
    GetComponent<Movement>().enabled = false;
    followCam.SetActive(false);
    Invoke("ReloadLevel", levelLoadDelay);
}

void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
