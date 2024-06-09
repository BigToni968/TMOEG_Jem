using MyStateMachine = Patterns.StateMachine;
using UnityEngine;

namespace Game
{
    public class EnemyStateCloseCombatAttackAndFollov : EnemyStateCLoseCombatAttack
    {
        public EnemyStateCloseCombatAttackAndFollov(MyStateMachine machine) : base(machine)
        {
        }

        public override void Update()
        {
            if (Vector3.Distance(Control.Owner.transform.position, Control.Player.transform.position) > CloseCombatMode.ReadData.Distance)
            {
                Control.Switch(new EnemyStateCloseCombatFollov(Control));
            }
        }
    }
}