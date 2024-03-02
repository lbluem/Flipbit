using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneManager : MonoBehaviour
{
    // Skript für Menü Button
    void Update()
    {
        if(KutiInput.GetKutiButtonDown(EKutiButton.MENU))
        {
            //SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            DeathCounter.instance.resetDeathCount();

            //Debug.Log("ResetSceneManager: Scene resetted");
        }
    }
}
