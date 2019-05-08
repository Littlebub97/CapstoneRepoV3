namespace PurchaseReqV3.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PurchaseReqV3.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PurchaseReqV3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //Alex all roles are added as per based on page 17 of the Purchase Requisition System Document.
        //Beware these are not spell checked throughly
        //All names and addresses and phone numebrs are random and are not as per WVUP staff
        //The roles are grouped via hierarchy as per page 17
        //CFO may be outdated, I left all old roles in the system for now

        //For simplicity sake, <<<ALL PASSWORDS ARE "Password1!" NOW>>> (Except for Admin)

        protected override void Seed(PurchaseReqV3.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var PasswordHash = new PasswordHasher();
            context.Roles.AddOrUpdate(r => r.Id,

                new IdentityRole { Name = "President" },
                new IdentityRole { Name = "Executive Assistant to the President" },

                new IdentityRole { Name = "Special Assistant to the President, Policy, and Social Justice" },

                new IdentityRole { Name = "Vice President, Finance and Administration" },
                new IdentityRole { Name = "Director, Business Services" },
                new IdentityRole { Name = "Director, Human Resources" },
                new IdentityRole { Name = "Director, Facility, and Grounds" },
                new IdentityRole { Name = "Campus Police Officer, Lead" },
                new IdentityRole { Name = "Chief Information Officer" },
                new IdentityRole { Name = "Director, Institutional Research" },
                new IdentityRole { Name = "Coordinator, Events and Rentals" },

                new IdentityRole { Name = "Vice President, Institutional Advancement" },
                new IdentityRole { Name = "Director, WVUP Foundation" },
                new IdentityRole { Name = "Director, Marketing and Communications" },
                new IdentityRole { Name = "BTG Program Coordinator, Sector Partnerships" },

                new IdentityRole { Name = "Vice President, Acedemic Affairs" },
                new IdentityRole { Name = "Dean, Academic Affairs" },
                new IdentityRole { Name = "Dean, Jackson County Center" },
                new IdentityRole { Name = "Chair Business, Accounting, and Public Services" },
                new IdentityRole { Name = "Chair Education" },
                new IdentityRole { Name = "Chair Health Sciences" },
                new IdentityRole { Name = "Executive Director, Workforce and Economic Development" },
                new IdentityRole { Name = "Chair Humanities, Fine Arts and Social Sciences" },
                new IdentityRole { Name = "Professional Technologist to Online Learning" },
                new IdentityRole { Name = "Chair Science Technology Engineering and Math" },
                new IdentityRole { Name = "Director, Library" },

                new IdentityRole { Name = "Vice President, Student Services" },
                new IdentityRole { Name = "Executive Director, Enrollment" },
                new IdentityRole { Name = "Director, Student Support and Engagement " },
                new IdentityRole { Name = "Director, Financial Aid" },
                new IdentityRole { Name = "Registrar" },

                new IdentityRole { Name = "Office Administrator" },

                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Employee" },
                new IdentityRole { Name = "CFO" },
                new IdentityRole { Name = "Student Dean"},
                new IdentityRole { Name = "Academic Division Chair" },
                new IdentityRole { Name = "Purchasing staff" },
                new IdentityRole { Name = "Academic Department Head" },
                new IdentityRole { Name = "Maintenance Division Head" },
                new IdentityRole { Name = "State Auditor" },
                new IdentityRole { Name = "Grounds Keeping Department Head" }
                );

            //ADDING ADMIN
            if (!context.Users.Any(u => u.UserName == "Admin@web.com"))
            {
                var admin = new User
                {
                    UserName = "Admin@web.com",
                    Email = "Admin@web.com",
                    F_name = "Bill",
                    L_name = "Admin",
                    Address = "address",
                  //PhoneNumber= "304-486-6654",
                    PasswordHash = PasswordHash.HashPassword("Admin!123"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };

                UserManager.Create(admin);
                UserManager.AddToRole(admin.Id, "Admin");
            }

            //Adding CFO
            if (!context.Users.Any(u => u.UserName == "Alice@web.com"))
            {
                var CFO = new User
                {
                    UserName = "Alice@web.com",
                    Email = "Alice@web.com",
                    F_name = "Alice",
                    L_name = "CFO",
                    Address = "address",
                    PasswordHash = PasswordHash.HashPassword("Alice!123"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };

                UserManager.Create(CFO);
                UserManager.AddToRole(CFO.Id, "CFO");
            }

             if (!context.Users.Any(u => u.UserName == "Cheri@web.com"))
            {
                var StateAuditor = new User
                {
                    UserName = "Cheri@web.com",
                    Email = "Cheri@web.com",
                    F_name = "Cheri",
                    L_name = "StateAuditor",
                    Address = "address",
                    PasswordHash = PasswordHash.HashPassword("Cheri!123"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };

                UserManager.Create(StateAuditor);
                UserManager.AddToRole(StateAuditor.Id, "State Auditor");
            }

            if (!context.Users.Any(u => u.UserName == "Steve@web.com"))
            {
                var Employee  = new User
                {
                    UserName = "Steve@web.com",
                    Email = "Steve@web.com",
                    F_name = "Steve",
                    L_name = "Employee",
                    Address = "address",
                    PasswordHash = PasswordHash.HashPassword("Steve!123"),
                    Active = true,
                    DateHired = new DateTime(2019,04,20)
                };

                UserManager.Create(Employee);
                UserManager.AddToRole(Employee.Id, "Employee");
            }

            //Adding President
            if (!context.Users.Any(u => u.UserName == "Scott@web.com"))
            {
                var President = new User
                {
                    UserName = "Scott@web.com",
                    Email = "Scott@web.com",
                    F_name = "Scott",
                    L_name = "Kelly",
                    Address = "971 East 8th Lans Acworth, GA 30101",
                    PhoneNumber = "(373) 864-4984",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(President);
                UserManager.AddToRole(President.Id, "President");
            }

            //Adding Executive Assistant to the President
            if (!context.Users.Any(u => u.UserName == "Sharon@web.com"))
            {
                var Executive_Assistant_to_the_President = new User
                {
                    UserName = "Sharon@web.com",
                    Email = "Sharon@web.com",
                    F_name = "Sharon",
                    L_name = "White",
                    Address = "14 South Ave. Schaumburg, IL 60193",
                    PhoneNumber = "(782) 765-6020",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Executive_Assistant_to_the_President);
                UserManager.AddToRole(Executive_Assistant_to_the_President.Id, "Executive Assistant to the President");
            }

            //Adding Special Assistant to the President, Policy and Social Justice
            if (!context.Users.Any(u => u.UserName == "Timothy@web.com"))
            {
                var Special_Assistant_to_the_President_Policy_and_Social_Justice = new User
                {
                    UserName = "Timothy@web.com",
                    Email = "Timothy@web.com",
                    F_name = "Timothy",
                    L_name = "Clark",
                    Address = "43 Old Beech St. Evansville, IN 47711",
                    PhoneNumber = "(231) 964-4779",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Special_Assistant_to_the_President_Policy_and_Social_Justice);
                UserManager.AddToRole(Special_Assistant_to_the_President_Policy_and_Social_Justice.Id, "Special Assistant to the President, Policy, and Social Justice");
            }

            //Adding Vice President Finance and Administration
            if (!context.Users.Any(u => u.UserName == "Beverly@web.com"))
            {
                var Vice_President_Finance_and_Administration = new User
                {
                    UserName = "Beverly@web.com",
                    Email = "Beverly@web.com",
                    F_name = "Beverly",
                    L_name = "Cox",
                    Address = "27 Alton Street Attleboro, MA 02703",
                    PhoneNumber = "(236) 585-4261",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Vice_President_Finance_and_Administration);
                UserManager.AddToRole(Vice_President_Finance_and_Administration.Id, "Vice President, Finance and Administration");
            }

            //Adding Director, Business Services
            if (!context.Users.Any(u => u.UserName == "Shawn@web.com"))
            {
                var Director_Business_Services = new User
                {
                    UserName = "Shawn@web.com",
                    Email = "Shawn@web.com",
                    F_name = "Shawn",
                    L_name = "Hall",
                    Address = "414 Garden Road Naugatuck, CT 06770",
                    PhoneNumber = "(671) 403-3902",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Director_Business_Services);
                UserManager.AddToRole(Director_Business_Services.Id, "Director, Business Services");
            }

            //Adding Director, Human Resources
            if (!context.Users.Any(u => u.UserName == "Carl@web.com"))
            {
                var Director_Human_Resources = new User
                {
                    UserName = "Carl@web.com",
                    Email = "Carl@web.com",
                    F_name = "Carl",
                    L_name = "Foster",
                    Address = "9512 SE. County Ave. Collegeville, PA 19426",
                    PhoneNumber = "(798) 592-4630",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Director_Human_Resources);
                UserManager.AddToRole(Director_Human_Resources.Id, "Director, Human Resources");
            }

            //Adding Director, Facilities and Grounds
            if (!context.Users.Any(u => u.UserName == "Jesse@web.com"))
            {
                var Director_Facilities_and_Grounds = new User
                {
                    UserName = "Jesse@web.com",
                    Email = "Jesse@web.com",
                    F_name = "Jesse",
                    L_name = "Sanchez",
                    Address = "559 Indian Spring Drive Hope Mills, NC 28348",
                    PhoneNumber = "(635) 971-2556",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Director_Facilities_and_Grounds);
                UserManager.AddToRole(Director_Facilities_and_Grounds.Id, "Director, Facility, and Grounds");
            }

            //Adding Campus Police Officer, Lead
            if (!context.Users.Any(u => u.UserName == "Roy@web.com"))
            {
                var Campus_Police_Officer_Lead = new User
                {
                    UserName = "Roy@web.com",
                    Email = "Roy@web.com",
                    F_name = "Roy",
                    L_name = "Stewart",
                    Address = "121 Lantern St. Sidney,OH 45365",
                    PhoneNumber = "(207) 371-3380",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Campus_Police_Officer_Lead);
                UserManager.AddToRole(Campus_Police_Officer_Lead.Id, "Campus Police Officer, Lead");
            }

            //Adding Chief Information officer
            if (!context.Users.Any(u => u.UserName == "Bonnie@web.com"))
            {
                var Chief_Information_Officer = new User
                {
                    UserName = "Bonnie@web.com",
                    Email = "Bonnie@web.com",
                    F_name = "Bonnie",
                    L_name = "Henderson",
                    Address = "642 State Street Phillipsburg, NJ 08865",
                    PhoneNumber = "(716) 903-9596",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Chief_Information_Officer);
                UserManager.AddToRole(Chief_Information_Officer.Id, "Chief Information Officer");
            }

            //Adding Director, Institutional Research
            if (!context.Users.Any(u => u.UserName == "Nicholas@web.com"))
            {
                var Director_Institutional_Research = new User
                {
                    UserName = "Nicholas@web.com",
                    Email = "Nicholas@web.com",
                    F_name = "Nicholas",
                    L_name = "Hernandez",
                    Address = "8033 Honey Creek St. Terre Haute, IN 47802",
                    PhoneNumber = "(412) 429-9694",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Director_Institutional_Research);
                UserManager.AddToRole(Director_Institutional_Research.Id, "Director, Institutional Research");
            }

            //Adding Coordinator, Events and Rentals
            if (!context.Users.Any(u => u.UserName == "Willie@web.com"))
            {
                var Coordinator_Events_and_Rentals = new User
                {
                    UserName = "Willie@web.com",
                    Email = "Willie@web.com",
                    F_name = "Willie",
                    L_name = "Adams",
                    Address = "903 Pierce Rd. Parlin, NJ 08859",
                    PhoneNumber = "(405) 363-9325",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Coordinator_Events_and_Rentals);
                UserManager.AddToRole(Coordinator_Events_and_Rentals.Id, "Coordinator, Events and Rentals");
            }

            //Adding Vice President, Institutional Advancement
            if (!context.Users.Any(u => u.UserName == "Lisa@web.com"))
            {
                var Vice_President_Institutional_Advancement = new User
                {
                    UserName = "Lisa@web.com",
                    Email = "Lisa@web.com",
                    F_name = "Lisa",
                    L_name = "Robinson",
                    Address = "953 Green Lake Ave. Bloomington, IN 47401",
                    PhoneNumber = "(868) 716-2052",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Vice_President_Institutional_Advancement);
                UserManager.AddToRole(Vice_President_Institutional_Advancement.Id, "Vice President, Institutional Advancement");
            }

            //Adding Director, WVUP Foundation
            if (!context.Users.Any(u => u.UserName == "Paula@web.com"))
            {
                var Director_WVUP_Foundation = new User
                {
                    UserName = "Paula@web.com",
                    Email = "Paula@web.com",
                    F_name = "Paula",
                    L_name = "Kelly",
                    Address = "485 Elmwood Street Downingtown, PA 19335",
                    PhoneNumber = "(542) 698-9056",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Director_WVUP_Foundation);
                UserManager.AddToRole(Director_WVUP_Foundation.Id, "Director, WVUP Foundation");
            }

            //Adding Director, Marketing and Communications
            if (!context.Users.Any(u => u.UserName == "George@web.com"))
            {
                var Director_Marketing_and_Communications = new User
                {
                    UserName = "George@web.com",
                    Email = "George@web.com",
                    F_name = "George",
                    L_name = "Russell",
                    Address = "707 Old York Dr. Point Pleasant Beach, NJ 08742",
                    PhoneNumber = "(965) 898-8460",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Director_Marketing_and_Communications);
                UserManager.AddToRole(Director_Marketing_and_Communications.Id, "Director, Marketing and Communications");
            }

            //Adding BTG Program Coordinator, Sector Partnerships
            if (!context.Users.Any(u => u.UserName == "Brian@web.com"))
            {
                var BTG_Program_Coordinator_Sector_Partnerships = new User
                {
                    UserName = "Brian@web.com",
                    Email = "Brian@web.com",
                    F_name = "Brian",
                    L_name = "Wood",
                    Address = "9930 Laurel Ave. Lawrence, MA 01841",
                    PhoneNumber = "(687) 816-4191",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(BTG_Program_Coordinator_Sector_Partnerships);
                UserManager.AddToRole(BTG_Program_Coordinator_Sector_Partnerships.Id, "BTG Program Coordinator, Sector Partnerships");
            }

            //Adding Vice President, Acedemic Affairs
            if (!context.Users.Any(u => u.UserName == "Christine@web.com"))
            {
                var Vice_President_Acedemic_Affairs = new User
                {
                    UserName = "Christine@web.com",
                    Email = "Christine@web.com",
                    F_name = "Christine",
                    L_name = "Phillips",
                    Address = "632 Golf Drive Capitol Heights, MD 20743",
                    PhoneNumber = "(357) 640-7957",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Vice_President_Acedemic_Affairs);
                UserManager.AddToRole(Vice_President_Acedemic_Affairs.Id, "Vice President, Acedemic Affairs");
            }

            //Adding Dean, Acedemic Affairs
            if (!context.Users.Any(u => u.UserName == "Jane@web.com"))
            {
                var Dean_Acedemic_Affairs = new User
                {
                    UserName = "Jane@web.com",
                    Email = "Jane@web.com",
                    F_name = "Jane",
                    L_name = "Ward",
                    Address = "193 Littleton Lane Framingham, MA 01701",
                    PhoneNumber = "(569) 649-5100",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Dean_Acedemic_Affairs);
                UserManager.AddToRole(Dean_Acedemic_Affairs.Id, "Dean, Academic Affairs");
            }

            //Adding Dean, Jackson County Center
            if (!context.Users.Any(u => u.UserName == "Laura@web.com"))
            {
                var Dean_Jackson_County_Center = new User
                {
                    UserName = "Laura@web.com",
                    Email = "Laura@web.com",
                    F_name = "Laura",
                    L_name = "Morgan",
                    Address = "622 E. Lake Rd. Manahawkin, NJ 08050",
                    PhoneNumber = "(854) 480-6087",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Dean_Jackson_County_Center);
                UserManager.AddToRole(Dean_Jackson_County_Center.Id, "Dean, Jackson County Center");
            }

            //Adding Chair Business, Accounting, and Public Services
            if (!context.Users.Any(u => u.UserName == "Howard@web.com"))
            {
                var Chair_Business_Accounting_and_Public_Services = new User
                {
                    UserName = "Howard@web.com",
                    Email = "Howard@web.com",
                    F_name = "Howard",
                    L_name = "Ross",
                    Address = "284 Thatcher Rd. Rahway, NJ 07065",
                    PhoneNumber = "(606) 766-2712",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Chair_Business_Accounting_and_Public_Services);
                UserManager.AddToRole(Chair_Business_Accounting_and_Public_Services.Id, "Chair Business, Accounting, and Public Services");
            }

            //Adding Chair Education
            if (!context.Users.Any(u => u.UserName == "Geraldine@web.com"))
            {
                var Chair_Education = new User
                {
                    UserName = "Geraldine@web.com",
                    Email = "Geraldine@web.com",
                    F_name = "Geraldine",
                    L_name = "Duncan",
                    Address = "375 South Virginia St. Navarre, FL 32566",
                    PhoneNumber = "(267) 625-6015",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Chair_Education);
                UserManager.AddToRole(Chair_Education.Id, "Chair Education");
            }

            //Adding Chair Health Sciences
            if (!context.Users.Any(u => u.UserName == "Lynn@web.com"))
            {
                var Chair_Health_Sciences = new User
                {
                    UserName = "Lynn@web.com",
                    Email = "Lynn@web.com",
                    F_name = "Lynn",
                    L_name = "Parker",
                    Address = "19 Primrose Lane Lake Villa, IL 60046",
                    PhoneNumber = "(244) 401-1836",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Chair_Health_Sciences);
                UserManager.AddToRole(Chair_Health_Sciences.Id, "Chair Education");
            }

            //Adding Executive Director, Workforce and Economic Development
            if (!context.Users.Any(u => u.UserName == "Tiffany@web.com"))
            {
                var Executive_Director_Workforce_and_Economic_Developments = new User
                {
                    UserName = "Tiffany@web.com",
                    Email = "Tiffany@web.com",
                    F_name = "Tiffany",
                    L_name = "Porter",
                    Address = "188 Sulphur Springs Street Buckeye, AZ 85326",
                    PhoneNumber = "(748) 434-4621",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Executive_Director_Workforce_and_Economic_Developments);
                UserManager.AddToRole(Executive_Director_Workforce_and_Economic_Developments.Id, "Executive Director, Workforce and Economic Development");
            }

            //Adding Chair Humanities, Fine Arts and Social Sciences
            if (!context.Users.Any(u => u.UserName == "Vickie@web.com"))
            {
                var Chair_Humanities_Fine_Arts_and_Social_Sciences = new User
                {
                    UserName = "Vickie@web.com",
                    Email = "Vickie@web.com",
                    F_name = "Vickie",
                    L_name = "Sparks",
                    Address = "7730 Pheasant Avenue Millville, NJ 08332",
                    PhoneNumber = "(635) 758-3907",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Chair_Humanities_Fine_Arts_and_Social_Sciences);
                UserManager.AddToRole(Chair_Humanities_Fine_Arts_and_Social_Sciences.Id, "Chair Humanities, Fine Arts and Social Sciences");
            }

            //Adding Professional Technologist to Online Learning
            if (!context.Users.Any(u => u.UserName == "Bernice@web.com"))
            {
                var Professional_Technologist_to_Online_Learning = new User
                {
                    UserName = "Bernice@web.com",
                    Email = "Bernice@web.com",
                    F_name = "Bernice",
                    L_name = "Bradley",
                    Address = "8123 Eagle Street Pensacola, FL 32503",
                    PhoneNumber = "(354) 789-4121",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Professional_Technologist_to_Online_Learning);
                UserManager.AddToRole(Professional_Technologist_to_Online_Learning.Id, "Professional Technologist to Online Learning");
            }

            //Adding Chair Science, Technology, Engineering and Math
            if (!context.Users.Any(u => u.UserName == "Jared@web.com"))
            {
                var Chair_Science_Technology_Engineering_and_Math = new User
                {
                    UserName = "Jared@web.com",
                    Email = "Jared@web.com",
                    F_name = "Jared",
                    L_name = "Gump",
                    Address = "41 W. Mayfair Rd. Muncie, IN 47302",
                    PhoneNumber = "(662) 540-9268",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Chair_Science_Technology_Engineering_and_Math);
                UserManager.AddToRole(Chair_Science_Technology_Engineering_and_Math.Id, "Chair Science Technology Engineering and Math");
            }

            //Adding Director, Library
            if (!context.Users.Any(u => u.UserName == "Reginald@web.com"))
            {
                var Director_Library = new User
                {
                    UserName = "Reginald@web.com",
                    Email = "Reginald@web.com",
                    F_name = "Reginald",
                    L_name = "Sherman",
                    Address = "9379 East Ridgeview Street Braintree, MA 02184",
                    PhoneNumber = "(388) 391-5541",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Director_Library);
                UserManager.AddToRole(Director_Library.Id, "Director, Library");
            }

            //Adding Vice President, Student Services
            if (!context.Users.Any(u => u.UserName == "Sally@web.com"))
            {
                var Vice_President_Student_Services = new User
                {
                    UserName = "Sally@web.com",
                    Email = "Sally@web.com",
                    F_name = "Sally",
                    L_name = "Leonard",
                    Address = "4 North Street Bellmore, NY 11710",
                    PhoneNumber = "(771) 353-3619",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Vice_President_Student_Services);
                UserManager.AddToRole(Vice_President_Student_Services.Id, "Vice President, Student Services");
            }

            //Adding Executive Director, Enrollment
            if (!context.Users.Any(u => u.UserName == "Kristen@web.com"))
            {
                var Executive_Director_Enrollment = new User
                {
                    UserName = "Kristen@web.com",
                    Email = "Kristen@web.com",
                    F_name = "Kristen",
                    L_name = "Jacobs",
                    Address = "8651 Indian Spring Avenue Taunton, MA 02780",
                    PhoneNumber = "(963) 277-1416",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Executive_Director_Enrollment);
                UserManager.AddToRole(Executive_Director_Enrollment.Id, "Executive Director, Enrollment");
            }

            //Adding Director, Student Support and Engagement
            if (!context.Users.Any(u => u.UserName == "Jan@web.com"))
            {
                var Director_Student_Support_and_Engagement = new User
                {
                    UserName = "Jan@web.com",
                    Email = "Jan@web.com",
                    F_name = "Jan",
                    L_name = "Gilbert",
                    Address = "59 North Bay Meadows Avenue Hixson, TN 37343",
                    PhoneNumber = "(523) 437-6744",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Director_Student_Support_and_Engagement);
                UserManager.AddToRole(Director_Student_Support_and_Engagement.Id, "Director, Student Support and Engagement");
            }

            //Adding Director, Financial Aid
            if (!context.Users.Any(u => u.UserName == "Nathaniel@web.com"))
            {
                var Director_Financial_Aid = new User
                {
                    UserName = "Nathaniel@web.com",
                    Email = "Nathaniel@web.com",
                    F_name = "Nathaniel",
                    L_name = "Schmidt",
                    Address = "7515 Belmont St. Burlington MA 01803",
                    PhoneNumber = "(277) 769-2075",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Director_Financial_Aid);
                UserManager.AddToRole(Director_Financial_Aid.Id, "Director, Financial Aid");
            }

            //Adding Registrar
            if (!context.Users.Any(u => u.UserName == "Jessie@web.com"))
            {
                var Registrar = new User
                {
                    UserName = "Jessie@web.com",
                    Email = "Jessie@web.com",
                    F_name = "Jessie",
                    L_name = "Keller",
                    Address = "89 Aspen St. Hartselle, AL 35640",
                    PhoneNumber = "(345) 808-4930",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Registrar);
                UserManager.AddToRole(Registrar.Id, "Registrar");
            }

            //Adding Office Administrator
            if (!context.Users.Any(u => u.UserName == "Daniel@web.com"))
            {
                var Office_Administrator = new User
                {
                    UserName = "Daniel@web.com",
                    Email = "Daniel@web.com",
                    F_name = "Daniel",
                    L_name = "Davidson",
                    Address = "9682 South Tarkiln Hill Dr. Mchenry, IL 60050",
                    PhoneNumber = "(210) 678-5176",
                    PasswordHash = PasswordHash.HashPassword("Password1!"),
                    Active = true,
                    DateHired = new DateTime(2019, 04, 20)
                };
                UserManager.Create(Office_Administrator);
                UserManager.AddToRole(Office_Administrator.Id, "Office Administrator");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}