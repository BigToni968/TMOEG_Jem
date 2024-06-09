using UnityEngine;
using Game.Data;

namespace Game
{
    public class UnitEnemy : Unit
    {
        [field: SerializeField] public bool Gizmo { get; private set; } = false;

        private SOCloseCombatMode _closeCombatModel;

        public override void Init()
        {
            base.Init();
            name = Character.name;

            if (Character.CombatMode == null)
            {
                return;
            }

            Gizmo = Character.CombatMode.Gizmo;
            UnitControl = Character.CombatMode.GetType() == typeof(CloseCombatMode) ? new EnemyCloseCombatControl() : new EnemyRangedCombatControl();
            UnitControl?.Init(this);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (UnitControl != null && UnitControl.Player != null)
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
                _closeCombatModel ??= Character.CombatMode as SOCloseCombatMode;

                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, _closeCombatModel.Model.ReadData.RangeAttack);
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, _closeCombatModel.Model.ReadData.Distance);
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(transform.position, transform.position + transform.forward * Character.ObstacleDetectionDistance);
            }
        }

        private void Update()
        {
            if (UnitControl.Current.GetType() != typeof(EnemyStateCloseCombatDead))
            {
                OnUpdate();
            }
        }
    }
}