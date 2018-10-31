using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public interface ISample4
    {
        string GetContents(string message);

        Guid InstanceID();
    }
    public class Sample4 : ISample4
    {
        private Guid instanceID;

        public Sample4()
        {
            this.instanceID = Guid.NewGuid();
        }

        public string GetContents(string message)
        {
            return $"[Sample4]:{message}";
        }

        public Guid InstanceID()
        {
            return this.instanceID;
        }
    }
}
