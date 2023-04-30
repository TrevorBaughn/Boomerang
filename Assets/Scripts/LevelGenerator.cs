using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //designers able to change type of map
    public enum MapType { Random, MapOfTheDay, Seed };
    public MapType type;

    private Level level;
    [SerializeField] private List<Tile> possibleTiles;
    [SerializeField] private List<Tile> possibleSpawnTiles;
    private bool hasSpawn;

    private float tileLength = 20.0f;
    [SerializeField] private int numberOfTiles;

    public int randomSeed;

    public void GenerateLevel()
    {
        hasSpawn = false;

        //seed rng on designer choice
        switch (type)
        {
            case MapType.Random:
                //seed the rng with a random number
                randomSeed = (int)System.DateTime.Now.Ticks;
                Random.InitState(randomSeed);
                break;
            case MapType.Seed:
                //seed rng with seed value
                Random.InitState(randomSeed);
                break;
            case MapType.MapOfTheDay:
                //seed the rng for map of the day
                Random.InitState((int)System.DateTime.Today.Ticks);
                break;
        }

        level = GetComponent<Level>();

        level.line = new Tile[numberOfTiles];

        for(int i = 0; i < numberOfTiles; i++)
        {
            Tile newTile = Instantiate(GetNextTile()) as Tile;

            //move it to correct pos
            Vector3 newPos = new Vector3(0.0f , 0.0f, i * tileLength);
            newTile.transform.position = newPos;
            //give name
            newTile.gameObject.name = "Tile(" + i + ")";
            //organize hierarchy
            newTile.gameObject.transform.parent = level.transform;

            //save it to grid
            level.line[i] = newTile;
        }

    }

    private Tile GetNextTile()
    {
        if(hasSpawn == false)
        {
            hasSpawn = true;
            return possibleSpawnTiles[Random.Range(0, possibleSpawnTiles.Count)];
        }

        return possibleTiles[Random.Range(0, possibleTiles.Count)];
    }
}
