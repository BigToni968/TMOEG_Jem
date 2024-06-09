using MyStateMachine = Patterns.StateMachine;
using UnityEngine;

namespace Game
{
    public class EnemyStateRangedCombatAttackAndFollov : EnemyStateRangedCombatAttack
    {
        private LayerMask _bots;
        public EnemyStateRangedCombatAttackAndFollov(MyStateMachine machine) : base(machine)
        {
        }

        public override void Start()
        {
            base.Start();
            Control.Owner.Animator.SetTrigger("IsAttack");
            _bots = 1 << LayerMask.NameToLayer("Enemy");
        }

        public override void Update()
        {

            if (IsObstacle())
            {
                return;
            }

            Move();

            if (Vector3.Distance(Control.Owner.transform.position, Control.Player.transform.position) > RangeCombatMode.ReadData.RangeAttack)
            {
                Control.Switch(new EnemyStateRangedCombatFollov(Control));
            }

            if (Vector3.Distance(Control.Owner.transform.position, Control.Player.transform.position) < RangeCombatMode.ReadData.RangeDistance)
            {
                Control.Switch(new EnemyStateRangedCombatAttack(Control));
            }

            if (_coroutineAiming == null && _coroutineAttack == null)
            {
                _coroutineAttack = Control.Player.StartCoroutine(Attack());
            }
        }

        public virtual void Move()
        {
            Control.Owner.transform.Translate(Vector3.forward * Control.Owner.Stats.ReadData.Speed * Time.deltaTime);
        }

        public virtual bool IsObstacle()
        {
            return Physics.Raycast(Control.Owner.transform.position, Control.Owner.transform.forward, Control.Owner.Character.ObstacleDetectionDistance, _bots);
        }
    }
}