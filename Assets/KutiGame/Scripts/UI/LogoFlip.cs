using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFlip : MonoBehaviour
{
    


    void Start()
    {

        // Event prerequisites
        Player_Movement player_Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        player_Movement.OnGravityChange += ChangeTurned;
    }

    private void ChangeTurned(bool turnedFromPlayer)
    {
        transform.eulerAngles = turnedFromPlayer ? new Vector3(0,0,180) : new Vector3(0,0,0);
    }
}
