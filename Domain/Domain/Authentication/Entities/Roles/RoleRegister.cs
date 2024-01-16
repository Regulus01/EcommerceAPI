namespace Domain.Authentication.Entities.Roles;

public static class RoleRegister
{
    public static Role Admin = new Role(Guid.Parse("24b8a637-0342-4e44-a7d2-659e78ee7303"), "MP_ADMIN");
    public static Role Vendedor = new Role(Guid.Parse("4cf226b0-d84d-4394-82fc-80eab1b7aa5e"), "MP_VENDEDOR");
    public static Role Comprador = new Role(Guid.Parse("6818f3b8-b19f-42cd-a236-61cb31305217"), "MP_COMPRADOR");
}