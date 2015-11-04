using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPipeline.Core.Pipeline.Nodes
{
    public class ChainNode : BaseNode
    {
        public IList<IPipelineNode> Nodes { get; set; }

        public ChainNode() { this.Nodes = new List<IPipelineNode>(); }
        public ChainNode(params IPipelineNode[] nodes) { this.Nodes = new List<IPipelineNode>(nodes); }

        protected override object Process(object input)
        {
            if (this.Nodes == null || this.Nodes.Count == 0)
            {
                throw new PipelineChainEmptyException();
            }
            
            this.Nodes[0].InputPin = input;
            for (int i = 1; i < this.Nodes.Count; i++)
            {
                this.Nodes[i].InputPin = this.Nodes[i - 1].OutputPin;
            }
            return this.Nodes[this.Nodes.Count - 1].OutputPin;
        }
    }
}
