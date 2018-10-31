using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface ISample
    {
        string GetContents(string message);

        Guid InstanceID();
    }
    public class Sample : ISample
    {
        private Guid instanceID;

        public Sample()
        {
            this.instanceID = Guid.NewGuid();
        }

        public string GetContents(string message)
        {
            return $"[Sample]:{message}";
        }

        public Guid InstanceID()
        {
            return this.instanceID;
        }
    }

    public class Sample2 : ISample
    {
        private Guid instanceID;

        public Sample2()
        {
            this.instanceID = Guid.NewGuid();
        }

        public string GetContents(string message)
        {
            return $"[Sample2]:{message}";
        }

        public Guid InstanceID()
        {
            return this.instanceID;
        }
    }
}
