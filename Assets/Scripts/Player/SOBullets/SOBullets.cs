using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "Data/Game/Bullets")]
public class SOBullets : ScriptableObject
{
    public ModelBullet[] ModelBullets;
}

[Serializable]
public struct ModelBullet
{
    public BulletBase Prefab;
    public float Speed;
    public float Damage;
    public float TimeLife;
}
