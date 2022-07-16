using Assets.Scipts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehavior : MonoBehaviour
{
    public int Width = 20;

    public int Height = 10;

    public List<GameObject> TileTypes;

    public List<int> TileProbability;

    //private List<ITile> TileGrid;

    private ITile[,] TileGrid;

    // Start is called before the first frame update
    void Start()
    {
        TileGrid = new ITile[Width, Height];

        foreach (GameObject obj in TileTypes)
        {
            var tileComponent = obj.GetComponent(typeof(ITile));

            if (tileComponent == null)
            {
                TileTypes.Remove(obj);
            }
        }

        for (int y = 0; y < Height; ++y)
        {
            for (int x = 0; x < Width; ++x)
            {
                GameObject obj;

                if (TileTypes.Count != TileProbability.Count)
                {
                    obj = Instantiate(TileTypes[Random.Range(0, TileTypes.Count)], new Vector3(x, 0, y), Quaternion.identity, transform);
                }
                else
                {
                    obj = Instantiate(GetTileTypeFromProbability(), new Vector3(x, 0, y), Quaternion.identity, transform);
                }

                TileGrid[x, y] = obj.GetComponent(typeof(ITile)) as ITile;
            }
        }
    }

    private GameObject GetTileTypeFromProbability()
    {
        var totalProbability = 0;
        TileProbability.ForEach(x => totalProbability += x);
        var randomNumber = Random.Range(0, totalProbability);
        int i = 0;
        int j = 0;

        foreach (int probability in TileProbability)
        {
            if (randomNumber >= i && randomNumber < i + probability)
            {
                return TileTypes[j];
            }
            i += probability;
            ++j;
        }
        return TileTypes[Random.Range(0, TileTypes.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetGridValue(int x, int y)
    {
        print($"get info on {x}, {y};");
    }

    public void ExecuteTile(int x, int y, int value)
    {
        TileGrid[x, y].ApplyTileEffect(x, y, value);
    }
}
