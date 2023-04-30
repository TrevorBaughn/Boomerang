using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    private GameObject spawnedObject;

    public void SpawnPlayer()
    {
        spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
        spawnedObject.gameObject.transform.parent = this.transform;
    }

    public void DestroyPlayer()
    {
        GameManager.instance.finalScore = spawnedObject.GetComponent<Controller>().score;
        Destroy(spawnedObject.gameObject);
    }
}
