using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike_handler : MonoBehaviour
{
    //spike collision with player handler
    //spike kollision mit spieler 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerDies(other);
            //DeathCounter.instance.addDeathCount();
            
            //dC.GetComponent<DeathCounter>().addDeathCount();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }

    private void PlayerDies(Collider2D player)
    {
        //player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<Animator>().SetTrigger("Dying");
        FindObjectOfType<AudioManager>().Play("PlayerHit");
        Debug.Log("Spike Handler: Player stepped on Spike");
    }
}
