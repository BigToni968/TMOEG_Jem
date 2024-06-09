using UnityEngine;
using System;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/" + nameof(GaleryResources))]
    public class GaleryResources : ScriptableObject
    {
        [field: SerializeField] public GaleryBox[] Resources { get; private set; }
    }

    [Serializable]
    public struct GaleryBox
    {
        public GameObject Model;
        public Character Character;
        public Vector3 Scale;
    }
}