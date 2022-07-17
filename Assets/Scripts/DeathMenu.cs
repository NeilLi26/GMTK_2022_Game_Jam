using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    [SerializeField] GameObject deathMenu;


    public void Pause() {
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TryAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
