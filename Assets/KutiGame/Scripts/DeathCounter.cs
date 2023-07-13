using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{

    private int deathCounter = 0;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void addDeathCount()
    {
        deathCounter++;
    }

    public void resetDeathCount()
    {
        deathCounter = 0;
    }
}
