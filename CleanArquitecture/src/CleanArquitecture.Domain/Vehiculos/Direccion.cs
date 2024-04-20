namespace CleanArquitecture.Domain.Vehiculos;
//se encarga de manejar la dirección de los vehículos
public record Direccion
(
    string Pais,
    string Departamento,
    string Provincia,
    string Ciudad,
    string Calle   
);
