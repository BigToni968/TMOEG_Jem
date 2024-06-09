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
        [Tooltip("����������������")]public float SpeedAttack;
        [Tooltip("������� ����������� ������ ��� �������������")] public float RangeAttack;
        public float Damage;
        [Tooltip("��������� �� ������� ����� ������� � ������ ����� ���� ����������")]
        public float Distance;
        [Tooltip("�������� ����� ������ ������.")] public float Aiming;
    }
}