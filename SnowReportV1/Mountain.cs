using System;
using System.Collections.Generic;
using System.Text;

namespace SnowReportV1
{
    class Mountain
    {
        public string Name { get; }
        public string State { get; }
        //public string Snow { get; set; }

        public Mountain(string name, string state)
        {
            this.Name = name;
            this.State = state;
            //this.Snow = snow;
        }
    }
}
