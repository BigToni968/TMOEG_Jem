using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    public Rigidbody rb;
    public ModelBullet Bullet;
    public Vector3 direction;
    public bool IsMove = true;
    public virtual void Move()
    {
        transform.Translate(direction * Bullet.Speed * Time.deltaTime);
    }
    public virtual void Update()
    {
        if (IsMove)
        {
            Move();
        }
        Remove();
    }
    public void Remove()
    {
        Bullet.TimeLife -= Time.deltaTime;
        if (Bullet.TimeLife < 0)
        {
            Destroy(gameObject);
        }
    }
    public void Init(ModelBullet model)
    {
        Bullet = model;
    }
    public virtual void Find() { }
}
