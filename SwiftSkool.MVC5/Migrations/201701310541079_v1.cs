namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allergies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MedicalHistoryId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalHistories", t => t.MedicalHistoryId)
                .Index(t => t.MedicalHistoryId);
            
            CreateTable(
                "dbo.MedicalHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surgery = c.Boolean(nullable: false),
                        YearOfSurgery = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Disabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MedicalHistoryId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalHistories", t => t.MedicalHistoryId)
                .Index(t => t.MedicalHistoryId);
            
            CreateTable(
                "dbo.Illnesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MedicalHistoryId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalHistories", t => t.MedicalHistoryId)
                .Index(t => t.MedicalHistoryId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OtherName = c.String(),
                        Age = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(),
                        AdmissionDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        StudentPassport = c.String(),
                        AdmissionNumber = c.String(),
                        Country = c.String(),
                        Active = c.Boolean(nullable: false),
                        AttendanceId = c.Int(),
                        ClassId = c.Int(),
                        ClubId = c.Int(),
                        GuardianId = c.Int(nullable: false),
                        HostelId = c.Int(nullable: false),
                        MedicalHistoryId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        Address_NameOfArea = c.String(),
                        Address_StreetName = c.String(),
                        Address_HouseNumber = c.String(),
                        Address_City = c.String(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .ForeignKey("dbo.Attendances", t => t.AttendanceId)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Clubs", t => t.ClubId)
                .ForeignKey("dbo.Guardians", t => t.GuardianId)
                .ForeignKey("dbo.Hostels", t => t.HostelId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.AttendanceId)
                .Index(t => t.ClassId)
                .Index(t => t.ClubId)
                .Index(t => t.GuardianId)
                .Index(t => t.HostelId)
                .Index(t => t.StateId)
                .Index(t => t.School_Id);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        StatusDescription = c.String(),
                        TeacherId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.SchoolSessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.SessionId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(),
                        ClassName = c.String(),
                        Section = c.String(),
                        TeacherId = c.Int(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        FormTeacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FormTeacher_Id)
                .Index(t => t.FormTeacher_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Address_NameOfArea = c.String(),
                        Address_StreetName = c.String(),
                        Address_HouseNumber = c.String(),
                        Address_City = c.String(),
                        LessonPlanId = c.Int(nullable: false),
                        SchoolId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OtherNames = c.String(),
                        Designation = c.String(),
                        Passport = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        Qualifications = c.Int(nullable: false),
                        Gender = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId)
                .Index(t => t.SchoolId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.School_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LessonPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolSessionId = c.Int(nullable: false),
                        ClassLevel = c.String(),
                        Class = c.String(),
                        Week = c.Int(nullable: false),
                        Topic = c.String(),
                        Discussions = c.String(),
                        Evaluations = c.String(),
                        RecommendedTexts = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PlanDescription = c.String(),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolSessions", t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TeacherId)
                .Index(t => t.Id)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.SchoolSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionName = c.String(),
                        Term = c.Int(nullable: false),
                        TermStarts = c.DateTime(nullable: false),
                        TermEnds = c.DateTime(nullable: false),
                        SchoolId = c.Int(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Logo = c.String(),
                        OwnerName = c.String(),
                        SchoolMotto = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SubjectCode = c.String(),
                        ScoreGradeId = c.Int(),
                        LessonPlanId = c.Int(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScoreGrades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(),
                        MinimumScore = c.Double(nullable: false),
                        MaximumScore = c.Double(nullable: false),
                        RatingId = c.Int(nullable: false),
                        ScoreComment = c.String(),
                        SubjectId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ratings", t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RatingGrade = c.String(),
                        Description = c.String(),
                        BehaviourActivityId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BehaviourActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KeyToRatingId = c.Int(nullable: false),
                        RatingId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ratings", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.KeyToRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Punctuality = c.String(),
                        Attendance = c.String(),
                        Attentiveness = c.String(),
                        Assignments = c.String(),
                        ActivityParticipation = c.String(),
                        Creativity = c.String(),
                        Neatness = c.String(),
                        Honesty = c.String(),
                        HandWriting = c.String(),
                        SelfControl = c.String(),
                        SocialSkills = c.String(),
                        Sports = c.String(),
                        BehaviourActivityId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BehaviourActivities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocalGovernments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StateId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clubname = c.String(),
                        TeacherId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Patron_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Patron_Id)
                .Index(t => t.Patron_Id);
            
            CreateTable(
                "dbo.Guardians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Occupation = c.String(),
                        AddressId = c.Int(nullable: false),
                        Address_NameOfArea = c.String(),
                        Address_StreetName = c.String(),
                        Address_HouseNumber = c.String(),
                        Address_City = c.String(),
                        Relationship = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hostels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HouseColour = c.String(),
                        HousePrefect = c.String(),
                        TeacherId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentStatus = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Payment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.Payment_Id)
                .Index(t => t.Payment_Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolSessionId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        ScoreGradeId = c.Int(nullable: false),
                        TermTotal = c.Double(nullable: false),
                        ClassAverage = c.Double(nullable: false),
                        Position = c.String(),
                        Status = c.String(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolSessions", t => t.SchoolSessionId, cascadeDelete: true)
                .ForeignKey("dbo.ScoreGrades", t => t.ScoreGradeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.SchoolSessionId)
                .Index(t => t.StudentId)
                .Index(t => t.ScoreGradeId);
            
            CreateTable(
                "dbo.ContinuousAssessments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Double(nullable: false),
                        Name = c.String(),
                        SubjectId = c.Int(nullable: false),
                        ResultId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Results", t => t.ResultId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.ResultId);
            
            CreateTable(
                "dbo.EntranceExamCandidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        TermTotal = c.Double(nullable: false),
                        EntranceExamId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EntranceExams", t => t.EntranceExamId, cascadeDelete: true)
                .Index(t => t.EntranceExamId);
            
            CreateTable(
                "dbo.EntranceExams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassOfEntry = c.Int(nullable: false),
                        TermTotal = c.Double(nullable: false),
                        CutoffScore = c.Double(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        AcceptanceStatus = c.Int(nullable: false),
                        EntranceExamCandidateId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EntranceExamSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        SubjectCode = c.String(),
                        Description = c.String(),
                        EntranceExamCandidateId = c.Int(nullable: false),
                        EntranceExamId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EntranceExams", t => t.EntranceExamId, cascadeDelete: true)
                .ForeignKey("dbo.EntranceExamCandidates", t => t.EntranceExamCandidateId)
                .Index(t => t.EntranceExamCandidateId)
                .Index(t => t.EntranceExamId);
            
            CreateTable(
                "dbo.EntranceExamRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        Passport = c.String(),
                        ScannedDocuments = c.String(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedAt = c.DateTime(),
                        ModifiedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Student_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.SubjectApplicationUsers",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EntranceExamSubjects", "EntranceExamCandidateId", "dbo.EntranceExamCandidates");
            DropForeignKey("dbo.EntranceExamSubjects", "EntranceExamId", "dbo.EntranceExams");
            DropForeignKey("dbo.EntranceExamCandidates", "EntranceExamId", "dbo.EntranceExams");
            DropForeignKey("dbo.Allergies", "MedicalHistoryId", "dbo.MedicalHistories");
            DropForeignKey("dbo.MedicalHistories", "Id", "dbo.Students");
            DropForeignKey("dbo.Students", "StateId", "dbo.States");
            DropForeignKey("dbo.Results", "Id", "dbo.Subjects");
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Results", "ScoreGradeId", "dbo.ScoreGrades");
            DropForeignKey("dbo.Results", "SchoolSessionId", "dbo.SchoolSessions");
            DropForeignKey("dbo.ContinuousAssessments", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.ContinuousAssessments", "ResultId", "dbo.Results");
            DropForeignKey("dbo.Payments", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.PaymentTypes", "Payment_Id", "dbo.Payments");
            DropForeignKey("dbo.Students", "HostelId", "dbo.Hostels");
            DropForeignKey("dbo.Hostels", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "GuardianId", "dbo.Guardians");
            DropForeignKey("dbo.Students", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Clubs", "Patron_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Students", "AttendanceId", "dbo.Attendances");
            DropForeignKey("dbo.Attendances", "SessionId", "dbo.SchoolSessions");
            DropForeignKey("dbo.Attendances", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "FormTeacher_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "StateId", "dbo.States");
            DropForeignKey("dbo.LocalGovernments", "StateId", "dbo.States");
            DropForeignKey("dbo.AspNetUsers", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LessonPlans", "TeacherId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LessonPlans", "Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubjectApplicationUsers", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.SubjectStudents", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.ScoreGrades", "Id", "dbo.Subjects");
            DropForeignKey("dbo.ScoreGrades", "Id", "dbo.Ratings");
            DropForeignKey("dbo.BehaviourActivities", "Id", "dbo.Ratings");
            DropForeignKey("dbo.KeyToRatings", "Id", "dbo.BehaviourActivities");
            DropForeignKey("dbo.LessonPlans", "Id", "dbo.SchoolSessions");
            DropForeignKey("dbo.SchoolSessions", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Students", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.AspNetUsers", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Illnesses", "MedicalHistoryId", "dbo.MedicalHistories");
            DropForeignKey("dbo.Disabilities", "MedicalHistoryId", "dbo.MedicalHistories");
            DropIndex("dbo.SubjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SubjectApplicationUsers", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectStudents", new[] { "Student_Id" });
            DropIndex("dbo.SubjectStudents", new[] { "Subject_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.EntranceExamSubjects", new[] { "EntranceExamId" });
            DropIndex("dbo.EntranceExamSubjects", new[] { "EntranceExamCandidateId" });
            DropIndex("dbo.EntranceExamCandidates", new[] { "EntranceExamId" });
            DropIndex("dbo.ContinuousAssessments", new[] { "ResultId" });
            DropIndex("dbo.ContinuousAssessments", new[] { "SubjectId" });
            DropIndex("dbo.Results", new[] { "ScoreGradeId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropIndex("dbo.Results", new[] { "SchoolSessionId" });
            DropIndex("dbo.Results", new[] { "Id" });
            DropIndex("dbo.PaymentTypes", new[] { "Payment_Id" });
            DropIndex("dbo.Payments", new[] { "Student_Id" });
            DropIndex("dbo.Hostels", new[] { "Id" });
            DropIndex("dbo.Clubs", new[] { "Patron_Id" });
            DropIndex("dbo.LocalGovernments", new[] { "StateId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.KeyToRatings", new[] { "Id" });
            DropIndex("dbo.BehaviourActivities", new[] { "Id" });
            DropIndex("dbo.ScoreGrades", new[] { "Id" });
            DropIndex("dbo.SchoolSessions", new[] { "SchoolId" });
            DropIndex("dbo.LessonPlans", new[] { "TeacherId" });
            DropIndex("dbo.LessonPlans", new[] { "Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "School_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "SchoolId" });
            DropIndex("dbo.AspNetUsers", new[] { "StateId" });
            DropIndex("dbo.Classes", new[] { "FormTeacher_Id" });
            DropIndex("dbo.Attendances", new[] { "ClassId" });
            DropIndex("dbo.Attendances", new[] { "SessionId" });
            DropIndex("dbo.Attendances", new[] { "Id" });
            DropIndex("dbo.Students", new[] { "School_Id" });
            DropIndex("dbo.Students", new[] { "StateId" });
            DropIndex("dbo.Students", new[] { "HostelId" });
            DropIndex("dbo.Students", new[] { "GuardianId" });
            DropIndex("dbo.Students", new[] { "ClubId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.Students", new[] { "AttendanceId" });
            DropIndex("dbo.Illnesses", new[] { "MedicalHistoryId" });
            DropIndex("dbo.Disabilities", new[] { "MedicalHistoryId" });
            DropIndex("dbo.MedicalHistories", new[] { "Id" });
            DropIndex("dbo.Allergies", new[] { "MedicalHistoryId" });
            DropTable("dbo.SubjectApplicationUsers");
            DropTable("dbo.SubjectStudents");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.EntranceExamRegistrations");
            DropTable("dbo.EntranceExamSubjects");
            DropTable("dbo.EntranceExams");
            DropTable("dbo.EntranceExamCandidates");
            DropTable("dbo.ContinuousAssessments");
            DropTable("dbo.Results");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Payments");
            DropTable("dbo.Hostels");
            DropTable("dbo.Guardians");
            DropTable("dbo.Clubs");
            DropTable("dbo.LocalGovernments");
            DropTable("dbo.States");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.KeyToRatings");
            DropTable("dbo.BehaviourActivities");
            DropTable("dbo.Ratings");
            DropTable("dbo.ScoreGrades");
            DropTable("dbo.Subjects");
            DropTable("dbo.Schools");
            DropTable("dbo.SchoolSessions");
            DropTable("dbo.LessonPlans");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Classes");
            DropTable("dbo.Attendances");
            DropTable("dbo.Students");
            DropTable("dbo.Illnesses");
            DropTable("dbo.Disabilities");
            DropTable("dbo.MedicalHistories");
            DropTable("dbo.Allergies");
        }
    }
}
