using UnityEngine;

namespace Game.Data
{
    public abstract class CombatMode : ScriptableObject
    {
        [field: Header("Debug Tools")]
        [field: SerializeField] public bool Gizmo { get; private set; } = false;
        [field: SerializeField] public Color ColorTargetCastProjectile { get; private set; } = Color.blue;
        [field: SerializeField] public float Radius { get; private set; } = 0.25f;
    }
}