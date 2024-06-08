using UnityEngine;

namespace Game.Data
{
    public abstract class CombatMode : ScriptableObject
    {
        [field: SerializeField] public bool Gizmo { get; private set; } = false;
    }
}