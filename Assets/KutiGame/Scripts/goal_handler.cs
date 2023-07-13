using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal_handler : MonoBehaviour
{
    [SerializeField] private string NextLevelName;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Start Coroutine and Animation
        if(other.gameObject.tag == "Player")
        {
            if(!start){
                FindObjectOfType<AudioManager>().Play("PlayerPickup");
                doorAnimator.SetTrigger("Opening");
                StartCoroutine(SceneEndTimer(transitionTime));
            }
        }
    }

    private IEnumerator SceneEndTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(NextLevelName, LoadSceneMode.Single);        
    }

}
