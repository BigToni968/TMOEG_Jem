using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayerState : State
{
    public PlayerController controller;
    public WaitForSeconds wait;
    public DeathPlayerState(StateMachine machine) : base(machine)
    {
        controller = machine as PlayerController;
    }

    public override void OnFinish()
    {
        //
    }

    public override void OnFixedUpdate()
    {
        
    }

    public override void OnStart()
    {
        controller.Player.Animator.SetTrigger("IsDie");
        AnimatorStateInfo a = controller.Player.Animator.GetCurrentAnimatorStateInfo(0);
        wait = new WaitForSeconds(a.length);
        controller.Player.StartCoroutine(WaitAnimDeath());

    }

    public override void OnUpdate()
    {
        if (controller.Player.PlayerSelf.Health > 0)
        {
            controller.Switch(new IdlePlayerState(Machine));            
        }
    }

    public IEnumerator WaitAnimDeath()
    {
        yield return wait;
        
    }
}
