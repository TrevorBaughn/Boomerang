using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPawn : Pawn
{
    [SerializeField] private bool sendBack = false;
    [SerializeField] private bool sendCenter = false;
    [SerializeField] private float moveSpeedIncrementer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        moveSpeed = baseMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoveSpeed();

    }

    private void UpdateMoveSpeed()
    {
        //if reached max speed forward, send back
        if (moveSpeed >= maxMoveSpeed)
        {
            sendBack = true;
        }

        //if reached max speed backward, send center
        if (moveSpeed <= -maxMoveSpeed)
        {
            sendCenter = true;
        }

        if (sendBack == true && sendCenter == true && moveSpeed > 0)
        {
            sendBack = false;
            sendCenter = false;
            moveSpeed = 0;

            GameManager.instance.winState = true; //cheap way to do this
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.win);
            GameManager.instance.playerSpawner.DestroyPlayer();
            GameManager.instance.ActivateGameOverState();

        }

        //if moving forward
        if (moveSpeed > 0)
        {
            //if hasn't hit max speed yet, increase speed
            if (sendBack == false)
            {
                moveSpeed += moveSpeedIncrementer * Time.deltaTime;
            }
            //when has hit max speed, decrease speed
            else
            {
                moveSpeed -= moveSpeedIncrementer * Time.deltaTime;
            }
        }
        //going backwards
        else if(moveSpeed < 0)
        {
            //if hasn't hit max speed yet, increase speed
            if (sendCenter == false)
            {
                moveSpeed -= moveSpeedIncrementer * Time.deltaTime;
            }
            //when has hit max speed, decrease speed
            else
            {
                moveSpeed += moveSpeedIncrementer * Time.deltaTime;
            }
        }

        
    }

    public override void MoveForward(float moveSpeed)
    {
        mover.MoveForward(moveSpeed);
    }

    public override void TeleportRight(float distance)
    {
        mover.TeleportRight(distance);
    }
}
