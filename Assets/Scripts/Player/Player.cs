using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Patterns;
using Random = UnityEngine.Random;

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
    public float timer = 3f;
    public Coroutine coroutineDash;

    private void Start()
    {
        if (Audio.Instance.FirstAttack.Length > 0)
        {
            Audio.Instance.Sound.clip = Audio.Instance.FirstAttack[Random.Range(0, Audio.Instance.FirstAttack.Length)];
        }
        Bullet = SOBullets.ModelBullets[index];
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
            if (Audio.Instance.FirstAttack.Length > 0)
            {
                Audio.Instance.Sound.clip = Audio.Instance.FirstAttack[Random.Range(0, Audio.Instance.FirstAttack.Length)];
            }
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (SOBullets.ModelBullets.Length < 2)
            {
                return;
            }
            Bullet = SOBullets.ModelBullets[1];
            index = 1;
            if (Audio.Instance.SecondaryAttack.Length > 0)
            {
                Audio.Instance.Sound.clip = Audio.Instance.SecondaryAttack[Random.Range(0, Audio.Instance.SecondaryAttack.Length)];
            }
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (SOBullets.ModelBullets.Length < 3)
            {
                return;
            }
            Bullet = SOBullets.ModelBullets[2];
            index = 2;
            if (Audio.Instance.ThertyAttack.Length > 0)
            {
                Audio.Instance.Sound.clip = Audio.Instance.ThertyAttack[Random.Range(0, Audio.Instance.ThertyAttack.Length)];
            }
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            if (SOBullets.ModelBullets.Length < 4)
            {
                return;
            }
            Bullet = SOBullets.ModelBullets[3];
            index = 3;
            if (Audio.Instance.FourthAttack.Length > 0)
            {
                Audio.Instance.Sound.clip = Audio.Instance.FourthAttack[Random.Range(0, Audio.Instance.FourthAttack.Length)];
            }
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            if (SOBullets.ModelBullets.Length < 5)
            {
                return;
            }
            Bullet = SOBullets.ModelBullets[4];
            index = 4;
            if (Audio.Instance.FiveAttack.Length > 0)
            {
                Audio.Instance.Sound.clip = Audio.Instance.FiveAttack[Random.Range(0, Audio.Instance.FiveAttack.Length)];
            }
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
        if (Bullet.Prefab.GetType() == typeof(StrongAttack))
        {
            for (int i = 0; i < 3; i++)
            {
                BulletBase bullet3 = Instantiate(Bullet.Prefab);
                if (i == 0)
                {
                    bullet3.transform.position = SpawnPos.position;
                    bullet3.transform.rotation = transform.rotation;
                    bullet3.transform.Rotate(new Vector3(-90f, 0f, -10f));
                    bullet3.Init(Bullet);
                    bullet3.direction = transform.forward;
                    PlayerSelf.Health -= Bullet.Price;
                    Audio.Instance.Sound.PlayOneShot(Audio.Instance.Sound.clip);
                }
                if (i == 1)
                {
                    bullet3.transform.position = SpawnPos.position;
                    bullet3.transform.rotation = transform.rotation;
                    bullet3.transform.Rotate(new Vector3(-90f, 0f, 0f));
                    bullet3.Init(Bullet);
                    bullet3.direction = transform.forward;


                }
                if (i == 2)
                {
                    bullet3.transform.position = SpawnPos.position;
                    bullet3.transform.rotation = transform.rotation;
                    bullet3.transform.Rotate(new Vector3(-90f, 0f, 10f));
                    bullet3.Init(Bullet);
                    bullet3.direction = transform.forward;

                }

            }
        }
        else
        {
            BulletBase bullet = Instantiate(Bullet.Prefab);
            bullet.transform.position = SpawnPos.position;
            bullet.transform.rotation = transform.rotation;
            bullet.transform.Rotate(new Vector3(-90f, 0f, 0f));
            bullet.Init(Bullet);
            bullet.direction = transform.forward;
            PlayerSelf.Health -= Bullet.Price;
            Audio.Instance.Sound.PlayOneShot(Audio.Instance.Sound.clip);
        }
    }
    public void ClearShoot()
    {
        IsShoot[index] = null;
    }
    public void DelaySprint(IEnumerator enumerator)
    {
        if (coroutineDash == null)
        {
            coroutineDash = StartCoroutine(enumerator);
        }
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
    public float ReloadTimeForDash;
    public float TimeForDash;
}