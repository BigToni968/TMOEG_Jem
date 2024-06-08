using MyStateMachine = Patterns.StateMachine;
using UnityEngine;

namespace Game
{
    public class EnemyStateCloseCombatFollov : EnemyStateCloseCombatBase
    {
        public EnemyStateCloseCombatFollov(MyStateMachine machine) : base(machine) { }

        public override void Update()
        {
            base.Update();
            Move();

            if (Vector3.Distance(Control.Owner.transform.position, Control.Player.transform.position) <= CloseCombatMode.ReadData.Distance)
            {
                Control.Switch(new EnemyStateCLoseCombatAttack(Control));
            }
        }

        public virtual void Move()
        {
            Control.Owner.Rigidbody.velocity = Control.Owner.transform.forward * Control.Owner.Stats.ReadData.Speed;
        }
    }
}