namespace Employees.Contracts
{
    public record EmployeeResponse(
        int Id,
        string Name,
        string Family,
        string Email
        );
}
