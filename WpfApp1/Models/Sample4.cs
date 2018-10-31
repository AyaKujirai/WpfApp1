using System;

namespace WpfApp1.Models
{
    public interface ISample4
    {
        Guid InstanceId { get; set; }

        string GetContents(string message);
    }

    public class Sample4 : ISample4
    {
        public Sample4()
        {
            this.InstanceId = Guid.NewGuid();
        }

        public Guid InstanceId { get; set; }

        public string GetContents(string message)
        {
            return $"[Sample4]:{message}";
        }
    }
}
