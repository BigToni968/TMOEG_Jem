using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WalkPlayerState : State
{
    public PlayerController controller;
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
        
        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
        {
            controller.Switch(new HealthStayPlayerState(Machine));
        }
        if (Input.GetMouseButtonDown(0))
        {
            controller.Switch(new ShootAndWalkPlayerState(Machine));
        }
        if (controller.Player.PlayerSelf.Health <=  0f)
        {
            controller.Switch(new DeathPlayerState(Machine));
        }
    }
    public void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal == 1)
        {
            controller.Player.Animator.SetTrigger("IsLeftRun");
        }
        if (moveHorizontal != -1)
        {
            controller.Player.Animator.SetTrigger("IsRightRun");
        }
        if (moveVertical == 1)
        {
            controller.Player.Animator.SetTrigger("IsForwardRun");
        }
        if (moveVertical == -1)
        {
            controller.Player.Animator.SetTrigger("IsBackRun");
        }
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    controller.Player.transform.Translate(movement * controller.Player.PlayerSelf.SprintSpeed * Time.deltaTime);
        //}

        controller.Player.rb.velocity = (movement * controller.Player.PlayerSelf.Speed * 100 * Time.fixedDeltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //controller.Player.rb.AddForce(Vector3.Lerp(movement, movement * controller.Player.PlayerSelf.DashSpeed * 100, 0.25f), ForceMode.VelocityChange);
            controller.Player.rb.velocity = Vector3.Lerp(movement, movement * controller.Player.PlayerSelf.DashSpeed * 100, 0.25f);

        }

    }

    public override void OnFixedUpdate()
    {
        Move();
    }
}
