using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPipeline.Core.Pipeline
{
    public interface IPipelineNode
    {
        object InputPin { get; set; }
        object OutputPin { get; }
    }
}
