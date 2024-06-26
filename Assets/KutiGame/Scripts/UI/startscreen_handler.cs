﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq; // Hinzugefügter Namespace für LINQ

public class Startscreen_Handler : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;

    private GameObject playerObject;
    private GameObject [] uiButtons;
    private bool player_1 = false;
    private bool player_2 = false;

    private bool playSound;


    void Start() {

        playSound = true;
        if(DeathCounter.instance != null)
        {
            DeathCounter.instance.ResetDeathCount();
            Debug.Log("startscreen_handler: Death Counter resetted");
        }

        // Resetting coins
        CoinCounter.instance.ResetCoins();
        
        uiButtons = GameObject.FindGameObjectsWithTag("UIButton");


        
    }

    void Update (){

        if(uiButtons != null)
        {
            if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID)){
                player_1 = true;
                foreach (GameObject button in uiButtons)
                {
                    /* if(button.name == "button_p1_up"){
                    button.GetComponent<SpriteRenderer>().color = Color.green;
                    } */
                    
                }
            }else if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID)){
                player_2 = true;
                foreach (GameObject button in uiButtons)
                {
                    /* if(button.name == "button_p2_up"){
                    button.GetComponent<SpriteRenderer>().color = Color.green;
                    } */
                    
                }
            }

            if(player_1 || player_2){
                if(myUIGroup.alpha >= 0){
                    myUIGroup.alpha -= Time.deltaTime;
                }
                foreach (GameObject button in uiButtons)
                {
                    Color colorTmp = button.GetComponent<SpriteRenderer>().color;
                    if(colorTmp.a >= 0){
                        colorTmp.a -= Time.deltaTime;
                        button.GetComponent<SpriteRenderer>().color = colorTmp;
                    }
                }
                //playerObject.GetComponent<Player_Movement>().enabled = true;
                Destroy(GameObject.Find("StartScreen"), 2);

                // Diese If Abfrage wird trotzdem sie zerstört wurde immer noch unzählige male
                // ausgeführt, d.h. ich kann keinen Sound abspielen da auch dieser dann
                // bis zu tausende male abgespielt wird
                if (playSound)
                {
                    //FindObjectOfType<AudioManager>().Play("MenuButton");
                    playSound = false;
                }

            }
        }
    }

}
