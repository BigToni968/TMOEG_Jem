namespace Game
{
    public class EnemyCloseCombatControl : UnitControl
    {
        public override void Init(Unit data)
        {
            base.Init(data);
            Switch(new EnemyStateCloseCombatIdle(this));
        }
    }
}