using UnityEngine;
using Patterns;
using System;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/CombatMode/" + nameof(SORangedCombatMode))]
    public class SORangedCombatMode : CombatMode
    {
        [field: Header("Настройка дальнего боя")]
        [field: SerializeField] public RangedCombatMode Model { get; private set; }
    }

    [Serializable]
    public class RangedCombatMode : Model<RangedCombatData> { }

    [Serializable]
    public struct RangedCombatData
    {
        public float SpeedAttack;
        public float RangeDistance;
        public float RangeAttack;
        public float DelayBeetwenAttacks;
        public float Aiming;
    }
}