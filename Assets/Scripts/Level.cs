using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Tile[] line;
    public LevelGenerator levelGen;

    private void Start()
    {
        levelGen = GetComponent<LevelGenerator>();
    }

    //clear everything from the level
    public void ClearLevel()
    {
        if (line != null)
        {
            foreach (Tile tile in line)
            {
                Destroy(tile);
            }

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }


        }

    }
}
