using UnityEngine;

public static class AndroidNativeVolumeService
{
    static int STREAMMUSIC;
    static int FLAGSHOWUI = 0;

    private static AndroidJavaObject audioManager;

    private static AndroidJavaObject deviceAudio
    {
        get
        {
            if (audioManager == null)
            {
                AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
                AndroidJavaClass audioManagerClass = new AndroidJavaClass("android.media.AudioManager");
                AndroidJavaClass contextClass = new AndroidJavaClass("android.content.Context");

                STREAMMUSIC = audioManagerClass.GetStatic<int>("STREAM_MUSIC");
                string Context_AUDIO_SERVICE = contextClass.GetStatic<string>("AUDIO_SERVICE");

                audioManager = context.Call<AndroidJavaObject>("getSystemService", Context_AUDIO_SERVICE);
            }
            return audioManager;
        }

    }

    private static int GetDeviceMaxVolume()
    {
        return deviceAudio.Call<int>("getStreamMaxVolume", STREAMMUSIC);
    }

    public static float GetSystemVolume()
    {
        int deviceVolume = deviceAudio.Call<int>("getStreamVolume", STREAMMUSIC);
        float scaledVolume = (float)(deviceVolume / (float)GetDeviceMaxVolume());

        return scaledVolume;
    }

    public static void SetSystemVolume(float volumeValue)
    {
        int scaledVolume = (int)(volumeValue * (float)GetDeviceMaxVolume());
        deviceAudio.Call("setStreamVolume", STREAMMUSIC, scaledVolume, FLAGSHOWUI);
    }
}