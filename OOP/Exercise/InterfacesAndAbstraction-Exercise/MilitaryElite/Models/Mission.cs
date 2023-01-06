namespace MilitaryElite.Models
{
    using Interfaces;
    using System;

    internal class Mission : IMission
    {

        private string missionState;
        public Mission(string codeName, string missionState)
        {
            CodeName = codeName;
            MissionState = missionState;
        }

        public string CodeName { get; private set; }
        public string MissionState
        {
            get => missionState;
            private set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    missionState = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void CompleteMission() => MissionState = "Finished";

        public override string ToString() => $"Code Name: {CodeName} State: {MissionState}";
    }
}
