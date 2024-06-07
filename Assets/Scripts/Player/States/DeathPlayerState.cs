using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayerState : State
{
    public PlayerController controller;
    public DeathPlayerState(StateMachine machine) : base(machine)
    {
        controller = machine as PlayerController;
    }

    public override void OnFinish()
    {
        //
    }

    public override void OnStart()
    {
        // ¬ключить анимацию смерти.
    }

    public override void OnUpdate()
    {
        if (controller.Player.PlayerSelf.Health > 0)
        {
            controller.Switch(new IdlePlayerState(Machine));            
        }
    }
}
