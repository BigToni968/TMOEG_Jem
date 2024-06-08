using Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyStateCloseCombatBase : EnemyStateBase
    {
        public CloseCombatMode CloseCombatMode { get; private set; }

        public EnemyStateCloseCombatBase(Patterns.StateMachine machine) : base(machine)
        {
            SOCloseCombatMode soCloseCombat = Control.Owner.Character.CombatMode as SOCloseCombatMode;
            CloseCombatMode.OnInit(soCloseCombat.Model.Copy());
            CloseCombatMode.Data.SpeedAttack = -150;
        }
    }
}