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
            hit.Take(Bullet.Damage);
        }
    }
}
