using System;

namespace WpfApp1.Models
{
    public interface ISample
    {
        Guid InstanceId { get; set; }

        string GetContents(string message);
    }

    public class Sample : ISample
    {
        public Sample()
        {
            this.InstanceId = Guid.NewGuid();
        }

        public Guid InstanceId { get; set; }

        public string GetContents(string message)
        {
            return $"[Sample]:{message}";
        }
    }
}
