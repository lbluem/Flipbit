using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CoinCounter : MonoBehaviour
{

     // Managing the PlayerPref CoinCounter
     
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

   public void AddCoinCount(string foundCoinID)
   {
        coinCounter++;
        UpdateCoinCount();
        Debug.Log("CoinCounter: "+PlayerPrefs.GetInt("coinCounter"));

        // Sets specific CoinID as "found"
        PlayerPrefs.SetInt(foundCoinID, 1);
   }

   public void ResetCoins()
   {
        coinCounter = 0;
        UpdateCoinCount();
        Debug.Log("CoinCounter: Reset");
        
        // Sets all CoinID's as "not found"
        PlayerPrefs.SetInt("coinLevel3",0);
        PlayerPrefs.SetInt("coinLevel8",0);
        PlayerPrefs.SetInt("coinLevel10",0);
   }

   private void UpdateCoinCount()
   {
        PlayerPrefs.SetInt("coinCounter", coinCounter);
   }

   public int GetCoinCount()
   {
     return PlayerPrefs.GetInt("coinCounter");
   }
}
