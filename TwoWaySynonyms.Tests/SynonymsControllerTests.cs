using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TwoWaySynonyms.Controllers;
using TwoWaySynonyms.DataAccess.Dtos;
using TwoWaySynonyms.DataAccess.Repositories;
using Xunit;

namespace TwoWaySynonyms.Tests
{
    public class SynonymsControllerTests
    {
        private readonly Mock<ITermsAndSynonymsRepository> _termsAndSynonymsRepositoryMock = new Mock<ITermsAndSynonymsRepository>();
        private readonly TermWithSynonymsInput _termWithSynonymsInputStub = new TermWithSynonymsInput
        {
            Term = "Computer",
            Synonyms = "PC,Laptop"
        };
        private readonly List<Words> _wordsStub = new List<Words>
        {
            new Words("Computer", new List<string>
            {
                "PC",
                "Laptop"
            })
        };

        [Fact]
        public void When_TermWithSynonymsAreAdded_Then_RepositoryCallsAddNewTermWithSynonyms()
        {
            // Given
            var synonymsController = new SynonymsController(_termsAndSynonymsRepositoryMock.Object);

            // When
            synonymsController.AddNewTermWithSynonyms(_termWithSynonymsInputStub);

            // Then
            _termsAndSynonymsRepositoryMock.Verify(mock => mock.AddNewTermWithSynonyms(_termWithSynonymsInputStub), Times.Once);
        }

        [Fact]
        public void When_ValidTermWithSynonymsIsAdded_Then_ControllersAddNewTermWithSynonyms_Returns_200()
        {
            // Given
            var termsAndSynonymsMock = new Mock<ITermsAndSynonymsRepository>();
            termsAndSynonymsMock
                .Setup(mock => mock.AddNewTermWithSynonyms(_termWithSynonymsInputStub))
                .Returns(true);
            var synonymsController = new SynonymsController(termsAndSynonymsMock.Object);

            // When
            var result = synonymsController.AddNewTermWithSynonyms(_termWithSynonymsInputStub);

            // Then
            var statusCodeResult = result as StatusCodeResult;
            Assert.Equal(200, statusCodeResult?.StatusCode);
        }

        [Fact]
        public void When_InvalidTermWithSynonymsIsAdded_Then_ControllersAddNewTermWithSynonyms_Returns_500()
        {
            // Given
            var termsAndSynonymsMock = new Mock<ITermsAndSynonymsRepository>();
            termsAndSynonymsMock
                .Setup(mock => mock.AddNewTermWithSynonyms(null))
                .Returns(false);
            var synonymsController = new SynonymsController(termsAndSynonymsMock.Object);

            // When
            var result = synonymsController.AddNewTermWithSynonyms(null);

            // Then
            var statusCodeResult = result as ObjectResult;
            Assert.Equal(500, statusCodeResult?.StatusCode);
        }

        [Fact]
        public void When_GetTermsWithSynonymsIsCalled_Then_RepositoryCallsGetTermsWithSynonyms()
        {
            // Given
            var synonymsController = new SynonymsController(_termsAndSynonymsRepositoryMock.Object);

            // When
            synonymsController.GetTermsWithSynonyms();

            // Then
            _termsAndSynonymsRepositoryMock.Verify(mock => mock.GetTermsWithSynonyms(), Times.Once);
        }

        [Fact]
        public void When_TermsAndSynonymsRepositoryReturnsListOfWords_Then_ControllersGetTermsWithSynonyms_Returns_200()
        {
            // Given
            var termsAndSynonymsMock = new Mock<ITermsAndSynonymsRepository>();
            termsAndSynonymsMock
                .Setup(mock => mock.GetTermsWithSynonyms())
                .Returns(_wordsStub);
            var synonymsController = new SynonymsController(termsAndSynonymsMock.Object);

            // When
            var result = synonymsController.GetTermsWithSynonyms();

            // Then
            var statusCodeResult = result.Result as ObjectResult;
            Assert.Equal(200, statusCodeResult?.StatusCode);
        }

        [Fact]
        public void When_TermsAndSynonymsRepositoryReturnsEmptyList_Then_ControllersGetTermsWithSynonyms_Returns_204()
        {
            // Given
            var termsAndSynonymsMock = new Mock<ITermsAndSynonymsRepository>();
            termsAndSynonymsMock
                .Setup(mock => mock.GetTermsWithSynonyms())
                .Returns(new List<Words>());
            var synonymsController = new SynonymsController(termsAndSynonymsMock.Object);

            // When
            var result = synonymsController.GetTermsWithSynonyms();

            // Then
            var statusCodeResult = result.Result as StatusCodeResult;
            Assert.Equal(204, statusCodeResult?.StatusCode);
        }
    }
}
