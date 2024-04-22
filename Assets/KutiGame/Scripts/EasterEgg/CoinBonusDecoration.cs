using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinBonusDecoration : MonoBehaviour
{
    // Has to be the child of a (BonusDecoration) Tilemap
    // Is activated if the player activated the DevTool
    // ~~If the players found all the coins there will be bonus decoration in the end level~~ ← original idea
    void Start()
    {
        GetComponentInParent<Tilemap>().color = new Color(1f,1f,1f,0f);
        if(CoinCounter.instance.GetCoinCount()>=1)
        {
            GetComponentInParent<Tilemap>().color = new Color(1f,1f,1f,1f);
        }
    }
}
