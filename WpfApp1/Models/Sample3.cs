using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public interface ISample3
    {
        string GetContents(string message);

        Guid InstanceID();
    }
    public class Sample3 : ISample3
    {
        private Guid instanceID;

        public Sample3()
        {
            this.instanceID = Guid.NewGuid();
        }

        public string GetContents(string message)
        {
            return $"[Sample3]:{message}";
        }

        public Guid InstanceID()
        {
            return this.instanceID;
        }
    }
}
