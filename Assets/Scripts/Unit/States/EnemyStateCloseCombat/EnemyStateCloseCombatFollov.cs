using MyStateMachine = Patterns.StateMachine;
using UnityEngine;

namespace Game
{
    public class EnemyStateCloseCombatFollov : EnemyStateCloseCombatBase
    {
        private LayerMask _bots;
        public EnemyStateCloseCombatFollov(MyStateMachine machine) : base(machine) { }

        public override void Start()
        {
            base.Start();
            _bots = 1 << LayerMask.NameToLayer("Enemy");
        }

        public override void Update()
        {
            base.Update();

            if (IsObstacle())
            {
                return;
            }

            Move();

            if (Vector3.Distance(Control.Owner.transform.position, Control.Player.transform.position) <= CloseCombatMode.ReadData.Distance)
            {
                Control.Switch(new EnemyStateCLoseCombatAttack(Control));
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