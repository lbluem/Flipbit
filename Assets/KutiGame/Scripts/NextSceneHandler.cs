using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneHandler : MonoBehaviour
{
    // Part of a simple Collider as a trigger transitioning to the next level

    public Animator transition;
    public float transitionTime = 1f;
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {            
            StartCoroutine(LoadLevel());
        }
    }

    // Waits for the Level transition Animation
    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}
