namespace MilitaryElite.Models.Interfaces
{
    internal interface IMission
    {
        public string CodeName { get; }
        public string MissionState { get; }

        public void CompleteMission();
    }
}
