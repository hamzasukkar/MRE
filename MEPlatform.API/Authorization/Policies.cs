namespace MEPlatform.API.Authorization;

public static class Policies
{
    public const string SuperAdministrator = "SuperAdministrator";
    public const string Supervisor = "Supervisor";
    public const string ProgramManager = "ProgramManager";
    public const string Viewer = "Viewer";
    
    public const string CanManageFrameworks = "CanManageFrameworks";
    public const string CanManageProjects = "CanManageProjects";
    public const string CanViewReports = "CanViewReports";
}