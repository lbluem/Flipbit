using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapArea : MonoBehaviour
{

    // Could be changed manually through SerializeField, but will be automated later in the code
    // Könnte durch SerializeField händisch verändert werden, wird aber später im Code automatisiert
    private bool directionIsUp;
    private bool turned;
    public Animator anim;
    public Animator shockwave;


    void Start()
    { 
        turned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;

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

    // Update is called once per frame
    void Update()
    {
        turned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        //Debug.Log("SwapArea: Collider Entered");
        if(other.tag == "Player")
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
