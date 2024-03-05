using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneManager : MonoBehaviour
{
    // Skript für Menü Button
    // Script for Menu Button
    void Update()
    {
        if(KutiInput.GetKutiButtonDown(EKutiButton.MENU))
        {
            //SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            DeathCounter.instance.resetDeathCount();
            CoinCounter.instance.resetCoinCount();

            //Debug.Log("ResetSceneManager: Scene resetted");
        }
    }
}
