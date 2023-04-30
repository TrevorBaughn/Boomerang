using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantForward : MonoBehaviour
{
    Pawn pawn;

    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>();
    }

    // Update is called once per frame
    void Update()
    {
        pawn.MoveForward(pawn.moveSpeed);
    }
}
