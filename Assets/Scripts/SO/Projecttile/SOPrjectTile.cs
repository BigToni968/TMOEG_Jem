using System.Collections.Generic;
using UnityEngine;
using Patterns;
using System;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/ProjectTile")]
    public class SOPrjectTile : ScriptableObject
    {
        [field: SerializeField] public ProjectTileModel Model { get; private set; }
    }

    [Serializable]
    public class ProjectTileModel : Model<ProjectTileData> { }

    [Serializable]
    public struct ProjectTileData
    {
        public EnemyProjectile Prefab;
        public float Speed;
        public float Damage;
        public float TimeLife;
        public AudioClip SoundOnDestroy;
        public bool IsFrendlyFire;
        public List<FrendlyFireList> frendlyFireLists;
    }

    [Serializable]
    public struct FrendlyFireList
    {
        public Character Character;
        public float Damage;
        public AudioClip SoundOnDestroy;
    }
}