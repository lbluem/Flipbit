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
        // Event prerequisites
        Player_Movement player_Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        player_Movement.OnGravityChange += ChangeTilemapAlpha;
        // Manual function call at the beginning of the Level
        ChangeTilemapAlpha(player_Movement.turned);
    }
    
    void ChangeTilemapAlpha(bool turned)
    {
        // 1f; 0f
        Color color = tilemap.color;
        color.a = turned ? 1f: 0f;
        tilemap.color = color;
    }
}
