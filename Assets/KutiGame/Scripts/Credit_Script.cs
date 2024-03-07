using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit_Script : MonoBehaviour
{
    void Update()
    {
        if(KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT)||
        KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT)||
        KutiInput.GetKutiButtonDown(EKutiButton.P1_MID)||
        KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT)||
        KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT)||
        KutiInput.GetKutiButtonDown(EKutiButton.P2_MID))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            DeathCounter.instance.resetDeathCount();
            CoinCounter.instance.resetCoinCount();

            // CoinID reset...

            //Debug.Log("ResetSceneManager: Scene resetted");
        }

    }
}
