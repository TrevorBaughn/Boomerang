using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.whoosh);
        GameManager.instance.players[0].score += 1;
    }
}
