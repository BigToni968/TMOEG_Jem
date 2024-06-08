using UnityEngine.EventSystems;
using UnityEngine;
using Game.Data;

namespace Game
{
    public interface IUnit
    {
        public bool IsDead { get; }

        public Stats Stats { get; }
        public Animator Animator { get; }
        public Rigidbody Rigidbody { get; }
        public Character Character { get; }
        public EventSystem EventSystem { get; }
        public UnitControl UnitControl { get; }
    }

    public abstract class Unit : MonoInitialization, IUnit, IInitialization<Character>, IDamageHit
    {
        [field: SerializeField] public bool DamageHitOnDead { get; private set; }
        [field: SerializeField] public bool IsDead { get; protected set; } = false;
        [field: SerializeField] public Animator Animator { get; protected set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; protected set; }
        [field: SerializeField] public Stats Stats { get; protected set; }
        public Character Character { get; protected set; }
        public EventSystem EventSystem { get; private set; }
        public UnitControl UnitControl { get; protected set; }

        public virtual void Init(Character data)
        {
            Character = data;
            DamageHitOnDead = Character.DamageHitOnDead;
            Stats.Set((Character.Stats.Copy() as Stats).Data);
            Init();
        }

        public virtual void Take(float damage) { }
    }
}