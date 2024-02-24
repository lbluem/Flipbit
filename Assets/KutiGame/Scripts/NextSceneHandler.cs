using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneHandler : MonoBehaviour
{

    //public int LevelToLoad;
    [SerializeField] private bool restartToLevel1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // lädt Level Szene die im Editor angegeben ist
            //SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Single);
            
            // lädt nächste Szene nach Build Index
            if(!restartToLevel1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }else
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);

            }
        }
    }
}
