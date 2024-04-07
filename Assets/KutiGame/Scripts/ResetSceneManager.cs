using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneManager : MonoBehaviour
{
    // Only for development
    // Script for Menu Button and will be deprecated in the future
    // Nur für die Entwicklung
    // Skript für Menü Button und ist in der Zukunft überflüssig
    void Update()
    {
        if(KutiInput.GetKutiButtonDown(EKutiButton.MENU))
        {
            SceneManager.LoadScene(11, LoadSceneMode.Single);
            //Debug.Log("ResetSceneManager: Scene resetted");
        }
    }
}
