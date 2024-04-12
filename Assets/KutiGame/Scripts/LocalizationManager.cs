using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LocalizationManager : MonoBehaviour
{

    // Loading the Localization XML file

    public TextAsset localizationFile;
    private Dictionary<string, Dictionary<string, string>> localizedTexts;

    void Awake()
    {
        localizedTexts = new Dictionary<string, Dictionary<string, string>>();
        LoadLocalizedTexts();
    }

    void LoadLocalizedTexts()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(localizationFile.text);

        XmlNodeList languageNodes = xmlDoc.SelectNodes("//Language");
        foreach (XmlNode languageNode in languageNodes)
        {
            string languageId = languageNode.Attributes["id"].Value;
            localizedTexts[languageId] = new Dictionary<string, string>();
            XmlNodeList textNodes = languageNode.SelectNodes("String");
            foreach (XmlNode textNode in textNodes)
            {
                string key = textNode.Attributes["key"].Value;
                string value = textNode.InnerText;
                localizedTexts[languageId][key] = value;
            }
        }
    }


    public string GetLocalizedText(string languageId, string key)
    {        
        if (localizedTexts.ContainsKey(languageId) && localizedTexts[languageId].ContainsKey(key))
        {
            return localizedTexts[languageId][key];
        }
        else
        {
            return "Localized text not found";
        }
    }
}
