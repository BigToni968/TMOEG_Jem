using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Patterns;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public Animator Animator;
    public Rigidbody rb;
    public Transform SpawnPos;
    public SOBullets SOBullets;
    public ModelBullet Bullet;
    public ModelPlayer PlayerSelf;
    public Coroutine[] IsShoot;
    public int index = 0;

    private void Start()
    {
        Bullet = SOBullets.ModelBullets[0];
        Controller = new PlayerController(this);
        Controller.Switch(new HealthStayPlayerState(Controller));
        IsShoot = new Coroutine[4];
    }
    private void Update()
    {
        if (Controller.Current.GetType() == typeof(DeathPlayerState))
        {
            return;
        }
        LookToMouse();
        Controller.OnUpdate();
        ChangeBullets();
    }
    public void ChangeBullets()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Bullet = SOBullets.ModelBullets[0];
            index = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Bullet = SOBullets.ModelBullets[1];
            index = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Bullet = SOBullets.ModelBullets[2];
            index = 2;
        }
        Animator.SetFloat("AtakaSpeed", Bullet.DelayShoot);
    }

    private void FixedUpdate()
    {
        Controller.OnFixedUpdate();
    }

    public void Shoot(IEnumerator enumerator) // Не рабочий
    {
        if (IsShoot[index] == null)
        {
            IsShoot[index] = StartCoroutine(enumerator);
            BulletBase bullet = Instantiate(Bullet.Prefab);
            bullet.Init(Bullet);
            bullet.direction = transform.forward;
            PlayerSelf.Health -= Bullet.Price;
        }
    }
    public void ShootAoe()
    {
        BulletBase bullet = Instantiate(Bullet.Prefab);
        bullet.transform.position = SpawnPos.position;
        bullet.transform.rotation = transform.rotation;
        bullet.transform.Rotate(new Vector3(-90f, 0f, 0f));
        bullet.Init(Bullet);
        bullet.direction = transform.forward;
        PlayerSelf.Health -= Bullet.Price;
    }
    public void ClearShoot()
    {
        IsShoot[index] = null;
    }

    public void LookToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.down, rb.transform.position);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 targetPosition = ray.GetPoint(distance);
            targetPosition.y = rb.transform.position.y; // Устанавливаем Y координату объекта, чтобы сохранить высоту

            // Плавное вращение в сторону указателя мыши
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - rb.transform.position);
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, targetRotation, PlayerSelf.RotationSpeed * Time.deltaTime);
        }
    }
}

[Serializable]
public struct ModelPlayer
{
    public float MaxHealth;
    public float Health;
    public float Speed;
    public float DashSpeed;
    public float RotationSpeed;
    public float SprintSpeed;
    public float tickHealth;
    public float DelayHealth;
    public float HealthRecovery;
}