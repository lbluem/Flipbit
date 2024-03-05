using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake() {


        // Ensure there's only one instance of AudioManager
        // Sicher stellen, dass es nur eine Instanz von AudioManager gibt
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
            return;
        }

        // Keep AudioManager persistent across scenes
        // Behalte AudioManager über Szenenwechsel hinweg
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    // Play the soundtrack when the scene starts
    // Spielt Soundtrack ab, wenn die Szene startet
    private void Start() {
        Play("Soundtrack");
    }

    // Find and play the sound with the specified name
    // Findet den Sound mit dem bestimmten Namen und spielt ihn ab
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s== null)
        {
            Debug.LogWarning("AudioManager: Sound: "+ name + " not found!");
            return;
        }
        
        // Pitch randomly changes a little for variations
        // Pitch wird für Abwechslung leicht verändert
        if(s.name != "Soundtrack")
        {
            RandomizeSound(s);
        }
        s.source.Play();
        //Debug.Log("AudioManager: Sound: "+ name + " played");
    }

    // Find and stop the sound with the specified name
    // Findet den Sound mit dem bestimmten Namen und stoppt ihn
    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s== null)
        {
            Debug.LogWarning("AudioManager: Sound to stop: "+ name + " not found!");
            return;
        }
        s.source.Stop();
    }

    private void RandomizeSound(Sound s)
    {   
        s.source.pitch = UnityEngine.Random.Range(0.9f,1.2f);
        s.pitch = s.source.pitch;
    }
}
