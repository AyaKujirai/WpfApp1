﻿using System;

namespace WpfApp1.Models
{
    public interface ISample3
    {
        Guid InstanceId { get; set; }

        string GetContents(string message);
    }

    public class Sample3 : ISample3
    {
        public Sample3()
        {
            this.InstanceId = Guid.NewGuid();
        }

        public Guid InstanceId { get; set; }

        public string GetContents(string message)
        {
            return $"[Sample3]:{message}";
        }
    }
}
