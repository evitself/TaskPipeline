using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPipeline.Core.Pipeline.Nodes
{
    public class RepeatNode<TItemIn, TItemOut> : BaseNode
    {
        protected IPipelineNode WorkerNode { get; set; }
        protected Func<TItemIn, bool> Predicate { get; set; }
        protected Func<TItemOut, bool> EnumerateBreaker { get; set; }

        public RepeatNode(IPipelineNode workerNode) : this(workerNode, null, null) { }
        public RepeatNode(IPipelineNode workerNode, Func<TItemIn, bool> predicate, Func<TItemOut, bool> enumerateBreaker)
        {
            this.WorkerNode = workerNode;
            this.Predicate = predicate;
            this.EnumerateBreaker = enumerateBreaker;
        }

        protected override object Process(object input)
        {
            var source = input as IEnumerable<TItemIn>;
            if (source == null)
            {
                return Enumerable.Empty<TItemOut>();
            }
            return this.ProcessInternal(source);
        }

        private IEnumerable<TItemOut> ProcessInternal(IEnumerable<TItemIn> input)
        {
            var source = this.Predicate == null ? input : input.Where(this.Predicate);
            foreach (var item in source)
            {
                this.WorkerNode.InputPin = item;
                var ret = (TItemOut)this.WorkerNode.OutputPin;
                if (this.EnumerateBreaker != null && this.EnumerateBreaker(ret))
                {
                    yield break;
                }
                yield return ret;
            }
        }
    }
}
