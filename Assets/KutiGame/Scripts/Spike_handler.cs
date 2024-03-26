using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike_handler : MonoBehaviour
{

    // Handling the logic of the deadly spikes

    // Only able to die once before Scene resets
    //public bool waitForAnimation = false;

    //spike collision with player handler
    //spike kollision mit spieler 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerDies(other);
        }
    }

    private void PlayerDies(Collider2D player)
    {
        if(!player.GetComponent<Player_Movement>().GetIsDying())
        {
            player.GetComponent<Animator>().SetTrigger("Dying");
            FindObjectOfType<AudioManager>().Play("PlayerHit");

            try{DeathCounter.instance.AddDeathCount();}
            catch (System.NullReferenceException)
            {
                Debug.LogWarning("Spike_Handler: No DeathCounter in this scene");
            }
            player.GetComponent<Player_Movement>().SetIsDying(true);
        }
        //Debug.Log("Spike Handler: Player stepped on Spike");
    }
}
