using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.UI.GridLayoutGroup;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public Animator Animator;
    public Rigidbody rb;
    public Transform SpawnPos;
    public SOBullets SOBullets;
    public ModelBullet Bullet;
    public ModelPlayer PlayerSelf;


    private void Start()
    {
        Bullet = SOBullets.ModelBullets[0];
        Controller = new PlayerController(this);
        Controller.Switch(new IdlePlayerState(Controller));
    }
    private void Update()
    {
        Controller.OnUpdate();
        ChangeBullets();
        //LookToMouse();
    }
    public void ChangeBullets()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Bullet = SOBullets.ModelBullets[0];
        }
         if (Input.GetKey(KeyCode.Alpha2))
        {
            Bullet = SOBullets.ModelBullets[1];
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Bullet = SOBullets.ModelBullets[2];
        }
    }
    public void Shoot()
    {
        BulletBase bullet = Instantiate(Bullet.Prefab, SpawnPos.position, Quaternion.identity);
        bullet.Init(Bullet);
        bullet.direction = transform.forward;
    }
    public void LookToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 targetPosition = ray.GetPoint(distance);
            targetPosition.y = transform.position.y; // Устанавливаем Y координату объекта, чтобы сохранить высоту

            // Плавное вращение в сторону указателя мыши
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerSelf.RotationSpeed * Time.deltaTime);
        }
    }
    public void PlayCoroutine(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }
}

[Serializable]
public struct ModelPlayer
{
    public float MaxHealth;
    public float Health;
    public float Speed;
    public float RotationSpeed;
    public float SprintSpeed;
    public float tickHealth;
    public float DelayHealth;
    public float HealthRecovery;
}
