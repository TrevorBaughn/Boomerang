using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Controller controller;
    protected Mover mover;

    [Header("Speeds")]
    [SerializeField] protected float maxMoveSpeed;
    [SerializeField] protected float baseMoveSpeed;
    public float moveSpeed;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        //load mover
        mover = GetComponent<Mover>();

        //load controller
        controller = GetComponent<Controller>();
    }

    abstract public void MoveForward(float moveSpeed);

    abstract public void TeleportRight(float distance);
}
