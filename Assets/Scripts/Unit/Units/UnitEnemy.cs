using Game.Data;

namespace Game
{
    public class UnitEnemy : Unit
    {
        public override void Init()
        {
            base.Init();
            if (Character.CombatMode == null)
            {
                return;
            }

            UnitControl = Character.CombatMode.GetType() == typeof(CloseCombatMode) ? new EnemyCloseCombatControl() : new EnemyRangedCombatControl();
        }

        public override void Take(float damage)
        {
            base.Take(damage);

            if (Character.DamageHitOnDead)
            {
            }
        }
    }
}