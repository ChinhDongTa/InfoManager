using InfoManager.Shared.Dtos.Auths;

namespace InfoManager.ModelClient.Auths;

public class CreateRoleModel
{
    [Required(ErrorMessage = "Role name is required.")]
    public string Name { get; set; } = string.Empty;

    public CreateRoleDto ToRequest()
    {
        return new CreateRoleDto(Name);
    }
}

public class UpdateRoleModel
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public UpdateRoleDto ToRequest()
    {
        return new UpdateRoleDto {  Id = Id, Name = Name };
    }
}