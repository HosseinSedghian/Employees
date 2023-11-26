namespace Employees.Contracts
{
    public record EmployeeRequest(
        string Name,
        string Family,
        string Email,
        string Password
        );
}
