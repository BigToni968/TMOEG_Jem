using MyStateMachine = Patterns.StateMachine;
using UnityEngine;
using Game.Data;

namespace Game
{
    public class EnemyStateRangedCombatBase : EnemyStateBase
    {
        public RangedCombatMode RangeCombatMode { get; private set; } = new();
        public LayerMask LayerTarget { get; protected set; }

        public EnemyStateRangedCombatBase(MyStateMachine machine) : base(machine)
        {
            LayerTarget = 1 << LayerMask.NameToLayer("Player");
            SORangedCombatMode soRangedCombat = Control.Owner.Character.CombatMode as SORangedCombatMode;
            RangeCombatMode.OnInit(soRangedCombat.Model.Copy());
        }

        public override void Update()
        {
            base.Update();
            if (Control.Owner.Stats.ReadData.HP <= 0)
            {
                Control.Switch(new EnemyStateRangedCombatDead(Control));
            }
        }
    }
}