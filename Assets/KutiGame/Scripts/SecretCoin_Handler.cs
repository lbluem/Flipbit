using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretCoin_Handler : MonoBehaviour
{
    // Has to be the child of a SecretLifter GameObject
    private Component secretScript;
    private SpriteRenderer coinSprite;
    private string coinID;

    void Start()
    {

        if(PlayerPrefs.GetInt(coinID,0)==1)
        {
            Destroy(gameObject);
        }else
        {
            Debug.Log("SecretCoin_Handler: PlayerPref ist "+PlayerPrefs.GetInt(coinID));
            secretScript = GetComponentInParent<SecretFinder>();
            coinSprite = GetComponent<SpriteRenderer>();
            coinID = "coinLevel"+(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("SecretCoin_Handler: CoinID ist "+coinID);

            coinSprite.color = new Color(1f,1f,1f,0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("CoinPickup");
            CoinCounter.instance.addCoinCount();
            PlayerPrefs.SetInt(coinID, 1);
            //Debug.Log("SecretCoin_Handler: +1 Point");
        }
    }

    public void makeVisible()
    {
        coinSprite.color = new Color(1f,1f,1f,1f);
    }
}
