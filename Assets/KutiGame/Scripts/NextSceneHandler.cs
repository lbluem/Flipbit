using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneHandler : MonoBehaviour
{

    //public int LevelToLoad;
    [SerializeField] private bool restartToLevel1;
    //[SerializeField] private Collider2D nextLevelZone;

    public Animator transition;
    public float transitionTime = 1f;
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // lädt Level Szene die im Editor angegeben ist
            //SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Single);
            
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if(!restartToLevel1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }else
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
                DeathCounter.instance.resetDeathCount();

            }
    }
}
