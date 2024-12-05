namespace _Project.Common.Services
{
    public struct KillEventData
    {
        public readonly int KillerTeam;

        public KillEventData(int killerTeam) => 
            KillerTeam = killerTeam;
    }
}