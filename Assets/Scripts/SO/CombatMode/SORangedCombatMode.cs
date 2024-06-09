using UnityEngine;
using Patterns;
using System;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/CombatMode/" + nameof(SORangedCombatMode))]
    public class SORangedCombatMode : CombatMode
    {
        [field: Header("��������� �������� ���")]
        [field: SerializeField] public RangedCombatMode Model { get; private set; }
    }

    [Serializable]
    public class RangedCombatMode : Model<RangedCombatData> { }

    [Serializable]
    public struct RangedCombatData
    {
        [Tooltip("������")] public SOPrjectTile PrjectTile;
        [Tooltip("����������������")] public float SpeedAttack;
        [Tooltip("��������� ��������� ����� �������")] public float RangeDistance;
        [Tooltip("������� � ������� �� �������")] public float RangeAttack;
        [Tooltip("������� ����������� ������")] public float DetectionRange;
        [Tooltip("����� ����� ���, ��������")] public float DelayBeetwenAttacks;
        [Tooltip("����� ����� ������ ����")] public float Aiming;
    }
}