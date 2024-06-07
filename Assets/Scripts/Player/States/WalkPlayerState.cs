using System.Collections;
using System.Collections.Generic;
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
        Move();
        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
        {
            controller.Switch(new HealthStayPlayerState(Machine));
        }
        if (Input.GetMouseButtonDown(0))
        {
            controller.Switch(new ShootAndWalkPlayerState(Machine));
        }
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Player.transform.Translate(movement * controller.Player.PlayerSelf.SprintSpeed * Time.deltaTime);
        }
        else
        {
            controller.Player.transform.Translate(movement * controller.Player.PlayerSelf.Speed * Time.deltaTime);
        }

    }    
}
