using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAttack : BulletBase
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
    }
}
