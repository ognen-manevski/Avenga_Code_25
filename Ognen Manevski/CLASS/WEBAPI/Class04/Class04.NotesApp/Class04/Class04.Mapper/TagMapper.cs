using Class04.Domain.Models;

using Class04.Dtos;


namespace Class04.Mapper;

public static class TagMapper
{
    public static TagDto ToTagDto(this TagDto tag)
    {
        return new TagDto
        {
            Id = tag.Id,
            Name = tag.Name,
            Color = tag.Color
        };
    }

    public static List<TagDto> ToTagDtoList(this List<Tag> tags)
    {
        return tags.Select(t => t.ToTagDto()).ToList();
    }
}
