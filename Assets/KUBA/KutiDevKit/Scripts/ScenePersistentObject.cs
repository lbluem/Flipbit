using UnityEngine;
using System.Collections;

public class ScenePersistentObject : MonoBehaviour {
    private static bool isCreated;
    void Awake()
    {
        if (!isCreated)
        {
            // this is the first instance - make it persist
            DontDestroyOnLoad(this.gameObject);
            isCreated = true;
        }
        else {
            // this must be a duplicate from a scene reload - DESTROY!
            Destroy(this.gameObject);
        }
    }
}
