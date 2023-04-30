using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : PlayerController
{
    [SerializeField] private float teleportAmount;
    private int lane = 1;

    [Header("Control Key Codes")]
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void ProcessInputs()
    {
        if (Input.GetKeyDown(right) && lane <= 1)
        {
            lane += 1;
            pawn.TeleportRight(teleportAmount);
        }
        if (Input.GetKeyDown(left) && lane >= 1)
        {
            lane -= 1;
            pawn.TeleportRight(-teleportAmount);
        }
    }
}
