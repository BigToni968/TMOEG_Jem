using MyStateMachine = Patterns.StateMachine;
using UnityEngine;
using Game.Data;

namespace Game
{
    public class EnemyStateCloseCombatBase : EnemyStateBase
    {
        public CloseCombatMode CloseCombatMode { get; private set; } = new();
        public LayerMask LayerTarget { get; protected set; }

        public EnemyStateCloseCombatBase(MyStateMachine machine) : base(machine)
        {
            LayerTarget = 1 << LayerMask.NameToLayer("Player");
            SOCloseCombatMode soCloseCombat = Control.Owner.Character.CombatMode as SOCloseCombatMode;
            CloseCombatMode.OnInit(soCloseCombat.Model.Copy());
        }

        public override void Update()
        {
            base.Update();
            if (Control.Owner.Stats.ReadData.HP <= 0)
            {
                Control.Switch(new EnemyStateCloseCombatDead(Control));
            }
        }
    }
}