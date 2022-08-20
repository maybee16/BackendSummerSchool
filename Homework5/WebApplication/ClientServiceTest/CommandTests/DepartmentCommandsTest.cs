using ClientService.DepartmentCommands;
using ClientService.DepartmentRequests;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using Moq;
using NUnit.Framework;
using SchoolModels;
using StudentResponses;

namespace ClientServiceTest
{
    [TestFixture]
    public class DepartmentCommandsTest
    {
        [Test]
        public void ExecuteAsyncCreate()
        {
            ValidationResult validationResult = new();
            CreateDepartmentRequest request = new();

            var validatorMock = new Mock<IValidator<CreateDepartmentRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<CreateDepartmentRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<Guid?>>(request, default, default));

            CreateDepartmentCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<Guid?>>>(result);
        }

        [Test]
        public void ExecuteAsyncGet()
        {
            ValidationResult validationResult = new();
            GetDepartmentRequest request = new();

            var validatorMock = new Mock<IValidator<GetDepartmentRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<GetDepartmentRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<DepartmentModel>>(request, default, default));

            GetDepartmentCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<DepartmentModel>>>(result);
        }

        [Test]
        public void ExecuteAsyncUpdate()
        {
            ValidationResult validationResult = new();
            UpdateDepartmentRequest request = new();

            var validatorMock = new Mock<IValidator<UpdateDepartmentRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<UpdateDepartmentRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<Guid?>>(request, default, default));

            UpdateDepartmentCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<Guid?>>>(result);
        }

        [Test]
        public void ExecuteAsyncFind()
        {
            ValidationResult validationResult = new();
            FindDepartmentRequest request = new();

            var validatorMock = new Mock<IValidator<FindDepartmentRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<FindDepartmentRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<List<DepartmentModel>>>(request, default, default));

            FindDepartmentCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<List<DepartmentModel>>>>(result);
        }
    }
}