using ClientService.MentorCommands;
using FluentValidation;
using FluentValidation.Results;
using MassTransit;
using MentorRequests;
using Moq;
using NUnit.Framework;
using SchoolModels;
using StudentResponses;

namespace ClientServiceTest
{
    [TestFixture]
    public class MentorCommandsTest
    {
        [Test]
        public void ExecuteAsyncCreate()
        {
            ValidationResult validationResult = new();
            CreateMentorRequest request = new();

            var validatorMock = new Mock<IValidator<CreateMentorRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<CreateMentorRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<Guid?>>(request, default, default));

            CreateMentorCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<Guid?>>>(result);
        }

        [Test]
        public void ExecuteAsyncGet()
        {
            ValidationResult validationResult = new();
            GetMentorRequest request = new();

            var validatorMock = new Mock<IValidator<GetMentorRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<GetMentorRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<MentorModel>>(request, default, default));

            GetMentorCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<MentorModel>>>(result);
        }

        [Test]
        public void ExecuteAsyncUpdate()
        {
            ValidationResult validationResult = new();
            UpdateMentorRequest request = new();

            var validatorMock = new Mock<IValidator<UpdateMentorRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<UpdateMentorRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<Guid?>>(request, default, default));

            UpdateMentorCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<Guid?>>>(result);
        }

        [Test]
        public void ExecuteAsyncFind()
        {
            ValidationResult validationResult = new();
            FindMentorRequest request = new();

            var validatorMock = new Mock<IValidator<FindMentorRequest>>();
            validatorMock.Setup(x => x.Validate(request)).Returns(validationResult);

            var requestMock = new Mock<IRequestClient<FindMentorRequest>>();
            requestMock.Setup(x => x.GetResponse<BrokerResponse<List<MentorModel>>>(request, default, default));

            FindMentorCommand command = new(validatorMock.Object, requestMock.Object);

            var result = command.ExecuteAsync(request);

            Assert.IsAssignableFrom<Task<BrokerResponse<List<MentorModel>>>>(result);
        }
    }
}