using System;

namespace WpfApp1.Models
{
    public class Sample2 : ISample
    {
        public Sample2()
        {
            this.InstanceId = Guid.NewGuid();
        }

        public Guid InstanceId { get; set; }

        public string GetContents(string message)
        {
            return $"[Sample2]:{message}";
        }
    }
}
