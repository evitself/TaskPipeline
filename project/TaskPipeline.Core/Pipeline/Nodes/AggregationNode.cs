using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPipeline.Core.Pipeline.Nodes
{
    public class AggregationNode<TItem> : BaseNode
    {
        protected override object Process(object input)
        {
            var source = input as IEnumerable<IEnumerable<TItem>>;
            if (source == null)
            {
                return Enumerable.Empty<TItem>();
            }
            return source.SelectMany(items => items.ToList());
        }
    }
}
