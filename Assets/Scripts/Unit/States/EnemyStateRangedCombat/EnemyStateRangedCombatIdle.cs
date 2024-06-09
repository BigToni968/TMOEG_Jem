using SMState = Patterns.State;
using UnityEngine;

namespace Game
{
    public class EnemyStateRangedCombatIdle : EnemyStateRangedCombatBase
    {

        public EnemyStateRangedCombatIdle(Patterns.StateMachine machine) : base(machine)
        {
        }

        public override void Update()
        {
            base.Update();


            if (Control.Player == null)
            {
                StayFind();
                return;
            }

            if (Control.Player)
            {
                Control.Switch(new EnemyStateRangedCombatFollov(Control));
            }
        }

        public void StayFind()
        {
            Collider[] all = Physics.OverlapSphere(Control.Owner.transform.position, CloseCombatMode.Data.RangeAttack, LayerTarget);

            if (all.Length > 0)
            {
                Control.Player = all[0].TryGetComponent<Player>(out Player player) ? player : Control.Player;
            }
        }
    }
}