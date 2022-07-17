using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    private bool pauseMenuOn;

    void Start() {
        pauseMenuOn = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pauseMenuOn) {
                Pause();
            } else {
                Resume();
            }
        }
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseMenuOn = true;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseMenuOn = false;
    }

    public void Home(int sceneID) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        pauseMenuOn = false;
    }
}
