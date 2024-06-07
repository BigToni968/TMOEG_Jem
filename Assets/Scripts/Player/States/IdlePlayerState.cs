using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerState : State
{
    PlayerController controller;
    public IdlePlayerState(StateMachine machine) : base(machine)
    {
        controller = machine as PlayerController;
    }

    public override void OnFinish()
    {
        // �� �������
    }

    public override void OnStart()
    {
        Debug.Log("StateIdle");
        // �������� �������� ��������.
    }

    public override void OnUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            controller.Switch(new WalkPlayerState(Machine));
        }
        if (Input.GetMouseButtonDown(0))
        {
            controller.Switch(new ShootPlayerState(Machine));
        }
    }
}
