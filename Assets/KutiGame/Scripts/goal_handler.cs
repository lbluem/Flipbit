using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal_handler : MonoBehaviour
{
    [SerializeField]
    private string NextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<AudioManager>().Play("PlayerPickup");
        SceneManager.LoadScene(NextLevelName, LoadSceneMode.Single);
        //print("hello world");
    }
}
