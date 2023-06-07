using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startscreen_handler : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;

    private GameObject temp;
    private bool player_1 = false;
    private bool player_2 = false;

    void Start() {
        temp = GameObject.Find("Player");
        temp.GetComponent<Player_Movement>().enabled = false;
    }

    void Update (){
        if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID)){
            player_1 = !player_1;
        }else if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID)){
            player_2 = !player_2;
        }

        if(player_1 && player_2){
            if(myUIGroup.alpha >= 0){
                myUIGroup.alpha -= Time.deltaTime;
            }
            temp.GetComponent<Player_Movement>().enabled = true;
        }
    }

}
