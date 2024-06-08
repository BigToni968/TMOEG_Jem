using Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayerState : State
{
    PlayerController controller;
    private WaitForSeconds wait;
    private Coroutine Coroutine;
    private float timeAnimation;
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
        //controller.Player.Animator.SetTrigger("IsShoot");
        AnimatorStateInfo a = controller.Player.Animator.GetCurrentAnimatorStateInfo(0);
        if (!a.IsName("mixamo.com(1)"))
        {
            controller.Player.Animator.SetTrigger("IsAttack");
        }
    }

    public override void OnUpdate()
    {
        //timeAnimation -= Time.deltaTime;
        //if (timeAnimation >= 0f)
        //{
        //    return;
        //}
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            controller.Switch(new WalkPlayerState(Machine));
        }
        if (Input.GetAxis("Horizontal") == 0f || Input.GetAxis("Vertical") == 0f)
        {
            controller.Switch(new HealthStayPlayerState(Machine));
        }
        if (controller.Player.PlayerSelf.Health <= 0f)
        {
            controller.Switch(new DeathPlayerState(Machine));
        }
    }

    public IEnumerator DelayShoot()
    {
        yield return wait;
        controller.Player.ClearShoot();
    }
}
