using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndWalkPlayerState : WalkPlayerState
{
    public PlayerController controller;
    public ShootAndWalkPlayerState(StateMachine machine) : base(machine)
    {
        controller = machine as PlayerController;
    }

    public override void OnFinish()
    {
        
    }

    public override void OnStart()
    {
        base.OnStart();
        controller.Player.Shoot();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

}
