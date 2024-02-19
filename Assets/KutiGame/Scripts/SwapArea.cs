using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapArea : MonoBehaviour
{
    [SerializeField] private bool directionIsUp;
    private bool turned;


    // Start is called before the first frame update

    void Start()
    { 
        turned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;
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
                Debug.Log("SwapArea: Player Swapped");
                FindObjectOfType<AudioManager>().Play("PlayerTurn");
                other.GetComponent<Player_Movement>().GravityTurn();
            } /* else if(!directionIsUp && turned)
            {
                FindObjectOfType<AudioManager>().Play("PlayerTurn");
                other.GetComponent<Player_Movement>().GravityTurn();
            } */

            
        }
    }

    /* private void OnTriggerEnter2D(TilemapCollider2D other) {
        
        if(other.tag == "Player")
        {
            if((directionIsUp && !turned)||!directionIsUp && turned)
            {
                FindObjectOfType<AudioManager>().Play("PlayerTurn");
                other.GetComponent<Player_Movement>().GravityTurn();
            }

            
        }
    } */
}
