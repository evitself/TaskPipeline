using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPipeline.Core.Pipeline.Nodes
{
    public static class Extensions
    {
        public static RepeatNode<TItemIn, TItemOut> GetRepeatNode<TItemIn, TItemOut>(this IPipelineNode node)
        {
            return new RepeatNode<TItemIn, TItemOut>(node);
        }

        public static RepeatNode<TItemIn, TItemOut> GetRepeatNode<TItemIn, TItemOut>(
            this IPipelineNode node,
            Func<TItemIn, bool> predicate,
            Func<TItemOut, bool> enumerateBreaker)
        {
            return new RepeatNode<TItemIn, TItemOut>(node, predicate, enumerateBreaker);
        }

        public static TOutput Spin<TInput, TOutput>(this IPipelineNode node, TInput input)
        {
            node.InputPin = input;
            return (TOutput)node.OutputPin;
        }
    }
}
