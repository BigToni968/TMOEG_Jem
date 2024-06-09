using MyStateMachine = Patterns.StateMachine;
using UnityEngine;

namespace Game
{
    public class EnemyStateRangedCombatDead : EnemyStateRangedCombatBase
    {
        public EnemyStateRangedCombatDead(MyStateMachine machine) : base(machine)
        {
        }

        public override void Start()
        {
            base.Start();
            Control.Player = null;
            GameObject.Destroy(Control.Owner.gameObject, Control.Owner.Character.DelayDestroyAfterDeath);
        }
    }
}