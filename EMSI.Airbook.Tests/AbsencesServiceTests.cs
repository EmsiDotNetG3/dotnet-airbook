using AutoFixture;
using AutoFixture.Xunit2;
using EMSi.Airbook.Absences;
using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;
using Moq;
using Xunit;

namespace EMSI.Airbook.Tests;

public class AbsencesServiceTests : TestsBase
{
    //System under test
    private readonly AbsencesService _sut;
    
    //Dependencies
    private readonly Mock<IAbsencesRepository> _absencesRepositoryMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    
    public AbsencesServiceTests()
    {
        _sut = new AbsencesService(_absencesRepositoryMock.Object, _unitOfWorkMock.Object, Mapper);
    }
    
    [Theory, AutoData]
    public async Task DeclarerAbsenceAsync_ShouldWork(Absence absence)
    {
        //act
        await _sut.DeclarerAbsenceAsync(absence);

        //assert
        _absencesRepositoryMock.Verify(x => x.AddAsync(It.IsAny<AbsenceDao>()), Times.Once);
        _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
    }

    [Theory, AutoData]
    public async Task GetAbsencesByEtudiantIdAsync_ReturnAbsences(Guid etudiantId)
    {
        //arrange
        var absences = Fixture.CreateMany<AbsenceDao>(10).ToList();
        absences[0].EtudiantId = etudiantId;
        absences[1].EtudiantId = etudiantId;
        
        _absencesRepositoryMock.Setup(x => x.GetAllQueryable()).Returns(absences.AsQueryable());
        
        //act
        var actual = await _sut.GetAbsencesByEtudiantIdAsync(etudiantId);
        
        //assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
        Assert.Equal(2, actual.Count);
    }
}