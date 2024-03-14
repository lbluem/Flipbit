using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit_Script : MonoBehaviour
{
    // Only for the Credit Scene
    // Part of the Main Camera
    void Update()
    {
        // Loads Level 1 if a button was pressed
        if(KutiInput.GetAnyButtonDown())
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

    }
}
