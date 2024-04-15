using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCheck : MonoBehaviour
{
    // Script to make sure the neccessary Instances exist in the scene
    // Especially for testing in Unity

    private void Awake() 
    {
        // Creating an InputManager if it doesnt exist in the scene
        if(InputManager.Instance == null)
        {
            GameObject InputManager = new GameObject("InputManager");
            InputManager.AddComponent<InputManager>();
        }
        // Creating a DeathCounter if it doesnt exist in the scene
        if(DeathCounter.instance == null)
        {
            GameObject DeathCounter = new GameObject("DeathCounter");
            DeathCounter.AddComponent<DeathCounter>();
        }
    }
}
