using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingAttack : BulletBase
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
    public override void Update()
    {
        base.Update();
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(3f, 3f, 3f), Time.deltaTime);
    }
}
