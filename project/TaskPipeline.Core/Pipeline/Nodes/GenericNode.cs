using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPipeline.Core.Pipeline.Nodes
{
    public class GenericNode : BaseNode
    {
        protected Func<object, object> ProcHandler { get; set; }

        public GenericNode(Func<object, object> proc)
        {
            this.ProcHandler = proc;
        }

        protected override object Process(object input)
        {
            return this.ProcHandler(input);
        }
    }
}
