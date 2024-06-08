using SMState = Patterns.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyStateCloseCombatIdle : EnemyStateBase
    {

        public EnemyStateCloseCombatIdle(Patterns.StateMachine machine) : base(machine)
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public void StayFind()
        {

        }
    }
}