using UnityEngine;
using Game.Data;
using System;

namespace Game
{
    public class UnitEnemy : Unit
    {
        [field: SerializeField] public bool Gizmo { get; private set; } = false;

        private SOCloseCombatMode _closeCombatModel;
        private SORangedCombatMode _rangedCombatMode;
        public override void Init()
        {
            base.Init();
            name = Character.name;

            if (Character.CombatMode == null)
            {
                return;
            }

            Gizmo = Character.CombatMode.Gizmo;
            UnitControl = Character.CombatMode.GetType() == typeof(SOCloseCombatMode) ? new EnemyCloseCombatControl() : new EnemyRangedCombatControl();
            UnitControl?.Init(this);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (UnitControl != null && UnitControl.Player != null && UnitControl.Owner.Stats.ReadData.HP > 0f)
            {
                LookToPlayer();
            }
        }

        public override void Take(float damage)
        {
            base.Take(damage);

            if (Character.DamageHitOnDead)
            {
                Stats.Data.HP = 0;
                return;
            }

            float heal = Stats.ReadData.HP - damage;
            Stats.Data.HP = Mathf.Clamp(heal, 0, Stats.ReadData.MaxHP);
        }

        public void LookToPlayer()
        {
            Vector3 targetPosition = UnitControl.Player.transform.position;
            targetPosition.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Stats.ReadData.RotateSpeed * Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            if (Gizmo && Character.CombatMode != null)
            {
                if (Character.CombatMode.GetType() == typeof(SOCloseCombatMode))
                {
                    _closeCombatModel ??= Character.CombatMode as SOCloseCombatMode;

                    Gizmos.color = Color.green;
                    Gizmos.DrawWireSphere(transform.position, _closeCombatModel.Model.ReadData.RangeAttack);
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(transform.position, _closeCombatModel.Model.ReadData.Distance);
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawWireSphere(transform.position, _closeCombatModel.Model.ReadData.Distance);
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawLine(transform.position, transform.position + transform.forward * Character.ObstacleDetectionDistance);
                    return;
                }

                if (Character.CombatMode.GetType() == typeof(SORangedCombatMode))
                {
                    _rangedCombatMode = Character.CombatMode as SORangedCombatMode;

                    Gizmos.color = Color.green;
                    Gizmos.DrawWireSphere(transform.position, _rangedCombatMode.Model.ReadData.DetectionRange);
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(transform.position, _rangedCombatMode.Model.ReadData.RangeAttack);
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawWireSphere(transform.position, _rangedCombatMode.Model.ReadData.RangeDistance);
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawLine(transform.position, transform.position + transform.forward * Character.ObstacleDetectionDistance);
                    return;
                }
            }
        }

        private void Update()
        {
            OnUpdate();
        }
    }
}