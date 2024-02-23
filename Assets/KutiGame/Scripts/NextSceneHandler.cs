using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneHandler : MonoBehaviour
{

    //public int LevelToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // lädt Level Szene die im Editor angegeben ist
            //SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Single);
            
            // lädt nächste Szene nach Build Index
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
    }
}
