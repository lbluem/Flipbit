using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class BoundaryColorChanger : MonoBehaviour
{

    public Player_Movement playerMovement;
    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement != null && tilemap != null)
        {
            if (playerMovement.turned)
            {
                ChangeTilemapAlpha(1f); // Set alpha to 1
            }
            else
            {
                ChangeTilemapAlpha(0f); // Set alpha to 0
            }
        }
    }

    void ChangeTilemapAlpha(float alpha)
    {
        Color color = tilemap.color;
        color.a = alpha;
        tilemap.color = color;
    }
}
