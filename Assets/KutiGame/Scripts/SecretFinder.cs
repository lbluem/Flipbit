using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretFinder : MonoBehaviour
{
    // SecretLifter GameObject has to be the child of a SecretPath Tilemap
    private Tilemap secretTilemap;

    private void Start() 
    {
        secretTilemap = GetComponentInParent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            secretTilemap.color = new Color(1f,1f,1f,0.2f);
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            secretTilemap.color = new Color(1f,1f,1f,1f);
        }  
    }
}
