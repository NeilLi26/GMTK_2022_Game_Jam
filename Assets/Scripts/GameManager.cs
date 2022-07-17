using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    public List<GameObject> Waves;
    public int waveCounter = 0;
    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (waveCounter > Waves.Count)
        {
            // TODO: implement transition to next scene after all waves on current scene has run out
            //Debug.Log("Finished waves");
            SceneManager.LoadScene(nextSceneName);
        } else if (enemyCount == 0)
        {
            /*
            Debug.Log("Wave number" + waveCounter);
            Debug.Log("Wave total" + Waves.Count);
            */
            Waves[waveCounter++].SetActive(true);
        }
        
    }
}
