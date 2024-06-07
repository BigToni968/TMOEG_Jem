using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStayPlayerState : IdlePlayerState
{
    public PlayerController Controller;
    private WaitForSeconds waitHealth;
    private WaitForSeconds tickHealth;
    public HealthStayPlayerState(StateMachine machine) : base(machine)
    {
        Controller = machine as PlayerController;
    }

    public override void OnFinish()
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        waitHealth = new WaitForSeconds(Controller.Player.PlayerSelf.DelayHealth);
        tickHealth = new WaitForSeconds(Controller.Player.PlayerSelf.tickHealth);
        Controller.Player.PlayCoroutine(Delayhealth());
        Debug.Log("Хп поперло");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public IEnumerator Delayhealth()
    {
        yield return waitHealth;
        while (true)
        {
            yield return tickHealth;
            if (Controller.Player.PlayerSelf.Health < Controller.Player.PlayerSelf.MaxHealth)
            {
                Controller.Player.PlayerSelf.Health += Controller.Player.PlayerSelf.HealthRecovery;
            }
        }
    }
}
