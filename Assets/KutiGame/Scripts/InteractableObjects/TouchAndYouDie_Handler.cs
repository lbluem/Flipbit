using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchAndYouDie_Handler : MonoBehaviour
{

    // Handling the logic of the deadly spikes and the different enemies

    // collision with player 
    // kollision mit spieler 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerDies(other);
        }
    }

    private void PlayerDies(Collider2D player)
    {
        // If the player is not dying already
        if(!player.GetComponent<Player_Movement>().GetIsDying())
        {
            player.GetComponent<Animator>().SetTrigger("Dying");
            FindObjectOfType<AudioManager>().Play("PlayerHit");

            // One death counter persists through scenes,
            // but while testing in a scene that is not Level 1 it will be missing
            try{DeathCounter.instance.AddDeathCount();}
            catch (System.NullReferenceException)
            {
                Debug.LogWarning("TouchAndYouDie_Handler: No DeathCounter in this scene");
            }
            player.GetComponent<Player_Movement>().SetIsDying(true);
        }
        //Debug.Log("TouchAndYouDie_Handler: Player stepped on Spike");
    }
}
