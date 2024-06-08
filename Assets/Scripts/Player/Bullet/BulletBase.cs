using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public ModelBullet Bullet;
    public Vector3 direction;
    public virtual void Move()
    {
        rb.velocity += direction * Bullet.Speed;
    }
    private void Update()
    {
        Move();
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
