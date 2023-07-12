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

        if(other.tag == "Player")
        {
            if((directionIsUp && !turned)||!directionIsUp && turned)
            {
                FindObjectOfType<AudioManager>().Play("PlayerTurn");
                other.GetComponent<Player_Movement>().GravityTurn();
            } /* else if(!directionIsUp && turned)
            {
                FindObjectOfType<AudioManager>().Play("PlayerTurn");
                other.GetComponent<Player_Movement>().GravityTurn();
            } */

            
        }
    }
}
