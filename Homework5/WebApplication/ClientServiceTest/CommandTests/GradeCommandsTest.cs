using ClientService.GradeCommands;
using ClientService.StudentCommands;
using FluentValidation;
using FluentValidation.Results;
using GradeRequests;
using MassTransit;
using Moq;
using NUnit.Framework;
using SchoolModels;
using StudentRequests;
using StudentResponses;

namespace ClientServiceTest
{
    [TestFixture]
    public class GradeCommandsTest
    {
        [Test]
        public void ExecuteAsyncCreate()
        {
            ValidationResult validationResult = new();
            CreateGradeRequest request = new();

            var validatorMock = new Mock<IValidator<CreateGradeRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<CreateGradeRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<Guid?>>(request, default, default));

            CreateGradeCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<Guid?>>>(result);
        }

        [Test]
        public void ExecuteAsyncGet()
        {
            ValidationResult validationResult = new();
            GetGradeRequest request = new();

            var validatorMock = new Mock<IValidator<GetGradeRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<GetGradeRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<GradeModel>>(request, default, default));

            GetGradeCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<GradeModel>>>(result);
        }

        [Test]
        public void ExecuteAsyncUpdate()
        {
            ValidationResult validationResult = new();
            UpdateGradeRequest request = new();

            var validatorMock = new Mock<IValidator<UpdateGradeRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<UpdateGradeRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<Guid?>>(request, default, default));

            UpdateGradeCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<Guid?>>>(result);
        }

        [Test]
        public void ExecuteAsyncFind()
        {
            ValidationResult validationResult = new();
            FindGradeRequest request = new();

            var validatorMock = new Mock<IValidator<FindGradeRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<FindGradeRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<List<GradeModel>>>(request, default, default));

            FindGradeCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<List<GradeModel>>>>(result);
        }
    }
}