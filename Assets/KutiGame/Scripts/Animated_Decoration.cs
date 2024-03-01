using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Animated_Decoration : MonoBehaviour
{
    // Ein Objekt mit diesem Skript muss immer Child einer Decoration Tilemap sein

    private Color currentBgColor;
    private SpriteRenderer thisSprite;

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
        thisSprite.color = color;
    }   


}
