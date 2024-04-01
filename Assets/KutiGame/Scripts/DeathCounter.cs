using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    // Managing the PlayerPref DeathCounter
    // Attempt counter not death counter therefore it starts at 1
    // kein Death Counter sondern VERSUCHs Counter deswegen Start bei 1
    public static DeathCounter instance;
    private int deathCounter = 1;

    // To manipulate the Text in the End Level
    public TextMeshProUGUI deathCounterLabel_P1;
    public TextMeshProUGUI deathCounterLabel_P2;

    private void Awake() {
        instance = this;
        PlayerPrefs.SetInt("deathCounter", deathCounter);
        //DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {
        deathCounter = PlayerPrefs.GetInt("deathCounter");
        
        // Only happens in the end Level
        if(deathCounterLabel_P1 != null)
        {
            deathCounterLabel_P1.SetText(deathCounter.ToString());
            deathCounterLabel_P2.SetText(deathCounter.ToString());
        }
    }

    // Method to increment the death count
    // Methode zur Inkrementierung des Versuchs-Zählers
    public void AddDeathCount()
    {
        deathCounter++;
        PlayerPrefs.SetInt("deathCounter", deathCounter);
        Debug.Log("DeathCounter: "+deathCounter);
    }

    // Method to reset the death count
    // Methode zum Zurücksetzen des Versuchs-Zählers
    public void ResetDeathCount()
    {
        deathCounter = 1;
        PlayerPrefs.SetInt("deathCounter", deathCounter);
        Debug.Log("DeathCounter: Reset");
    }

}
