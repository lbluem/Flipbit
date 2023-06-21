using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startscreen_handler : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;

    private GameObject playerObject;
    private GameObject [] uiButtons;
    private bool player_1 = false;
    private bool player_2 = false;

    void Start() {
        playerObject = GameObject.Find("Player");
        playerObject.GetComponent<Player_Movement>().enabled = false;

        uiButtons = GameObject.FindGameObjectsWithTag("UIButton");
    }

    void Update (){
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

        if(player_1 && player_2){
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
            playerObject.GetComponent<Player_Movement>().enabled = true;
            Destroy(GameObject.Find("StartScreen"), 2);
        }
    }


}
