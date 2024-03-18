using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq; // Hinzugefügter Namespace für LINQ

    
public class Localization_Handler : MonoBehaviour
{
    [SerializeField] private string language;

    public LocalizationManager localizationManager;

    void Start() {

        UpdateLocalizedTexts();
    }
    void UpdateLocalizedTexts()
    {
        if (language == "en")
        {
            TextMeshProTagManager.UpdateTextMeshProWithTag("upbuttonlabel", localizationManager.GetLocalizedText("en_US", "up_button"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("rightbuttonlabel", localizationManager.GetLocalizedText("en_US", "right_button"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("leftbuttonlabel", localizationManager.GetLocalizedText("en_US", "left_button"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("goaltext", localizationManager.GetLocalizedText("en_US", "goal_label"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("swaptext", localizationManager.GetLocalizedText("en_US", "swappad_label"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("versuche", localizationManager.GetLocalizedText("en_US", "versuche"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("danke", localizationManager.GetLocalizedText("en_US", "danke"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("from", localizationManager.GetLocalizedText("en_US", "from"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("graphics", localizationManager.GetLocalizedText("en_US", "graphics"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("soundtrack", localizationManager.GetLocalizedText("en_US", "soundtrack"));

        }
        else if (language == "de")
        {
            TextMeshProTagManager.UpdateTextMeshProWithTag("upbuttonlabel", localizationManager.GetLocalizedText("de_DE", "up_button"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("rightbuttonlabel", localizationManager.GetLocalizedText("de_DE", "right_button"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("leftbuttonlabel", localizationManager.GetLocalizedText("de_DE", "left_button"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("goaltext", localizationManager.GetLocalizedText("de_DE", "goal_label"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("swaptext", localizationManager.GetLocalizedText("de_DE", "swappad_label"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("versuche", localizationManager.GetLocalizedText("de_DE", "versuche"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("danke", localizationManager.GetLocalizedText("de_DE", "danke"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("from", localizationManager.GetLocalizedText("de_DE", "from"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("graphics", localizationManager.GetLocalizedText("de_DE", "graphics"));
            TextMeshProTagManager.UpdateTextMeshProWithTag("soundtrack", localizationManager.GetLocalizedText("de_DE", "soundtrack"));

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