var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ComfySelf_Patients_API>("comfyself-patients-api");

builder.Build().Run();
