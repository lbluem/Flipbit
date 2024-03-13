using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinBonusDecoration : MonoBehaviour
{
    // Has to be the child of a (BonusDecoration) Tilemap
    void Start()
    {
        if(!(PlayerPrefs.GetInt("coinCounter")>= 3))
        {
            GetComponentInParent<Tilemap>().color = new Color(1f,1f,1f,0f);
        }
    }
}
