using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spike_handler : MonoBehaviour
{
    //[SerializeField] private Component dC;
    private string thisScene;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        thisScene = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            DeathCounter.instance.addDeathCount();
            Debug.Log("I DIED");
            //dC.GetComponent<DeathCounter>().addDeathCount();
            SceneManager.LoadScene(thisScene, LoadSceneMode.Single);
        }
    }
}
