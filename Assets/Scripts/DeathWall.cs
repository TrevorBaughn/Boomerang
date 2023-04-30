using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.death);
        GameManager.instance.playerSpawner.DestroyPlayer();

        GameManager.instance.winState = false;
        GameManager.instance.ActivateGameOverState();
    }
}
