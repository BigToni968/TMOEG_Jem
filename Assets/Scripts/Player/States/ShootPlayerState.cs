using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayerState : State
{
    PlayerController controller;
    public ShootPlayerState(StateMachine machine) : base(machine)
    {
        controller = machine as PlayerController;
    }

    public override void OnFinish()
    {
        
    }

    public override void OnFixedUpdate()
    {
        
    }

    public override void OnStart()
    {
        Debug.Log("StateShoot");
        controller.Player.Shoot();
    }

    public override void OnUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            controller.Switch(new WalkPlayerState(Machine));
        }
        if(Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            controller.Switch(new HealthStayPlayerState(Machine));
        }
        if (controller.Player.PlayerSelf.Health <= 0f)
        {
            controller.Switch(new DeathPlayerState(Machine));
        }
    }
}
