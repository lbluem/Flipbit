using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CoinCounter : MonoBehaviour
{

    public static CoinCounter instance;
    private int coinCounter = 0;
 
    private void Awake() 
    {
        instance = this;
    }

    private void Start()
    {
        coinCounter = PlayerPrefs.GetInt("coinCounter");
    }

   public void addCoinCount()
   {
        coinCounter++;
        updateCoinCount();
        Debug.Log("CoinCounter: "+PlayerPrefs.GetInt("coinCounter"));
   }

   public void resetCoinCount()
   {
        coinCounter = 0;
        updateCoinCount();
        Debug.Log("CoinCounter: Reset");
   }

   private void updateCoinCount()
   {
        PlayerPrefs.SetInt("coinCounter", coinCounter);
   }
}
