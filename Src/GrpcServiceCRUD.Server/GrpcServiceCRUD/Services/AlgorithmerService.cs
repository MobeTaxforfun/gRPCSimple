using Grpc.Core;
using GrpcServiceCRUD.Protos;

namespace GrpcServiceCRUD.Services
{
    public class AlgorithmerService : Algorithmer.AlgorithmerBase
    {
        private readonly ILogger<AlgorithmerService> _logger;
        public AlgorithmerService(ILogger<AlgorithmerService> logger)
        {
            _logger = logger;
        }

        public override Task<SumTwoValue> AlgorithmAddition(AddTwoValue request, ServerCallContext context)
        {
            return Task.FromResult(new SumTwoValue
            {
                Sum = request.Addend + request.Augend
            });
        }
    }
}
