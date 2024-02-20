using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal_handler : MonoBehaviour
{
    // Name of the next level to load
    // Name des nächsten Levels, das geladen werden soll
    [SerializeField] private string NextLevelName;
    // Time taken for transition to the next level
    // Zeit für den Übergang zum nächsten Level
    [SerializeField] private float transitionTime = 2;
    [SerializeField] private bool start;
    private Animator doorAnimator;
    [SerializeField] private Animator dialogueAnimator;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        
        if(start)
        {
            doorAnimator.SetTrigger("Closing");
        }else
        {
            dialogueAnimator.SetTrigger("Dialogue");
        }
    }

    // Start Coroutine and Animation when the player enters the trigger area
    // Startet die Coroutine und die Animation, wenn der Spieler den Triggerbereich betritt
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!start){
                FindObjectOfType<AudioManager>().Play("PlayerPickup");
                doorAnimator.SetTrigger("Opening");
                StartCoroutine(SceneEndTimer(transitionTime));
            }
        }
    }

    // Coroutine for delaying scene transition
    // Coroutine für Verzögern des Szenenübergangs
    private IEnumerator SceneEndTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(NextLevelName, LoadSceneMode.Single);        
    }

}
