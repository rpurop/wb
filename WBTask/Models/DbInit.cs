using Microsoft.AspNetCore.Components.Forms;

namespace WBTask.Models;
public class DatabaseInitilaizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<WBTaskContext>();

                if (!context.Users.Any())
                {
                    var UsersToAdd = new List<User>
                    {
                        new User { Id = 1, Name = "Grigor"},
                        new User { Id = 2, Name = "Ivan"},
                        new User { Id = 3, Name = "Peter"},
                        new User { Id = 4, Name = "George"},
                    };

                    var UserRolesToAdd = new List<UserRole>
                    {
                        new UserRole {Id = 1, user = UsersToAdd[0], Role = "Editor", CountryCode = "BG"},
                        new UserRole {Id = 2, user = UsersToAdd[1], Role = "Reviewer", CountryCode = "BG"},
                        new UserRole {Id = 3, user = UsersToAdd[2], Role = "Editor", CountryCode = "CEE"},
                        new UserRole {Id = 4, user = UsersToAdd[3], Role = "Reviewer", CountryCode = "CEE"},
                        new UserRole {Id = 5, user = UsersToAdd[0], Role = "Editor", CountryCode = "CEE"},
                    };

                    var TasksToAdd = new List<Task>
                    {
                        new Task {Id =1, Name="Obtain country decision"},
                        new Task {Id =2, Name="Inform on country level"},
                        new Task {Id =3, Name="Obtain regional decision"},
                        new Task {Id =4, Name="Inform on regional level"},
                    };

                    // var PackagesToAdd = new List<Package>
                    // {
                    //     new Package {Id = 1, LastVersionSeq = 1},
                    //     new Package {Id = 2, LastVersionSeq = 1},
                    //     new Package {Id = 3, LastVersionSeq = 1},
                    //     new Package {Id = 4, LastVersionSeq = 1},
                    //     new Package {Id = 5, LastVersionSeq = 1},
                    // };

                    // var PackageVersionsToAdd =new List<PackageVersion>
                    // {
                    //     new PackageVersion {Id=1, PackageId=1,VersionSeq=1,Package="First Package"},
                    //     new PackageVersion {Id=2, PackageId=2,VersionSeq=1,Package="Second Package"},
                    //     new PackageVersion {Id=3, PackageId=3,VersionSeq=1,Package="Third Package"},
                    //     new PackageVersion {Id=4, PackageId=4,VersionSeq=1,Package="Fourth Package"},
                    //     new PackageVersion {Id=5, PackageId=5,VersionSeq=1,Package="Fifth Package"},
                    // };

                    context.Users.AddRange(UsersToAdd);
                    context.UserRoles.AddRange(UserRolesToAdd);
                    context.Tasks.AddRange(TasksToAdd);
                    // context.Packages.AddRange(PackagesToAdd);
                    // context.PackageVersions.AddRange(PackageVersionsToAdd);
                    context.SaveChanges();
                }
            }
        }
    }