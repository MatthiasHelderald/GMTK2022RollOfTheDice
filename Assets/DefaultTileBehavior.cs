using Assets.Scipts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTileBehavior : MonoBehaviour, ITile
{
    public void ApplyTileEffect(int x, int y, int value)
    {
        print($"Arrived on green tile at {x}, {y} with value {value}");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
