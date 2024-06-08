using Patterns;
using System;

namespace Game
{
    [Serializable]
    public struct StatsData
    {
        public float HP;
        public float MaxHP;
        public float Speed;
        public float RotateSpeed;
    }

    [Serializable]
    public class Stats : Model<StatsData>
    {
    }
}