using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPipeline.Core.Pipeline.Nodes
{
    public abstract class BaseNode : IPipelineNode
    {
        public object InputPin { get; set; }
        public object OutputPin { get { return this.Process(this.InputPin); } }

        protected abstract object Process(object input);
    }
}
