namespace Homework08.Libraries.Enums;

using System.ComponentModel.DataAnnotations; // For the Display attribute

public enum Genres
{
    Rock,
    [Display(Name = "Hip Hop")] Hip_Hop, // Using Display attribute to show "Hip Hop" instead of "Hip_Hop"
    Techno,
    Classical
}
