using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.Review;

public sealed record Rating
{
    public static readonly Error Invalid = new("Rating.Invalid", "Rating is invalid");

    public int Value { get; init; }

    private Rating(int value) => Value = value;

    public static Result<Rating> Create(int value)
    {
        if (value < 1 || value > 5)
        {
            return Result.Failure<Rating>(Invalid);
        }

        return Result.Success(new Rating(value));
    }
}
