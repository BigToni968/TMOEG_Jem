using UnityEngine;
using Patterns;
using System;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/CombatMode/" + nameof(SOCloseCombatMode))]
    public class SOCloseCombatMode : CombatMode
    {
        [field: Header("��������� ������� ���")]
        [field: SerializeField] public CloseCombatMode Model { get; private set; }
    }

    [Serializable]
    public class CloseCombatMode : Model<CloseCombatData> { }

    [Serializable]
    public struct CloseCombatData
    {
        public float SpeedAttack;
        public float RangeAttack;
        public float Damage;
        [Tooltip("��������� �� ������� ����� ������� � ������ ����� ���� ����������")]
        public float Distance;
        public float Aiming;
    }
}