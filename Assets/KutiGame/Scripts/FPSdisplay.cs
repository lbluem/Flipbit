using UnityEngine;
using TMPro;

public class FPSdisplay : MonoBehaviour
{

    // Showing the Frames per second for performance purposes
    public TextMeshProUGUI fpsText;
    public static FPSdisplay instance;

    private float pollingTime = 1f;
    private float time;
    private int frameCount;


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

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount/time);
            fpsText.text = frameRate.ToString() + " FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
