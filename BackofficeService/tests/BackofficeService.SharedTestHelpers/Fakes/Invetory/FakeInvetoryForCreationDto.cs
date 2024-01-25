namespace BackofficeService.SharedTestHelpers.Fakes.Invetory;

using AutoBogus;
using BackofficeService.Domain.Invetories;
using BackofficeService.Domain.Invetories.Dtos;

public sealed class FakeInvetoryForCreationDto : AutoFaker<InvetoryForCreationDto>
{
    public FakeInvetoryForCreationDto()
    {
    }
}