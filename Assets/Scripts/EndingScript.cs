using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    [SerializeField] GameObject endingMenu;

    public void Home(int sceneID) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
