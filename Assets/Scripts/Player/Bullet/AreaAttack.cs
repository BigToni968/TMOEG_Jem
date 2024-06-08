using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttack : BulletBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageHit>(out IDamageHit hit))
        {
            // ме асдер!
        }
    }
}