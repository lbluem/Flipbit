using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // Managing almost all Inputs (besides the Credit Screen)
    // Used by mainly Player/Platform Movement Scripts

    public static InputManager Instance;

    public bool P1ButtonLeftUp {get; private set;} = true;
    public bool P1ButtonRightUp {get; private set;} = true;
    public bool P2ButtonLeftUp {get; private set;} = true;
    public bool P2ButtonRightUp {get; private set;} = true;

    public bool P1ButtonJumpUp {get; private set;} = true;
    public bool P2ButtonJumpUp {get; private set;} = true;

    private void Awake() 
    {
        ResetButtons();
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    // Keeping track of all Button states
    private void Update()
    {  
        
        if(KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT)){P1ButtonLeftUp = false;/* Debug.Log("P1: LEFT BUTTON DOWN"); */}
        if(KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT)){P1ButtonRightUp = false;/* Debug.Log("P1: RIGHT BUTTON DOWN"); */}
        if(KutiInput.GetKutiButtonUp(EKutiButton.P1_LEFT)){P1ButtonLeftUp = true;/* Debug.Log("P1: LEFT BUTTON UP"); */}
        if(KutiInput.GetKutiButtonUp(EKutiButton.P1_RIGHT)){P1ButtonRightUp = true;/* Debug.Log("P1: RIGHT BUTTON UP"); */}
        
        if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID)){P1ButtonJumpUp = false;/* Debug.Log("P1: JUMP BUTTON DOWN"); */}
        if(KutiInput.GetKutiButtonUp(EKutiButton.P1_MID)){P1ButtonJumpUp = true;/* Debug.Log("P1: JUMP BUTTON UP"); */}

        if(KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT)){P2ButtonLeftUp = false;/* Debug.Log("P2: LEFT BUTTON DOWN"); */}
        if(KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT)){P2ButtonRightUp = false;/* Debug.Log("P2: RIGHT BUTTON DOWN"); */}
        if(KutiInput.GetKutiButtonUp(EKutiButton.P2_LEFT)){P2ButtonLeftUp = true;/* Debug.Log("P2: LEFT BUTTON UP"); */}
        if(KutiInput.GetKutiButtonUp(EKutiButton.P2_RIGHT)){P2ButtonRightUp = true;/* Debug.Log("P2: RIGHT BUTTON UP"); */}

        if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID)){P2ButtonJumpUp = false;/* Debug.Log("P2: JUMP BUTTON DOWN"); */}
        if(KutiInput.GetKutiButtonUp(EKutiButton.P2_MID)){P2ButtonJumpUp = true;/* Debug.Log("P2: JUMP BUTTON UP"); */}
     
    }

    // Resetting Buttons for a fresh start
    public void ResetButtons()
    {
        //Debug.Log("RESETTING BUTTONS");
        P1ButtonLeftUp = true;
        P1ButtonRightUp = true;
        P2ButtonLeftUp = true;
        P2ButtonRightUp = true;

        P1ButtonJumpUp = true;
        P2ButtonJumpUp = true;
    }

}
