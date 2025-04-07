using Moq;
using TaxesMunicipality.Core.DTOs;
using TaxesMunicipality.Core.Enums;
using TaxesMunicipality.Core.Interfaces;
using TaxesMunicipality.Core.Models;
using TaxesMunicipality.Core.Services;

namespace TaxesMunicipality.Tests
{
    public class MunicipalityTaxServiceTests
    {
        private readonly Mock<IMunicipalityTaxRepository> _repositoryMock;
        private readonly MunicipalityTaxService _taxServiceMock;

        public MunicipalityTaxServiceTests()
        {
            _repositoryMock = new Mock<IMunicipalityTaxRepository>();
            _taxServiceMock = new MunicipalityTaxService(_repositoryMock.Object);
        }

        [Fact]
        public void GetTaxRate_CopenhagenOnJanuary1_2024_Returns_DalyTaxRateOf_0_1()
        {
            var municipality = "Copenhagen";
            var date = new DateTime(2024, 01, 01);

            var taxes = new List<MunicipalityTaxModel>
            {
                new MunicipalityTaxModel
                {
                    Id = 1,
                    Municipality = "Copenhagen",
                    TaxRate = 0.2,
                    Type = TaxType.Yearly,
                    FromDate = new DateTime(2024, 1, 1),
                    ToDate = new DateTime(2024, 12, 31)
                },
                new MunicipalityTaxModel
                {
                    Id = 3,
                    Municipality = "Copenhagen",
                    TaxRate = 0.1,
                    Type = TaxType.Daily,
                    FromDate = new DateTime(2024, 1, 1),
                    ToDate = new DateTime(2024, 1, 1)
                }
            };

            _repositoryMock.Setup(x => x.GetMunicipalityTaxes(municipality, date)).Returns(taxes);

            var result = _taxServiceMock.GetTaxRate(municipality, date);

            Assert.Equal(0.1, result?.TaxRate);
        }

        [Fact]
        public void GetTaxRate_CopenhagenOnMarch16_2024_Returns_YearlyTaxRateOf_0_2()
        {
            var municipality = "Copenhagen";
            var date = new DateTime(2024, 03, 16);

            var taxes = new List<MunicipalityTaxModel>
            {
                new MunicipalityTaxModel
                {
                    Id = 1,
                    Municipality = "Copenhagen",
                    TaxRate = 0.2,
                    Type = TaxType.Yearly,
                    FromDate = new DateTime(2024, 1, 1),
                    ToDate = new DateTime(2024, 12, 31)
                }
            };

            _repositoryMock.Setup(x => x.GetMunicipalityTaxes(municipality, date)).Returns(taxes);

            var result = _taxServiceMock.GetTaxRate(municipality, date);

            Assert.Equal(0.2, result?.TaxRate);
        }

        [Fact]
        public void GetTaxRate_CopenhagenOnMay2_2024_Returns_MonthlyTaxRateOf_0_4()
        {
            var municipality = "Copenhagen";
            var date = new DateTime(2024, 5, 2);

            var taxes = new List<MunicipalityTaxModel>
            {
                new MunicipalityTaxModel
                {
                    Id = 2,
                    Municipality = "Copenhagen",
                    TaxRate = 0.4,
                    Type = TaxType.Monthly,
                    FromDate = new DateTime(2024, 5, 1),
                    ToDate = new DateTime(2024, 5, 31)
                }
            };

            _repositoryMock.Setup(x => x.GetMunicipalityTaxes(municipality, date)).Returns(taxes);

            var result = _taxServiceMock.GetTaxRate(municipality, date);

            Assert.Equal(0.4, result?.TaxRate);
        }

        [Fact]
        public void GetTaxRate_CopenhagenOnNovember2_2024_Returns_WeeklyTaxRateOf_0_6()
        {
            var municipality = "Copenhagen";
            var date = new DateTime(2024, 11, 2);

            var taxes = new List<MunicipalityTaxModel>
            {
                new MunicipalityTaxModel
                {
                    Id = 2,
                    Municipality = "Copenhagen",
                    TaxRate = 0.6,
                    Type = TaxType.Weekly,
                    FromDate = new DateTime(2024, 5, 1),
                    ToDate = new DateTime(2024, 5, 31)
                }
            };

            _repositoryMock.Setup(x => x.GetMunicipalityTaxes(municipality, date)).Returns(taxes);

            var result = _taxServiceMock.GetTaxRate(municipality, date);

            Assert.Equal(0.6, result?.TaxRate);
        }

        [Fact]
        public void GetTaxRate_NonExistanceMunicipality_Returns_Null()
        {
            var municipality = "random";
            var date = new DateTime(2024, 11, 2);

            _repositoryMock.Setup(x => x.GetMunicipalityTaxes(municipality, date)).Returns(value: null);

            var result = _taxServiceMock.GetTaxRate(municipality, date);

            Assert.Null(result);
        }

        [Fact]
        public async Task AddTaxRateAsync_ProperRequest_ReturnsTrue()
        {
            var request = new AddTaxRequestDTO
            {
                Municipality = "Vilnius",
                TaxRate = 0.7,
                TaxType = TaxType.Yearly,
                FromDate = new DateTime(2024, 1, 1),
                ToDate = new DateTime(2024, 12, 31)
            };

            _repositoryMock.Setup(x => x.AddMunicipalityTaxAsync(It.IsAny<MunicipalityTaxModel>())).ReturnsAsync(true);

            var result = await _taxServiceMock.AddTaxRateAsync(request);

            Assert.True(result);
        }

        [Fact]
        public async Task UpdateTaxRateAsync_ProperRequest_ReturnsUpdatedTaxRate()
        {
            var vilniusTax = new MunicipalityTaxModel
            {
                Id = 5,
                Municipality = "Vilnius",
                TaxRate = 0.6,
                Type = TaxType.Yearly,
                FromDate = new DateTime(2024, 1, 1),
                ToDate = new DateTime(2024, 12, 31)
            };

            var request = new UpdateTaxRequestDTO
            {
                Id = 5,
                Municipality = "Vilnius",
                TaxRate = 0.7,
                TaxType = TaxType.Yearly,
                FromDate = new DateTime(2024, 1, 1),
                ToDate = new DateTime(2024, 12, 31)
            };

            _repositoryMock.Setup(x => x.GetMunicipalityTaxByIdAsync(request.Id)).ReturnsAsync(vilniusTax);
            _repositoryMock.Setup(x => x.UpdateMunicipalityTaxAsync(It.IsAny<UpdateTaxRequestDTO>())).ReturnsAsync(true);

            var result = await _taxServiceMock.UpdateTaxRateAsync(request);

            Assert.True(result);
        }
    }
}
