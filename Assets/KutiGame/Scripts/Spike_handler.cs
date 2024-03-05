using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike_handler : MonoBehaviour
{

    // Only able to die once before Scene resets
    public bool waitForAnimation = false;

    //spike collision with player handler
    //spike kollision mit spieler 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerDies(other);
        }
    }

    private void PlayerDies(Collider2D player)
    {
        if(!waitForAnimation)
        {
            player.GetComponent<Animator>().SetTrigger("Dying");
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            DeathCounter.instance.addDeathCount();
            waitForAnimation = true;
        }
        //Debug.Log("Spike Handler: Player stepped on Spike");
    }
}
