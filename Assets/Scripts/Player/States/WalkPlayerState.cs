using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WalkPlayerState : State
{
    public PlayerController controller;
    public Coroutine Coroutine;
    public WaitForSeconds wait;

    public WalkPlayerState(StateMachine machine) : base(machine)
    {
        controller = machine as PlayerController;
    }

    public override void OnFinish()
    {

    }

    public override void OnStart()
    {
        Debug.Log("StateWalk");

        // Начать анимацию.
    }

    public override void OnUpdate()
    {
        //RecoveryDash();
        float rotateY = controller.Player.transform.rotation.eulerAngles.y;
        Debug.Log(rotateY);
        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
        {
            controller.Switch(new HealthStayPlayerState(Machine));
        }
        if (Input.GetMouseButtonDown(0))
        {
            controller.Switch(new ShootAndWalkPlayerState(Machine));
        }
        if (controller.Player.PlayerSelf.Health <= 0f)
        {
            controller.Switch(new DeathPlayerState(Machine));
        }
    }
    public void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float rotateY = controller.Player.transform.rotation.eulerAngles.y;
        Debug.Log(rotateY);
        if (rotateY <= 315 && rotateY > 225)
        {
            controller.Player.Animator.SetFloat("RunHorizontal", -moveVertical);
            controller.Player.Animator.SetFloat("RunVertical", -moveHorizontal);
        }
        else if (rotateY > 45 && rotateY <= 135)
        {
            controller.Player.Animator.SetFloat("RunHorizontal", moveVertical);
            controller.Player.Animator.SetFloat("RunVertical", moveHorizontal);
        }
        else if (rotateY > 135 && rotateY <= 225)
        {
            controller.Player.Animator.SetFloat("RunHorizontal", -moveHorizontal);
            controller.Player.Animator.SetFloat("RunVertical", -moveVertical);
        }
        else
        {
            controller.Player.Animator.SetFloat("RunHorizontal", moveHorizontal);
            controller.Player.Animator.SetFloat("RunVertical", moveVertical);
        }



        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;


        if (Input.GetKey(KeyCode.LeftShift) && controller.Player.timer > 0f)
        {
            controller.Player.timer -= Time.deltaTime;
            controller.Player.rb.velocity = (movement * controller.Player.PlayerSelf.DashSpeed * 100 * Time.fixedDeltaTime);
        }
        else
        {
            controller.Player.rb.velocity = (movement * controller.Player.PlayerSelf.Speed * 100 * Time.fixedDeltaTime);
            controller.Player.timer += 0.07f * Time.fixedDeltaTime;
            controller.Player.timer = Mathf.Clamp(controller.Player.timer, 0, controller.Player.PlayerSelf.ReloadTimeForDash);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    controller.Player.rb.AddForce(Vector3.Lerp(movement, movement * controller.Player.PlayerSelf.DashSpeed * 100, 0.25f), ForceMode.VelocityChange);
        //}

    }
    //public void RecoveryDash()
    //{
    //    wait ??= new WaitForSeconds(controller.Player.PlayerSelf.TimeForDash);
    //    if (controller.Player.timer <= 0)
    //    {
    //        controller.Player.DelaySprint(DelayDash());
    //    }
    //}

    //public IEnumerator DelayDash()
    //{
    //    yield return wait;
    //    controller.Player.timer = controller.Player.PlayerSelf.ReloadTimeForDash;
    //    controller.Player.coroutineDash = null;
    //}

    public override void OnFixedUpdate()
    {
        Move();
    }
}
