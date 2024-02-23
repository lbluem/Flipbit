﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DecoColorChanger : MonoBehaviour
{

    private Tilemap sprite;
    bool gravityTurned;
    public Color player1Color;
    public Color player2Color;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Tilemap>();
        gravityTurned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;
        ChangeSpriteColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(gravityTurned != GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned)
        {
            ChangeSpriteColor();
        } 
    }

    void ChangeSpriteColor()
    {
        gravityTurned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;
            if(gravityTurned)
            {
                sprite.color = player2Color;
            }else
            {
                sprite.color = player1Color;
            }
    }
}
