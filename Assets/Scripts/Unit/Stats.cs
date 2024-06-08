using Patterns;
using System;

namespace Game
{
    [Serializable]
    public struct StatsData
    {
        public int HP;
        public int MaxHP;
        public int Speed;
    }

    [Serializable]
    public class Stats : Model<StatsData>
    {
    }
}