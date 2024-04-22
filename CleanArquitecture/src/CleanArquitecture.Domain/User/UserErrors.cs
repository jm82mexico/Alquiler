using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.User;

public static class UserErrors
{
    public static Error NotFound = new(
        "User.NotFound",
        "No existe un usuario con el id especificado"
    );

    public static Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "Credenciales inválidas"
    );
}
