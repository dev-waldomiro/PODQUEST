using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
public string nextScene;
    public static bool isPaused;
    public GameObject pauseMenuUI;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }
    
    public void changeScene () {
        SceneManager.LoadScene(nextScene);
        /*if(nextScene == "FASE01") FindObjectOfType<AudioManager>().Play("Starting");
        else FindObjectOfType<AudioManager>().Play("ButtonPress");*/
    }

    public void quitApplication () {
        Application.Quit();
        //FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        //FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        //FindObjectOfType<AudioManager>().Play("ButtonPress");
    }
}
