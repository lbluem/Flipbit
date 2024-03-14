using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DecoColorChanger : MonoBehaviour
{
    // Changing decoration Color on Player Change
    // Is part of a tilemap
    // ist Teil von einer Tilemap
    
    private Tilemap sprite;
    bool gravityTurned;
    public Color player1Color;
    public Color player2Color;

    // Event for the animated elements
    // Event für die animierten Elemente
    public delegate void ChangeSpriteColorDelegate(Color newColor);
    public event ChangeSpriteColorDelegate OnColorChange;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Tilemap>();

        // Event prerequisites
        Player_Movement player_Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        player_Movement.OnGravityChange += ChangeSpriteColor;
        // Manual function call at the beginning of the Level
        ChangeSpriteColor(player_Movement.turned);
    }

    // Triggered once at the start of the Level and then as an Event
    // everytime the Player changes
    void ChangeSpriteColor(bool turnedFromPlayer)
    {
        gravityTurned = turnedFromPlayer;
        //gravityTurned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;
            if(gravityTurned)
            {
                sprite.color = player2Color;
                OnColorChange?.Invoke(player2Color);
            }else
            {
                sprite.color = player1Color;
                OnColorChange?.Invoke(player1Color);
            }
    }
}
