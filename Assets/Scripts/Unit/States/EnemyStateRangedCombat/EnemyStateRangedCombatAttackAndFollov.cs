using MyStateMachine = Patterns.StateMachine;
using UnityEngine;

namespace Game
{
    public class EnemyStateRangedCombatAttackAndFollov : EnemyStateCLoseCombatAttack
    {
        public EnemyStateRangedCombatAttackAndFollov(MyStateMachine machine) : base(machine)
        {
        }

        public override void Update()
        {
            if (Vector3.Distance(Control.Owner.transform.position, Control.Player.transform.position) > CloseCombatMode.ReadData.Distance)
            {
                Control.Switch(new EnemyStateRangedCombatFollov(Control));
            }
        }
    }
}