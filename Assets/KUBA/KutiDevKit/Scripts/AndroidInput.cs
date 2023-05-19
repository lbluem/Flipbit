using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;

public class AndroidInput : MonoBehaviour
{
    private string path = "sys/class/gpio/gpio";
    private Dictionary<EKutiButton, FileStream> fileStreams = new Dictionary<EKutiButton, FileStream>();
    private Dictionary<int, EKutiButton> Ports = new Dictionary<int, EKutiButton>
    {
        { 1,EKutiButton.P2_MID },
        { 2,EKutiButton.MENU },
        { 3,EKutiButton.P1_LEFT},
        { 4,EKutiButton.P1_RIGHT },
        { 5,EKutiButton.P1_MID },
        { 6,EKutiButton.P2_LEFT },
        { 8,EKutiButton.P2_RIGHT },
    };
    private static Dictionary<EKutiButton, bool> currentInputs = new Dictionary<EKutiButton, bool>
    {
            { EKutiButton.MENU, false }, { EKutiButton.P1_LEFT, false },
             { EKutiButton.P1_RIGHT, false }, { EKutiButton.P1_MID, false },
              { EKutiButton.P2_LEFT, false }, { EKutiButton.P2_MID, false },
             { EKutiButton.P2_RIGHT, false }
    };
   private static Dictionary<EKutiButton, bool> currentButtonDown = new Dictionary<EKutiButton, bool>
    {
            { EKutiButton.MENU, false }, { EKutiButton.P1_LEFT, false },
             { EKutiButton.P1_RIGHT, false }, { EKutiButton.P1_MID, false },
              { EKutiButton.P2_LEFT, false }, { EKutiButton.P2_MID, false },
             { EKutiButton.P2_RIGHT, false }
    };
    private static Dictionary<EKutiButton, bool> currentButtonUp = new Dictionary<EKutiButton, bool>
    {
            { EKutiButton.MENU, false }, { EKutiButton.P1_LEFT, false },
             { EKutiButton.P1_RIGHT, false }, { EKutiButton.P1_MID, false },
              { EKutiButton.P2_LEFT, false }, { EKutiButton.P2_MID, false },
             { EKutiButton.P2_RIGHT, false }
    };

    public static bool isInitialized = false;
    private static bool isCreated;

    void Awake()
    {
        if (!isCreated)
        {
            // this is the first instance - make it persist
            DontDestroyOnLoad(this.gameObject);
            isCreated = true;
            Initialize();
        }
        else
        {
            // this must be a duplicate from a scene reload - DESTROY!
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        ResetUpDownDictionarys();
        ListenForKeyChanges();
    }
    IEnumerator SetVolume()
    {
        yield return new WaitForSeconds(5f);
        AndroidNativeVolumeService.SetSystemVolume(0.5f);
    }
    private  void Initialize()
    {
        if(File.ReadAllText("proc/device-tree/model").Contains("Compute Module"))
        {
            Ports = new Dictionary<int, EKutiButton>
            {
                { 2,EKutiButton.MENU },
                { 3,EKutiButton.P1_LEFT},
                { 4,EKutiButton.P1_RIGHT },
                { 5,EKutiButton.P1_MID },
                { 6,EKutiButton.P2_LEFT },
                { 8,EKutiButton.P2_RIGHT },
                { 1,EKutiButton.P2_MID }
            };
        }
        else
        {
            Ports = new Dictionary<int, EKutiButton>
            {
                { 2,EKutiButton.MENU },
                { 3,EKutiButton.P1_LEFT},
                { 4,EKutiButton.P1_RIGHT },
                { 5,EKutiButton.P1_MID },
                { 6,EKutiButton.P2_LEFT },
                { 8,EKutiButton.P2_RIGHT },
                { 15,EKutiButton.P2_MID }
            };
        }



        StartCoroutine(SetVolume());
        foreach (KeyValuePair<int, EKutiButton> entry in Ports)
        {
            FileStream temp = null;
            try
            {
                temp = new FileStream(path + entry.Key + "/value", FileMode.Open, FileAccess.Read);
                currentInputs[entry.Value] = ReadStream(temp) == 48;
                fileStreams.Add(entry.Value, temp);
            }
            catch (Exception e)
            {
                Console.Write(
                    "Wasn't able to open StreamReader for KutiButton " + entry.Value +
                    " and its GPIO port " + entry.Key, e);
            }
        }
        if(fileStreams.Count == currentInputs.Count)
        {
            isInitialized = true;
        }
    }
    private  int ReadStream(FileStream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        int temp = stream.ReadByte();
        return temp;
    }   

    public static bool GetKutiButton(EKutiButton button)
    {
        return currentInputs[button];
    }
    public static bool GetKutiButtonDown(EKutiButton button)
    {
        return currentButtonDown[button];
    }
    public static bool GetKutiButtonUp(EKutiButton button)
    {
        return currentButtonUp[button];
    }

    private void ResetUpDownDictionarys()
    {
        foreach (EKutiButton button in EKutiButton.GetValues(typeof(EKutiButton)))
        {
            currentButtonDown[button] = false;
            currentButtonUp[button] = false;
        }
    }
    private void ListenForKeyChanges()
    {
        if(!isInitialized)
        {
            Initialize();
        }
         foreach (EKutiButton button in EKutiButton.GetValues(typeof(EKutiButton)))
        {
            bool input = false;
            try
            {
                input = ReadStream(fileStreams[button]) == 48;
            }
            catch
            {

            }
            if(input!= currentInputs[button])
            {
                currentInputs[button] = input;
                if(input == true)
                {
                    currentButtonDown[button] = true;
                }
                else if(input==false)
                {
                    currentButtonUp[button] = true;
                }
            }         
        }
    }
}
