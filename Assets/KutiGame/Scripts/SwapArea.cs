using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapArea : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("PlayerTurn");
            other.GetComponent<Player_Movement>().GravityTurn();
        }
    }

}
