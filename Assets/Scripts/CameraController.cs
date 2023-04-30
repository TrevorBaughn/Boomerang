using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    private Pawn pawn;

    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponentInParent<Pawn>();
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {

    }

    //two similar functions, that COULD be one, but are named differently for descriptions sake
    //not sure if better way to do this in C#

    //follows the pawn simply
    public void followPawn()
    {
        if (pawn != null)
        {
            //set position of camera to the offset of the position
            transform.SetPositionAndRotation(pawn.transform.position + cameraOffset, Quaternion.identity);

            //look at the pawn
            //transform.LookAt(pawn.transform);
        }
    }
}
