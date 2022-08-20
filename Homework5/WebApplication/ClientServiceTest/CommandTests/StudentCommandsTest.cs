using ClientService.StudentCommands;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using Moq;
using NUnit.Framework;
using SchoolModels;
using StudentRequests;
using StudentResponses;

namespace ClientServiceTest
{
    [TestFixture]
    public class StudentCommandsTest
    {
        [Test]
        public void ExecuteAsyncCreate()
        {
            ValidationResult validationResult = new();
            CreateStudentRequest request = new();

            var validatorMock = new Mock<IValidator<CreateStudentRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<CreateStudentRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<Guid?>>(request, default, default));

            CreateStudentCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<Guid?>>>(result);
        }

        [Test]
        public void ExecuteAsyncGet()
        {
            ValidationResult validationResult = new();
            GetStudentRequest request = new();

            var validatorMock = new Mock<IValidator<GetStudentRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<GetStudentRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<StudentModel>>(request, default, default));

            GetStudentCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<StudentModel>>>(result);
        }

        [Test]
        public void ExecuteAsyncUpdate()
        {
            ValidationResult validationResult = new();
            UpdateStudentRequest request = new();

            var validatorMock = new Mock<IValidator<UpdateStudentRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<UpdateStudentRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<Guid?>>(request, default, default));

            UpdateStudentCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<Guid?>>>(result);
        }

        [Test]
        public void ExecuteAsyncFind()
        {
            ValidationResult validationResult = new();
            FindStudentRequest request = new();

            var validatorMock = new Mock<IValidator<FindStudentRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<FindStudentRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<List<StudentModel>>>(request, default, default));

            FindStudentCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<List<StudentModel>>>>(result);
        }
    }
}