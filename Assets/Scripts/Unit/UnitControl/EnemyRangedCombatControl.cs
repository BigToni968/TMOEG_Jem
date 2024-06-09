namespace Game
{
    public class EnemyRangedCombatControl : UnitControl
    {
        public override void Init(Unit data)
        {
            base.Init(data);
            Switch(new EnemyStateRangedCombatIdle(this));
        }
    }
}