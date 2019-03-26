namespace TP_EveTools.Core.Domain
{
    public class AllianceCount
    {
        public int AllyId { get; set; }
        public string AllyName { get; set; }
        public int AllyCount { get; set; }
        public void Increase()
        {
            this.AllyCount += 1;
        }
    }
}