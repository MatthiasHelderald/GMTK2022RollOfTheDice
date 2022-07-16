using Assets.Scipts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DefaultGreenTileBehavior : MonoBehaviour, ITile
{
    private GameObject Plaisir;
    private SliderControl SliderScript;
    private TextMeshProUGUI Textou;
    public void ApplyTileEffect(int x, int y, int value)
    {
        print($"Arrived on green tile at {x}, {y} with value {value}");
        SliderScript.slider.value += value;
        SliderScript.score += value;
        Textou.text = "Score :"+SliderScript.score;
    }
    
    void Start()
    {
        Plaisir = GameObject.FindGameObjectsWithTag("Environment").First();
        SliderScript = Plaisir.GetComponentInChildren<SliderControl>();
        Textou = Plaisir.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
