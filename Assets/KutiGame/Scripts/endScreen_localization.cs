﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq; // Hinzugefügter Namespace für LINQ

public class endScreen_localization : MonoBehaviour
{
    [SerializeField] private string language;

    public LocalizationManager localizationManager;
    private TextMeshProUGUI  attemptsText;
    private TextMeshProUGUI  thankyouText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLocalizedTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void UpdateLocalizedTexts()
    {
        if (language == "en")
        {
            TextMeshProTagManager.UpdateTextMeshProWithTag("versuche", localizationManager.GetLocalizedText("en_US", "versuche"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("danke", localizationManager.GetLocalizedText("en_US", "danke"));
        }
        else if (language == "de")
        {
            TextMeshProTagManager.UpdateTextMeshProWithTag("versuche", localizationManager.GetLocalizedText("de_DE", "versuche"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("danke", localizationManager.GetLocalizedText("de_DE", "danke"));
        }
    }
    
    public static class TextMeshProTagManager
{
    public static void UpdateTextMeshProWithTag(string tag, string newText)
    {
        TextMeshProUGUI[] textMeshPros = GameObject.FindGameObjectsWithTag(tag)
                                                  .Select(go => go.GetComponent<TextMeshProUGUI>())
                                                  .Where(tmpro => tmpro != null)
                                                  .ToArray();

        foreach (TextMeshProUGUI tmpro in textMeshPros)
        {
            tmpro.text = newText;
        }
    }
}
}