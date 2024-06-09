using MyStateMachine = Patterns.StateMachine;
using UnityEngine;

namespace Game
{
    public class EnemyStateRangedCombatIdle : EnemyStateRangedCombatBase
    {
        public EnemyStateRangedCombatIdle(MyStateMachine machine) : base(machine)
        {
        }

        public override void Start()
        {
            base.Start();
            Control.Owner.Animator.SetTrigger("IsWalk");
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
            Collider[] all = Physics.OverlapSphere(Control.Owner.transform.position, RangeCombatMode.ReadData.DetectionRange, LayerTarget);

            if (all.Length > 0)
            {
                Control.Player = all[0].TryGetComponent<Player>(out Player player) ? player : Control.Player;
            }
        }
    }
}