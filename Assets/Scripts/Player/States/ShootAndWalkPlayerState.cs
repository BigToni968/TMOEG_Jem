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
        wait = new WaitForSeconds(controller.Player.Bullet.DelayShoot);
        controller.Player.Shoot(DelayShoot());
        Debug.Log("StateShoot");
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
