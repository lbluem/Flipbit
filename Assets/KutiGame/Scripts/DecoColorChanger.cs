using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DecoColorChanger : MonoBehaviour
{

    private Tilemap sprite;
    bool gravityTurned;
    public Color player1Color;
    public Color player2Color;

    // Für die animierten Elemente
    // For the animated elements
    public delegate void ChangeSpriteColorDelegate(Color newColor);
    public event ChangeSpriteColorDelegate OnColorChange;

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
                OnColorChange?.Invoke(player2Color);
            }else
            {
                sprite.color = player1Color;
                OnColorChange?.Invoke(player1Color);
            }
    }
}
