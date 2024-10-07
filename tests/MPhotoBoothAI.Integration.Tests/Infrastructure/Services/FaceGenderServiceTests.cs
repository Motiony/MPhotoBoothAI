using Microsoft.Extensions.DependencyInjection;
using MPhotoBoothAI.Application.Interfaces;
using MPhotoBoothAI.Application.Models;

namespace MPhotoBoothAI.Integration.Tests.Infrastructure.Services;

public class FaceGenderServiceTests(DependencyInjectionFixture dependencyInjectionFixture) : IClassFixture<DependencyInjectionFixture>
{
    [Theory]
    [InlineData("TestData/womanAlign224.dat", Gender.Female)]
    [InlineData("TestData/manAlign224.dat", Gender.Male)]
    public void Get_ShouldBeExpected(string path, Gender expected)
    {
        //arrange
        using var sourceFaceFrame = RawMatFile.MatFromBase64File(path);
        var faceGenderService = dependencyInjectionFixture.ServiceProvider.GetService<IFaceGenderService>();
        //act
        var gender = faceGenderService.Get(sourceFaceFrame);
        //assert
        Assert.Equal(expected, gender);
    }

    [Theory]
    [InlineData("TestData/womanAlign224.dat", Gender.Female)]
    [InlineData("TestData/manAlign224.dat", Gender.Male)]
    public void GetVgg_ShouldBeExpected(string path, Gender expected)
    {
        //arrange
        using var sourceFaceFrame = RawMatFile.MatFromBase64File(path);
        var faceGenderService = dependencyInjectionFixture.ServiceProvider.GetService<IFaceGenderService>();
        //act
        var gender = faceGenderService.GetVgg(sourceFaceFrame);
        //assert
        Assert.Equal(expected, gender);
    }
}
