namespace BackofficeService.SharedTestHelpers.Fakes.Invetory;

using AutoBogus;
using BackofficeService.Domain.Invetories;
using BackofficeService.Domain.Invetories.Models;

public sealed class FakeInvetoryForCreation : AutoFaker<InvetoryForCreation>
{
    public FakeInvetoryForCreation()
    {
    }
}