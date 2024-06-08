using MyStateMachine = Patterns.StateMachine;

namespace Game
{
    public abstract class UnitControl : MyStateMachine, IInitialization<Unit>
    {
        public Player Player { get; set; }
        public Unit Owner { get; private set; }

        public virtual void Init(Unit data)
        {
            Owner = data;
            Switch(new EnemyStateCloseCombatIdle(this));
        }
    }
}