namespace TP_EveTools.Core.Domain
{
    public class AllianceCount
    {
        public string AllyName { get; set; }
        public int AllyCount { get; set; }
        public void Increase()
        {
            this.AllyCount += 1;
        }
    }
}