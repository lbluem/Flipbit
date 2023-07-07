using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal_handler : MonoBehaviour
{
    [SerializeField]
    private string NextLevelName;
    [SerializeField] private float transitionTime = 2;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Start Coroutine and Animation
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("PlayerPickup");
            _animator.SetTrigger("Opening");
            StartCoroutine(SceneEndTimer(transitionTime));
        }
    }

    private IEnumerator SceneEndTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(NextLevelName, LoadSceneMode.Single);        
    }

}
