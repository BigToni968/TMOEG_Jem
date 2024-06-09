using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelcroAttack : BulletBase
{
    public WaitForSeconds wait;
    public IDamageHit hit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageHit>(out IDamageHit hit))
        {
            wait = new WaitForSeconds(2);
            IsMove = false;
            transform.SetParent(other.transform);
            rb.isKinematic = true;
            StartCoroutine(DelayAttack(hit));
        }
        else if (other.GetComponent<Collider>() && !other.GetComponent<Player>() && !other.GetComponent<BulletBase>())
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator DelayAttack(IDamageHit hit)
    {
        while (true)
        {
            yield return wait;
            hit.Take(Bullet.Damage);
        }
    }
}
