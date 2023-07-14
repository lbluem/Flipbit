﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    public static DeathCounter instance;
    // eig kein Death Counter sondern VERSUCHs Counter deswegen Start bei 1
    private int deathCounter = 1;

    public TextMeshProUGUI deathCounterLabel_P1;
    public TextMeshProUGUI deathCounterLabel_P2;

    private void Awake() {
        instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {
        deathCounter = PlayerPrefs.GetInt("deathCounter");

        if(deathCounterLabel_P1 != null)
        {
            deathCounterLabel_P1.SetText("Ihr habt nur "+ deathCounter +" Versuche gebraucht");
            deathCounterLabel_P2.SetText("Ihr habt nur "+ deathCounter +" Versuche gebraucht");
        }
    }

    public void addDeathCount()
    {
        deathCounter++;
        PlayerPrefs.SetInt("deathCounter", deathCounter);

        if(deathCounterLabel_P1 != null)
        {
            deathCounterLabel_P1.SetText("Ihr habt nur "+ deathCounter +" Versuche gebraucht");
            deathCounterLabel_P2.SetText("Ihr habt nur "+ deathCounter +" Versuche gebraucht");
        }else
        Debug.Log(deathCounter);
    }

    public void resetDeathCount()
    {
        deathCounter = 1;
        PlayerPrefs.SetInt("deathCounter", deathCounter);
        //Debug.Log("Death Counter resetted");
    }
}
