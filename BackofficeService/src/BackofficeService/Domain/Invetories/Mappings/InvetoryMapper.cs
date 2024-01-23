namespace BackofficeService.Domain.Invetories.Mappings;

using BackofficeService.Domain.Invetories.Dtos;
using BackofficeService.Domain.Invetories.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class InvetoryMapper
{
    public static partial InvetoryForCreation ToInvetoryForCreation(this InvetoryForCreationDto invetoryForCreationDto);
    public static partial InvetoryForUpdate ToInvetoryForUpdate(this InvetoryForUpdateDto invetoryForUpdateDto);
    public static partial InvetoryDto ToInvetoryDto(this Invetory invetory);
    public static partial IQueryable<InvetoryDto> ToInvetoryDtoQueryable(this IQueryable<Invetory> invetory);
}