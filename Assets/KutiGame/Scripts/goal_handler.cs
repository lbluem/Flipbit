using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal_handler : MonoBehaviour
{
    [SerializeField]
    public string NextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
{
    SceneManager.LoadScene(NextLevelName, LoadSceneMode.Single);
}
}
