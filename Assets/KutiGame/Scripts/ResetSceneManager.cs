using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KutiInput.GetKutiButtonDown(EKutiButton.MENU))
        {
            SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
        }
    }
}
