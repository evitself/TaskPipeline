using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPipeline.Core.Pipeline
{
    public class PipelineChainEmptyException : Exception
    {
        public PipelineChainEmptyException() : base() { }
        public PipelineChainEmptyException(string message) : base(message) { }
    }

    public class PipelineInputPinException : Exception
    {
        public PipelineInputPinException() : base() { }
        public PipelineInputPinException(string message) : base(message) { }
        public PipelineInputPinException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class PipelineOutputPinException : Exception
    {
        public PipelineOutputPinException() : base() { }
        public PipelineOutputPinException(string message) : base(message) { }
        public PipelineOutputPinException(string message, Exception innerException) : base(message, innerException) { }
    }
}
