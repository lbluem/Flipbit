using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCoin_Handler : MonoBehaviour
{
    // Has to be the child of a SecretLifter GameObject
    private Component secretScript;
    private SpriteRenderer coinSprite;

    void Start()
    {
        secretScript = GetComponentInParent<SecretFinder>();
        coinSprite = GetComponent<SpriteRenderer>();

        coinSprite.color = new Color(1f,1f,1f,0f);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("CoinPickup");
            CoinCounter.instance.addCoinCount();
            //Debug.Log("SecretCoin_Handler: +1 Point");
        }
    }

    public void makeVisible()
    {
        coinSprite.color = new Color(1f,1f,1f,1f);
    }
}
