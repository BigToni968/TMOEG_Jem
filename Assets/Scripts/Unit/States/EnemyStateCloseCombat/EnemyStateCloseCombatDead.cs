using MyStateMachine = Patterns.StateMachine;
using UnityEngine;

namespace Game
{
    public class EnemyStateCloseCombatDead : EnemyStateCloseCombatBase
    {
        public EnemyStateCloseCombatDead(MyStateMachine machine) : base(machine)
        {
        }

        public override void Start()
        {
            base.Start();
            GameObject.Destroy(Control.Owner.gameObject, Control.Owner.Character.DelayDestroyAfterDeath);
        }
    }
}