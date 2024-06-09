using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndWalkPlayerState : WalkPlayerState
{
    public PlayerController controller;
    private Coroutine Coroutine;
    private WaitForSeconds wait;
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
        AnimatorStateInfo a = controller.Player.Animator.GetCurrentAnimatorStateInfo(0);
        if (!a.IsName("mixamo.com(1)"))
        {
            controller.Player.Animator.SetTrigger("IsAttack");
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
    public IEnumerator DelayShoot()
    {
        yield return wait;
        controller.Player.ClearShoot();
    }
}
