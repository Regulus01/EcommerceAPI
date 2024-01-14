namespace Domain.Authentication.Entities.Roles;

public static class RoleRegister
{
    public static Role Admin = new Role(Guid.Parse("50F5BCBE-CD0D-4DCE-9808-49064A35E20A"), "Admin");
    public static Role Vendedor = new Role(Guid.Parse("BD49AF6B-B585-4384-9C5D-56B347BB02FB"), "Vendedor");
    public static Role Comprador = new Role(Guid.Parse("A83097FE-87B9-4A38-8067-1F13AB201137"), "Comprador");
}