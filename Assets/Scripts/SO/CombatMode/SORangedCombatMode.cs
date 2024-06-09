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
        [Tooltip("Префаб")] public SOPrjectTile PrjectTile;
        [Tooltip("Скорострельность")] public float SpeedAttack;
        [Tooltip("Дистанция остановки перед игроком")] public float RangeDistance;
        [Tooltip("Область в которой мы атакуем")] public float RangeAttack;
        [Tooltip("Область обнаружения игрока")] public float DetectionRange;
        [Tooltip("Забыл зачем оно, простите")] public float DelayBeetwenAttacks;
        [Tooltip("Время перед серией атак")] public float Aiming;
    }
}