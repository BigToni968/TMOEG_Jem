using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "Characte", menuName = "Game/Data/Character")]
    public class Character : SOInitialization
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField, TextArea(5, 10)] public string Description { get; private set; }
        [field: SerializeField] public Sprite Portrate { get; private set; }
        [field: SerializeField] public Unit Prefab { get; private set; }
        [field: SerializeField] public CombatMode CombatMode { get; private set; }
        [field: SerializeField] public bool DamageHitOnDead { get; private set; }
        [field: SerializeField] public float DelayDestroyAfterDeath { get; private set; }
        [field: SerializeField] public float ObstacleDetectionDistance { get; private set; }
        [field: SerializeField] public Stats Stats { get; private set; }

        public override void Init()
        {
            base.Init();
        }
    }
}