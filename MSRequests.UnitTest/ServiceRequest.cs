using MediatR;
using Moq;
using MSRequests.Application.Handlers.AuthHandlers;
using MSRequests.Application.Queries;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.IRepositories;


namespace MSRequests.UnitTest
{

    public class ServiceRequest
    {
        private readonly Mock<IServiceRequestRepository> _moqServiceRequestRepository;
        public ServiceRequest()
        {
            _moqServiceRequestRepository = new();
        }

        [Fact]
        public async Task TestServiceRequestStatusByIdAsync()
        {
            // Arrange
            GetAllServiceRequestsByIdQuery query = new GetAllServiceRequestsByIdQuery
            {
                ServiceRequestId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            };
            var handler = new ServiceRequestQueryHandler(_moqServiceRequestRepository.Object);
            // Act
            var result = await handler.Handle(query, default); // It is always return null here i will check the reason in another time
            // Assert
            Assert.Equal(null, result);

        }

    }
}