
using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.Review;

public static class ReviewErrors
{
    public static readonly Error NotElegible = new Error(
        "Review.NotElegible",
        "Este review y calificación para el auto no es elegible porque aun no se ha completado el alquiler del auto."
    );
    
}
