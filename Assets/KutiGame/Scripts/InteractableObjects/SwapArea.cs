using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapArea : MonoBehaviour
{

    // Handling the logic of the SwapPads (springs)

    // Could be changed manually through SerializeField, but will be automated later in the code
    // Könnte durch SerializeField händisch verändert werden, wird aber später im Code automatisiert
    private bool directionIsUp;
    private bool turned;
    public Animator anim;
    public Animator shockwave;


    void Start()
    { 
        // Event prerequisites
        Player_Movement player_Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        player_Movement.OnGravityChange += ChangeTurned;
        // Manual function call at the beginning of the Level
        ChangeTurned(player_Movement.turned);

        // Depending on the rotation of the spring, it only works in one direction
        // Je nach Rotation der Sprungfeder funktioniert sie nur in eine Richtung
        if(transform.parent.transform.rotation.eulerAngles.z == 180)
        {
            directionIsUp = false;
        }else
        {
            directionIsUp = true;
        }
    }

    // Triggered once at the start of the Level and then as an Event
    // everytime the Player changes
    private void ChangeTurned(bool turnedFromPlayer)
    {
        turned = turnedFromPlayer;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        //Debug.Log("SwapArea: Collider Entered");
        if(other.CompareTag("Player"))
        {
            //Debug.Log("SwapArea: Player Entered");
            if((directionIsUp && !turned)||!directionIsUp && turned)
            {
                //Debug.Log("SwapArea: Player Swapped");
                FindObjectOfType<AudioManager>().Play("PlayerTurn");
                other.GetComponent<Player_Movement>().GravityTurn();
                anim.SetTrigger("jumpedOn");

                // sieht momentan nicht so gut aus und pro Sprungfeder
                // spielt die Animation auch nur einmal aus
                //shockwave.SetTrigger("wave");

                
            }             
        }
    }
}
