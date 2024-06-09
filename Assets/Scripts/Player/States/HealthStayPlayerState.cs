using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HealthStayPlayerState : IdlePlayerState
{
    public PlayerController Controller;
    private WaitForSeconds waitHealth;
    private WaitForSeconds tickHealth;
    private Coroutine Coroutine;

    public HealthStayPlayerState(StateMachine machine) : base(machine)
    {
        Controller = machine as PlayerController;
    }

    public override void OnFinish()
    {
        base.OnFinish();
        Controller.Player.StopCoroutine(Coroutine);
    }

    public override void OnStart()
    {
        base.OnStart();
        Controller.Player.rb.velocity = Vector3.zero;
        waitHealth = new WaitForSeconds(Controller.Player.PlayerSelf.DelayHealth);
        tickHealth = new WaitForSeconds(Controller.Player.PlayerSelf.tickHealth);
        Coroutine = Controller.Player.StartCoroutine(Delayhealth());
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
                Audio.Instance.Sound.PlayOneShot(Audio.Instance.health_Player[Random.RandomRange(0, Audio.Instance.health_Player.Length)]);
                Controller.Player.PlayerSelf.Health += Controller.Player.PlayerSelf.HealthRecovery;
            }
        }
    }
}
