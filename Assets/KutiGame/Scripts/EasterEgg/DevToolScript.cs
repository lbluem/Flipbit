using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevToolScript : MonoBehaviour
{

    // Activating the secret DevTool
    // for FPS display, a (speedrun) timer and more (CoinBonus)Decoration

    // Index for iterating through the Keys list
    int index = 0;
    // For making sure the player is in the designated area
    private bool IsInArea = false;
    // Representing if Dev Mode is turned on / off
    private bool activateMode = false;
    // The FPSdisplay Object to manipulate
    FPSdisplay framesDisplay;
    // The Timer Object to manipulate
    Timer timerDisplay;
    // Instance to keep through Level
    public static DevToolScript instance;

    // List with the order of necessary Button presses
    private EKutiButton[] keys = new EKutiButton[]
    {
        EKutiButton.P1_MID,
        EKutiButton.P1_MID,
        EKutiButton.P1_LEFT,
        EKutiButton.P2_RIGHT,
        EKutiButton.P2_RIGHT
    };


    // GameObject is kept through levels
    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Grabbing the FPS Component and making it invisible to start with
    private void Start() 
    {
        framesDisplay = GetComponentInChildren<FPSdisplay>();
        framesDisplay.fpsText.alpha = 0f;

        timerDisplay = GetComponentInChildren<Timer>();
        timerDisplay.timeText.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Only if the player is in the area
        if(IsInArea)
        {
            if(KutiInput.GetKutiButtonDown(keys[index]))
            {
                index++;
            // If a wrong button is pressed player has to re-enter the area
            }else if(KutiInput.GetAnyButtonDown() && !KutiInput.GetKutiButtonDown(keys[index]))
            {
                IsInArea = false;
            }
            // Player has successfully executed the keycode
            if(index == keys.Length)
            {
                index = 0;
                //Debug.Log("PLAYER INSIDE DEV AREA");
                SwitchMode();
            }
        }
        if(SceneManager.GetActiveScene().buildIndex > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))    
        {
            IsInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))    
        {
            IsInArea = false;
            // The index (counter) gets reset
            index = 0;
        }
    }

    // Switching visibility of FPS Text
    private void SwitchMode()
    {
        activateMode = !activateMode;
        // Sound cue
        FindObjectOfType<AudioManager>().Play("CoinPickup");

        if(activateMode)
        {
            framesDisplay.fpsText.alpha = 1f;
            timerDisplay.timeText.alpha = 1f;
            // Dummy Coins used from a previous discarded concept
            // this leads to hearts being at the Level End Scene if "Dev Mode" is on
            CoinCounter.instance.AddCoinCount("devCoin");
        }else
        {
            framesDisplay.fpsText.alpha = 0f;
            timerDisplay.timeText.alpha = 0f;
            CoinCounter.instance.ResetCoins();
        }
    }
}
