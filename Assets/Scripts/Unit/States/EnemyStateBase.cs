using MyStateMachine = Patterns.StateMachine;
using SMState = Patterns.State;

namespace Game
{
    public abstract class EnemyStateBase : SMState
    {
        private protected UnitControl Control;

        public EnemyStateBase(MyStateMachine machine)
        {
            Machine = machine;
            Control = machine as UnitControl;
        }
    }
}