using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Animated_Decoration : MonoBehaviour
{
    // An object with this script must always be a child of a (decoration) tilemap
    // Ein Objekt mit diesem Skript muss immer Child einer (Decoration) Tilemap sein
    private Color currentBgColor;
    private SpriteRenderer thisSprite;

    // The tilemap must be dragged onto the field manually in the editor
    // Die Tilemap muss händisch im Editor auf das Feld gezogen werden
    public DecoColorChanger decoColorChangerScript;

    // Start is called before the first frame update
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        currentBgColor = GetComponentInParent<Tilemap>().color;

        thisSprite.color = currentBgColor;
    }

    public void Awake()
    {   
        decoColorChangerScript.OnColorChange += SetColor;
    }

    void OnDestroy()
    {
        decoColorChangerScript.OnColorChange -= SetColor;
    }

    void SetColor(Color color)
    {
        if(thisSprite != null)
        {
            thisSprite.color = color;
        }
    }   
}
