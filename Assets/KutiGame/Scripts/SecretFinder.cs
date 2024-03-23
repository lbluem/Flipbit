using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretFinder : MonoBehaviour
{
    // SecretLifter GameObject has to be the child of a SecretPath tilemap
    // If player walks into this wall it gets transparent

    private Tilemap secretTilemap;
    private DecoColorChanger colorChangerFromParent;
    private Color thisColor;

    // also changes the correspondent coin to make it visible
    [SerializeField] private SecretCoin_Handler thisCoin;

    private void Start() 
    {
        secretTilemap = GetComponentInParent<Tilemap>();
        colorChangerFromParent = GetComponentInParent<DecoColorChanger>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            //secretTilemap.color = new Color(1f,1f,1f,0.2f);
            thisColor = secretTilemap.color;
            thisColor.a = 0.2f;
            secretTilemap.color = thisColor;
            
            if(thisCoin != null)
            {
                thisCoin.MakeVisible();
            }
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            thisColor = secretTilemap.color;
            thisColor.a = 0.7843137f;
            secretTilemap.color = thisColor;
            //secretTilemap.color = new Color(1f,1f,1f,1f);
        }  
    }
}
