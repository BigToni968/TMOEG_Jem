using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardAttack : BulletBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageHit>(out IDamageHit hit))
        {
            Bullet.MaxCountEnemy--;
            hit.Take(Bullet.Damage);
            if (Bullet.MaxCountEnemy <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (other.GetComponent<Collider>() && !other.GetComponent<Player>() && !other.GetComponent<BulletBase>())
        {
            Destroy(gameObject);
        }
    }
}
