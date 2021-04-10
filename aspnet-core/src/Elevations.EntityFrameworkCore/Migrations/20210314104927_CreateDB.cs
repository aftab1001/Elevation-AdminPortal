namespace Elevations.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CreateDB : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("AbpAuditLogs");

            migrationBuilder.DropTable("AbpBackgroundJobs");

            migrationBuilder.DropTable("AbpDynamicEntityPropertyValues");

            migrationBuilder.DropTable("AbpDynamicPropertyValues");

            migrationBuilder.DropTable("AbpEntityPropertyChanges");

            migrationBuilder.DropTable("AbpFeatures");

            migrationBuilder.DropTable("AbpLanguages");

            migrationBuilder.DropTable("AbpLanguageTexts");

            migrationBuilder.DropTable("AbpNotifications");

            migrationBuilder.DropTable("AbpNotificationSubscriptions");

            migrationBuilder.DropTable("AbpOrganizationUnitRoles");

            migrationBuilder.DropTable("AbpOrganizationUnits");

            migrationBuilder.DropTable("AbpPermissions");

            migrationBuilder.DropTable("AbpRoleClaims");

            migrationBuilder.DropTable("AbpSettings");

            migrationBuilder.DropTable("AbpTenantNotifications");

            migrationBuilder.DropTable("AbpTenants");

            migrationBuilder.DropTable("AbpUserAccounts");

            migrationBuilder.DropTable("AbpUserClaims");

            migrationBuilder.DropTable("AbpUserLoginAttempts");

            migrationBuilder.DropTable("AbpUserLogins");

            migrationBuilder.DropTable("AbpUserNotifications");

            migrationBuilder.DropTable("AbpUserOrganizationUnits");

            migrationBuilder.DropTable("AbpUserRoles");

            migrationBuilder.DropTable("AbpUserTokens");

            migrationBuilder.DropTable("AbpWebhookSendAttempts");

            migrationBuilder.DropTable("AbpWebhookSubscriptions");

            migrationBuilder.DropTable("Apartments");

            migrationBuilder.DropTable("Dashboard");

            migrationBuilder.DropTable("Dishes");

            migrationBuilder.DropTable("News");

            migrationBuilder.DropTable("Reservation");

            migrationBuilder.DropTable("Rooms");

            migrationBuilder.DropTable("AbpDynamicEntityProperties");

            migrationBuilder.DropTable("AbpEntityChanges");

            migrationBuilder.DropTable("AbpRoles");

            migrationBuilder.DropTable("AbpEditions");

            migrationBuilder.DropTable("AbpWebhookEvents");

            migrationBuilder.DropTable("ApartmentCategory");

            migrationBuilder.DropTable("RoomsCategory");

            migrationBuilder.DropTable("AbpDynamicProperties");

            migrationBuilder.DropTable("AbpEntityChangeSets");

            migrationBuilder.DropTable("AbpUsers");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AbpAuditLogs",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: true),
                                 ServiceName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                                 MethodName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                                 Parameters = table.Column<string>("nvarchar(1024)", maxLength: 1024, nullable: true),
                                 ReturnValue = table.Column<string>("nvarchar(max)", nullable: true),
                                 ExecutionTime = table.Column<DateTime>("datetime2", nullable: false),
                                 ExecutionDuration = table.Column<int>("int", nullable: false),
                                 ClientIpAddress = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: true),
                                 ClientName = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: true),
                                 BrowserInfo = table.Column<string>("nvarchar(512)", maxLength: 512, nullable: true),
                                 Exception = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: true),
                                 ImpersonatorUserId = table.Column<long>("bigint", nullable: true),
                                 ImpersonatorTenantId = table.Column<int>("int", nullable: true),
                                 CustomData = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpAuditLogs", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpBackgroundJobs",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 JobType = table.Column<string>("nvarchar(512)", maxLength: 512, nullable: false),
                                 JobArgs = table.Column<string>("nvarchar(max)", maxLength: 1048576, nullable: false),
                                 TryCount = table.Column<short>("smallint", nullable: false),
                                 NextTryTime = table.Column<DateTime>("datetime2", nullable: false),
                                 LastTryTime = table.Column<DateTime>("datetime2", nullable: true),
                                 IsAbandoned = table.Column<bool>("bit", nullable: false),
                                 Priority = table.Column<byte>("tinyint", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpDynamicProperties",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 PropertyName = table.Column<string>("nvarchar(450)", nullable: true),
                                 DisplayName = table.Column<string>("nvarchar(max)", nullable: true),
                                 InputType = table.Column<string>("nvarchar(max)", nullable: true),
                                 Permission = table.Column<string>("nvarchar(max)", nullable: true),
                                 TenantId = table.Column<int>("int", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpDynamicProperties", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpEditions",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 Name = table.Column<string>("nvarchar(32)", maxLength: 32, nullable: false),
                                 DisplayName = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 DeleterUserId = table.Column<long>("bigint", nullable: true),
                                 DeletionTime = table.Column<DateTime>("datetime2", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpEditions", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpEntityChangeSets",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 BrowserInfo = table.Column<string>("nvarchar(512)", maxLength: 512, nullable: true),
                                 ClientIpAddress = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: true),
                                 ClientName = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 ExtensionData = table.Column<string>("nvarchar(max)", nullable: true),
                                 ImpersonatorTenantId = table.Column<int>("int", nullable: true),
                                 ImpersonatorUserId = table.Column<long>("bigint", nullable: true),
                                 Reason = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpEntityChangeSets", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpLanguages",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 Name = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                                 DisplayName = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                                 Icon = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: true),
                                 IsDisabled = table.Column<bool>("bit", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 DeleterUserId = table.Column<long>("bigint", nullable: true),
                                 DeletionTime = table.Column<DateTime>("datetime2", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpLanguages", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpLanguageTexts",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 LanguageName = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                                 Source = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                                 Key = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: false),
                                 Value = table.Column<string>("nvarchar(max)", maxLength: 67108864, nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpLanguageTexts", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpNotifications",
                table => new
                             {
                                 Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 NotificationName =
                                     table.Column<string>("nvarchar(96)", maxLength: 96, nullable: false),
                                 Data = table.Column<string>("nvarchar(max)", maxLength: 1048576, nullable: true),
                                 DataTypeName = table.Column<string>("nvarchar(512)", maxLength: 512, nullable: true),
                                 EntityTypeName = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: true),
                                 EntityTypeAssemblyQualifiedName = table.Column<string>(
                                     "nvarchar(512)",
                                     maxLength: 512,
                                     nullable: true),
                                 EntityId = table.Column<string>("nvarchar(96)", maxLength: 96, nullable: true),
                                 Severity = table.Column<byte>("tinyint", nullable: false),
                                 UserIds = table.Column<string>("nvarchar(max)", maxLength: 131072, nullable: true),
                                 ExcludedUserIds = table.Column<string>(
                                     "nvarchar(max)",
                                     maxLength: 131072,
                                     nullable: true),
                                 TenantIds = table.Column<string>("nvarchar(max)", maxLength: 131072, nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpNotifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpNotificationSubscriptions",
                table => new
                             {
                                 Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: false),
                                 NotificationName = table.Column<string>("nvarchar(96)", maxLength: 96, nullable: true),
                                 EntityTypeName = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: true),
                                 EntityTypeAssemblyQualifiedName = table.Column<string>(
                                     "nvarchar(512)",
                                     maxLength: 512,
                                     nullable: true),
                                 EntityId = table.Column<string>("nvarchar(96)", maxLength: 96, nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpNotificationSubscriptions", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpOrganizationUnitRoles",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 RoleId = table.Column<int>("int", nullable: false),
                                 OrganizationUnitId = table.Column<long>("bigint", nullable: false),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpOrganizationUnits",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 ParentId = table.Column<long>("bigint", nullable: true),
                                 Code = table.Column<string>("nvarchar(95)", maxLength: 95, nullable: false),
                                 DisplayName = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 DeleterUserId = table.Column<long>("bigint", nullable: true),
                                 DeletionTime = table.Column<DateTime>("datetime2", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpOrganizationUnits", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                            x => x.ParentId,
                            "AbpOrganizationUnits",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                    });

            migrationBuilder.CreateTable(
                "AbpTenantNotifications",
                table => new
                             {
                                 Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 NotificationName =
                                     table.Column<string>("nvarchar(96)", maxLength: 96, nullable: false),
                                 Data = table.Column<string>("nvarchar(max)", maxLength: 1048576, nullable: true),
                                 DataTypeName = table.Column<string>("nvarchar(512)", maxLength: 512, nullable: true),
                                 EntityTypeName = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: true),
                                 EntityTypeAssemblyQualifiedName = table.Column<string>(
                                     "nvarchar(512)",
                                     maxLength: 512,
                                     nullable: true),
                                 EntityId = table.Column<string>("nvarchar(96)", maxLength: 96, nullable: true),
                                 Severity = table.Column<byte>("tinyint", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpTenantNotifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserAccounts",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: false),
                                 UserLinkId = table.Column<long>("bigint", nullable: true),
                                 UserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                                 EmailAddress = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 DeleterUserId = table.Column<long>("bigint", nullable: true),
                                 DeletionTime = table.Column<DateTime>("datetime2", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpUserAccounts", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserLoginAttempts",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 TenancyName = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: true),
                                 UserNameOrEmailAddress = table.Column<string>(
                                     "nvarchar(256)",
                                     maxLength: 256,
                                     nullable: true),
                                 ClientIpAddress = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: true),
                                 ClientName = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: true),
                                 BrowserInfo = table.Column<string>("nvarchar(512)", maxLength: 512, nullable: true),
                                 Result = table.Column<byte>("tinyint", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpUserLoginAttempts", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserNotifications",
                table => new
                             {
                                 Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: false),
                                 TenantNotificationId = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 State = table.Column<int>("int", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpUserNotifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserOrganizationUnits",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: false),
                                 OrganizationUnitId = table.Column<long>("bigint", nullable: false),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpUserOrganizationUnits", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUsers",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 DeleterUserId = table.Column<long>("bigint", nullable: true),
                                 DeletionTime = table.Column<DateTime>("datetime2", nullable: true),
                                 AuthenticationSource = table.Column<string>(
                                     "nvarchar(64)",
                                     maxLength: 64,
                                     nullable: true),
                                 UserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: false),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 EmailAddress = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: false),
                                 Name = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                                 Surname = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                                 Password = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                                 EmailConfirmationCode = table.Column<string>(
                                     "nvarchar(328)",
                                     maxLength: 328,
                                     nullable: true),
                                 PasswordResetCode = table.Column<string>(
                                     "nvarchar(328)",
                                     maxLength: 328,
                                     nullable: true),
                                 LockoutEndDateUtc = table.Column<DateTime>("datetime2", nullable: true),
                                 AccessFailedCount = table.Column<int>("int", nullable: false),
                                 IsLockoutEnabled = table.Column<bool>("bit", nullable: false),
                                 PhoneNumber = table.Column<string>("nvarchar(32)", maxLength: 32, nullable: true),
                                 IsPhoneNumberConfirmed = table.Column<bool>("bit", nullable: false),
                                 SecurityStamp = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: true),
                                 IsTwoFactorEnabled = table.Column<bool>("bit", nullable: false),
                                 IsEmailConfirmed = table.Column<bool>("bit", nullable: false),
                                 IsActive = table.Column<bool>("bit", nullable: false),
                                 NormalizedUserName = table.Column<string>(
                                     "nvarchar(256)",
                                     maxLength: 256,
                                     nullable: false),
                                 NormalizedEmailAddress = table.Column<string>(
                                     "nvarchar(256)",
                                     maxLength: 256,
                                     nullable: false),
                                 ConcurrencyStamp = table.Column<string>(
                                     "nvarchar(128)",
                                     maxLength: 128,
                                     nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpUsers", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpUsers_AbpUsers_CreatorUserId",
                            x => x.CreatorUserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            "FK_AbpUsers_AbpUsers_DeleterUserId",
                            x => x.DeleterUserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            "FK_AbpUsers_AbpUsers_LastModifierUserId",
                            x => x.LastModifierUserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                    });

            migrationBuilder.CreateTable(
                "AbpWebhookEvents",
                table => new
                             {
                                 Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 WebhookName = table.Column<string>("nvarchar(max)", nullable: false),
                                 Data = table.Column<string>("nvarchar(max)", nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 DeletionTime = table.Column<DateTime>("datetime2", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpWebhookEvents", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpWebhookSubscriptions",
                table => new
                             {
                                 Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 WebhookUri = table.Column<string>("nvarchar(max)", nullable: false),
                                 Secret = table.Column<string>("nvarchar(max)", nullable: false),
                                 IsActive = table.Column<bool>("bit", nullable: false),
                                 Webhooks = table.Column<string>("nvarchar(max)", nullable: true),
                                 Headers = table.Column<string>("nvarchar(max)", nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_AbpWebhookSubscriptions", x => x.Id); });

            migrationBuilder.CreateTable(
                "ApartmentCategory",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 Name = table.Column<string>("nvarchar(max)", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_ApartmentCategory", x => x.Id); });

            migrationBuilder.CreateTable(
                "Dashboard",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 Description1 = table.Column<string>("nvarchar(max)", nullable: false),
                                 Description2 = table.Column<string>("nvarchar(max)", nullable: true),
                                 Image = table.Column<string>("nvarchar(max)", nullable: false),
                                 ImageSequence = table.Column<int>("int", nullable: false),
                                 Price = table.Column<decimal>("decimal(18,2)", nullable: false),
                                 Title = table.Column<string>("nvarchar(max)", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_Dashboard", x => x.Id); });

            migrationBuilder.CreateTable(
                "Dishes",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 Description = table.Column<string>("nvarchar(max)", nullable: true),
                                 Image = table.Column<string>("nvarchar(max)", nullable: false),
                                 ImageSequence = table.Column<int>("int", nullable: false),
                                 Name = table.Column<string>("nvarchar(max)", nullable: false),
                                 Price = table.Column<decimal>("decimal(18,2)", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_Dishes", x => x.Id); });

            migrationBuilder.CreateTable(
                "News",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 Date = table.Column<DateTime>("datetime2", nullable: false),
                                 Description = table.Column<string>("nvarchar(max)", nullable: true),
                                 Image = table.Column<string>("nvarchar(max)", nullable: false),
                                 ImageSequence = table.Column<int>("int", nullable: false),
                                 Title = table.Column<string>("nvarchar(max)", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_News", x => x.Id); });

            migrationBuilder.CreateTable(
                "Reservation",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 Address = table.Column<string>("nvarchar(max)", nullable: true),
                                 Email = table.Column<string>("nvarchar(max)", nullable: false),
                                 Message = table.Column<string>("nvarchar(max)", nullable: true),
                                 Name = table.Column<string>("nvarchar(max)", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_Reservation", x => x.Id); });

            migrationBuilder.CreateTable(
                "RoomsCategory",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 Name = table.Column<string>("nvarchar(max)", nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_RoomsCategory", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpDynamicEntityProperties",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 EntityFullName = table.Column<string>("nvarchar(450)", nullable: true),
                                 DynamicPropertyId = table.Column<int>("int", nullable: false),
                                 TenantId = table.Column<int>("int", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpDynamicEntityProperties", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpDynamicEntityProperties_AbpDynamicProperties_DynamicPropertyId",
                            x => x.DynamicPropertyId,
                            "AbpDynamicProperties",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpDynamicPropertyValues",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 Value = table.Column<string>("nvarchar(max)", nullable: false),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 DynamicPropertyId = table.Column<int>("int", nullable: false)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpDynamicPropertyValues", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpDynamicPropertyValues_AbpDynamicProperties_DynamicPropertyId",
                            x => x.DynamicPropertyId,
                            "AbpDynamicProperties",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpFeatures",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 Name = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                                 Value = table.Column<string>("nvarchar(2000)", maxLength: 2000, nullable: false),
                                 Discriminator = table.Column<string>("nvarchar(max)", nullable: false),
                                 EditionId = table.Column<int>("int", nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpFeatures_AbpEditions_EditionId",
                            x => x.EditionId,
                            "AbpEditions",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpEntityChanges",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 ChangeTime = table.Column<DateTime>("datetime2", nullable: false),
                                 ChangeType = table.Column<byte>("tinyint", nullable: false),
                                 EntityChangeSetId = table.Column<long>("bigint", nullable: false),
                                 EntityId = table.Column<string>("nvarchar(48)", maxLength: 48, nullable: true),
                                 EntityTypeFullName = table.Column<string>(
                                     "nvarchar(192)",
                                     maxLength: 192,
                                     nullable: true),
                                 TenantId = table.Column<int>("int", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpEntityChanges_AbpEntityChangeSets_EntityChangeSetId",
                            x => x.EntityChangeSetId,
                            "AbpEntityChangeSets",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpRoles",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 Description = table.Column<string>("nvarchar(max)", maxLength: 5000, nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 DeleterUserId = table.Column<long>("bigint", nullable: true),
                                 DeletionTime = table.Column<DateTime>("datetime2", nullable: true),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 Name = table.Column<string>("nvarchar(32)", maxLength: 32, nullable: false),
                                 DisplayName = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                                 IsStatic = table.Column<bool>("bit", nullable: false),
                                 IsDefault = table.Column<bool>("bit", nullable: false),
                                 NormalizedName = table.Column<string>("nvarchar(32)", maxLength: 32, nullable: false),
                                 ConcurrencyStamp = table.Column<string>(
                                     "nvarchar(128)",
                                     maxLength: 128,
                                     nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpRoles", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpRoles_AbpUsers_CreatorUserId",
                            x => x.CreatorUserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            "FK_AbpRoles_AbpUsers_DeleterUserId",
                            x => x.DeleterUserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            "FK_AbpRoles_AbpUsers_LastModifierUserId",
                            x => x.LastModifierUserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                    });

            migrationBuilder.CreateTable(
                "AbpSettings",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: true),
                                 Name = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: false),
                                 Value = table.Column<string>("nvarchar(max)", nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpSettings", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpSettings_AbpUsers_UserId",
                            x => x.UserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                    });

            migrationBuilder.CreateTable(
                "AbpTenants",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true),
                                 IsDeleted = table.Column<bool>("bit", nullable: false),
                                 DeleterUserId = table.Column<long>("bigint", nullable: true),
                                 DeletionTime = table.Column<DateTime>("datetime2", nullable: true),
                                 TenancyName = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                                 Name = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                                 ConnectionString = table.Column<string>(
                                     "nvarchar(1024)",
                                     maxLength: 1024,
                                     nullable: true),
                                 IsActive = table.Column<bool>("bit", nullable: false),
                                 EditionId = table.Column<int>("int", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpTenants", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpTenants_AbpEditions_EditionId",
                            x => x.EditionId,
                            "AbpEditions",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            "FK_AbpTenants_AbpUsers_CreatorUserId",
                            x => x.CreatorUserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            "FK_AbpTenants_AbpUsers_DeleterUserId",
                            x => x.DeleterUserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            "FK_AbpTenants_AbpUsers_LastModifierUserId",
                            x => x.LastModifierUserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                    });

            migrationBuilder.CreateTable(
                "AbpUserClaims",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: false),
                                 ClaimType = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                                 ClaimValue = table.Column<string>("nvarchar(max)", nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpUserClaims_AbpUsers_UserId",
                            x => x.UserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpUserLogins",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: false),
                                 LoginProvider = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                                 ProviderKey = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: false)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpUserLogins", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpUserLogins_AbpUsers_UserId",
                            x => x.UserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpUserRoles",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: false),
                                 RoleId = table.Column<int>("int", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpUserRoles", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpUserRoles_AbpUsers_UserId",
                            x => x.UserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpUserTokens",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: false),
                                 LoginProvider = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: true),
                                 Name = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: true),
                                 Value = table.Column<string>("nvarchar(512)", maxLength: 512, nullable: true),
                                 ExpireDate = table.Column<DateTime>("datetime2", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpUserTokens", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpUserTokens_AbpUsers_UserId",
                            x => x.UserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpWebhookSendAttempts",
                table => new
                             {
                                 Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 WebhookEventId = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 WebhookSubscriptionId = table.Column<Guid>("uniqueidentifier", nullable: false),
                                 Response = table.Column<string>("nvarchar(max)", nullable: true),
                                 ResponseStatusCode = table.Column<int>("int", nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 TenantId = table.Column<int>("int", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpWebhookSendAttempts", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpWebhookSendAttempts_AbpWebhookEvents_WebhookEventId",
                            x => x.WebhookEventId,
                            "AbpWebhookEvents",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "Apartments",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 ApartmentCategory = table.Column<int>("int", nullable: true),
                                 Description = table.Column<string>("nvarchar(max)", nullable: false),
                                 Image = table.Column<string>("nvarchar(max)", nullable: false),
                                 ImageSequence = table.Column<int>("int", nullable: false),
                                 Name = table.Column<string>("nvarchar(max)", nullable: false),
                                 Price = table.Column<string>("nvarchar(max)", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_Apartments", x => x.Id);
                        table.ForeignKey(
                            "FK_Apartments_ApartmentCategory_ApartmentCategory",
                            x => x.ApartmentCategory,
                            "ApartmentCategory",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                    });

            migrationBuilder.CreateTable(
                "Rooms",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 RoomsCategory = table.Column<int>("int", nullable: true),
                                 Description = table.Column<string>("nvarchar(max)", nullable: false),
                                 Image = table.Column<string>("nvarchar(max)", nullable: false),
                                 ImageSequence = table.Column<int>("int", nullable: false),
                                 Name = table.Column<string>("nvarchar(max)", nullable: false),
                                 Price = table.Column<string>("nvarchar(max)", nullable: false),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true),
                                 LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                                 LastModifierUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_Rooms", x => x.Id);
                        table.ForeignKey(
                            "FK_Rooms_RoomsCategory_RoomsCategory",
                            x => x.RoomsCategory,
                            "RoomsCategory",
                            "Id",
                            onDelete: ReferentialAction.Restrict);
                    });

            migrationBuilder.CreateTable(
                "AbpDynamicEntityPropertyValues",
                table => new
                             {
                                 Id = table.Column<int>("int", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 Value = table.Column<string>("nvarchar(max)", nullable: false),
                                 EntityId = table.Column<string>("nvarchar(max)", nullable: true),
                                 DynamicEntityPropertyId = table.Column<int>("int", nullable: false),
                                 TenantId = table.Column<int>("int", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpDynamicEntityPropertyValues", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpDynamicEntityPropertyValues_AbpDynamicEntityProperties_DynamicEntityPropertyId",
                            x => x.DynamicEntityPropertyId,
                            "AbpDynamicEntityProperties",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpEntityPropertyChanges",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 EntityChangeId = table.Column<long>("bigint", nullable: false),
                                 NewValue = table.Column<string>("nvarchar(512)", maxLength: 512, nullable: true),
                                 OriginalValue = table.Column<string>("nvarchar(512)", maxLength: 512, nullable: true),
                                 PropertyName = table.Column<string>("nvarchar(96)", maxLength: 96, nullable: true),
                                 PropertyTypeFullName = table.Column<string>(
                                     "nvarchar(192)",
                                     maxLength: 192,
                                     nullable: true),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 NewValueHash = table.Column<string>("nvarchar(max)", nullable: true),
                                 OriginalValueHash = table.Column<string>("nvarchar(max)", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                            x => x.EntityChangeId,
                            "AbpEntityChanges",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpPermissions",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 Name = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                                 IsGranted = table.Column<bool>("bit", nullable: false),
                                 Discriminator = table.Column<string>("nvarchar(max)", nullable: false),
                                 RoleId = table.Column<int>("int", nullable: true),
                                 UserId = table.Column<long>("bigint", nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpPermissions", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpPermissions_AbpRoles_RoleId",
                            x => x.RoleId,
                            "AbpRoles",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            "FK_AbpPermissions_AbpUsers_UserId",
                            x => x.UserId,
                            "AbpUsers",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateTable(
                "AbpRoleClaims",
                table => new
                             {
                                 Id = table.Column<long>("bigint", nullable: false)
                                     .Annotation("SqlServer:Identity", "1, 1"),
                                 TenantId = table.Column<int>("int", nullable: true),
                                 RoleId = table.Column<int>("int", nullable: false),
                                 ClaimType = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                                 ClaimValue = table.Column<string>("nvarchar(max)", nullable: true),
                                 CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                                 CreatorUserId = table.Column<long>("bigint", nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                        table.ForeignKey(
                            "FK_AbpRoleClaims_AbpRoles_RoleId",
                            x => x.RoleId,
                            "AbpRoles",
                            "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_ExecutionDuration",
                "AbpAuditLogs",
                new[] { "TenantId", "ExecutionDuration" });

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_ExecutionTime",
                "AbpAuditLogs",
                new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_UserId",
                "AbpAuditLogs",
                new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
                "AbpBackgroundJobs",
                new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicEntityProperties_DynamicPropertyId",
                "AbpDynamicEntityProperties",
                "DynamicPropertyId");

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicEntityProperties_EntityFullName_DynamicPropertyId_TenantId",
                "AbpDynamicEntityProperties",
                new[] { "EntityFullName", "DynamicPropertyId", "TenantId" },
                unique: true,
                filter: "[EntityFullName] IS NOT NULL AND [TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicEntityPropertyValues_DynamicEntityPropertyId",
                "AbpDynamicEntityPropertyValues",
                "DynamicEntityPropertyId");

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicProperties_PropertyName_TenantId",
                "AbpDynamicProperties",
                new[] { "PropertyName", "TenantId" },
                unique: true,
                filter: "[PropertyName] IS NOT NULL AND [TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicPropertyValues_DynamicPropertyId",
                "AbpDynamicPropertyValues",
                "DynamicPropertyId");

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChanges_EntityChangeSetId",
                "AbpEntityChanges",
                "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChanges_EntityTypeFullName_EntityId",
                "AbpEntityChanges",
                new[] { "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChangeSets_TenantId_CreationTime",
                "AbpEntityChangeSets",
                new[] { "TenantId", "CreationTime" });

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChangeSets_TenantId_Reason",
                "AbpEntityChangeSets",
                new[] { "TenantId", "Reason" });

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChangeSets_TenantId_UserId",
                "AbpEntityChangeSets",
                new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                "IX_AbpEntityPropertyChanges_EntityChangeId",
                "AbpEntityPropertyChanges",
                "EntityChangeId");

            migrationBuilder.CreateIndex("IX_AbpFeatures_EditionId_Name", "AbpFeatures", new[] { "EditionId", "Name" });

            migrationBuilder.CreateIndex("IX_AbpFeatures_TenantId_Name", "AbpFeatures", new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex("IX_AbpLanguages_TenantId_Name", "AbpLanguages", new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key",
                "AbpLanguageTexts",
                new[] { "TenantId", "Source", "LanguageName", "Key" });

            migrationBuilder.CreateIndex(
                "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName_EntityId_UserId",
                "AbpNotificationSubscriptions",
                new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                "IX_AbpNotificationSubscriptions_TenantId_NotificationName_EntityTypeName_EntityId_UserId",
                "AbpNotificationSubscriptions",
                new[] { "TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId",
                "AbpOrganizationUnitRoles",
                new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnitRoles_TenantId_RoleId",
                "AbpOrganizationUnitRoles",
                new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex("IX_AbpOrganizationUnits_ParentId", "AbpOrganizationUnits", "ParentId");

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnits_TenantId_Code",
                "AbpOrganizationUnits",
                new[] { "TenantId", "Code" });

            migrationBuilder.CreateIndex("IX_AbpPermissions_RoleId", "AbpPermissions", "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AbpPermissions_TenantId_Name",
                "AbpPermissions",
                new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex("IX_AbpPermissions_UserId", "AbpPermissions", "UserId");

            migrationBuilder.CreateIndex("IX_AbpRoleClaims_RoleId", "AbpRoleClaims", "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoleClaims_TenantId_ClaimType",
                "AbpRoleClaims",
                new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex("IX_AbpRoles_CreatorUserId", "AbpRoles", "CreatorUserId");

            migrationBuilder.CreateIndex("IX_AbpRoles_DeleterUserId", "AbpRoles", "DeleterUserId");

            migrationBuilder.CreateIndex("IX_AbpRoles_LastModifierUserId", "AbpRoles", "LastModifierUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_TenantId_NormalizedName",
                "AbpRoles",
                new[] { "TenantId", "NormalizedName" });

            migrationBuilder.CreateIndex(
                "IX_AbpSettings_TenantId_Name_UserId",
                "AbpSettings",
                new[] { "TenantId", "Name", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex("IX_AbpSettings_UserId", "AbpSettings", "UserId");

            migrationBuilder.CreateIndex("IX_AbpTenantNotifications_TenantId", "AbpTenantNotifications", "TenantId");

            migrationBuilder.CreateIndex("IX_AbpTenants_CreatorUserId", "AbpTenants", "CreatorUserId");

            migrationBuilder.CreateIndex("IX_AbpTenants_DeleterUserId", "AbpTenants", "DeleterUserId");

            migrationBuilder.CreateIndex("IX_AbpTenants_EditionId", "AbpTenants", "EditionId");

            migrationBuilder.CreateIndex("IX_AbpTenants_LastModifierUserId", "AbpTenants", "LastModifierUserId");

            migrationBuilder.CreateIndex("IX_AbpTenants_TenancyName", "AbpTenants", "TenancyName");

            migrationBuilder.CreateIndex("IX_AbpUserAccounts_EmailAddress", "AbpUserAccounts", "EmailAddress");

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_TenantId_EmailAddress",
                "AbpUserAccounts",
                new[] { "TenantId", "EmailAddress" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_TenantId_UserId",
                "AbpUserAccounts",
                new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_TenantId_UserName",
                "AbpUserAccounts",
                new[] { "TenantId", "UserName" });

            migrationBuilder.CreateIndex("IX_AbpUserAccounts_UserName", "AbpUserAccounts", "UserName");

            migrationBuilder.CreateIndex(
                "IX_AbpUserClaims_TenantId_ClaimType",
                "AbpUserClaims",
                new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex("IX_AbpUserClaims_UserId", "AbpUserClaims", "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Result",
                "AbpUserLoginAttempts",
                new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserLoginAttempts_UserId_TenantId",
                "AbpUserLoginAttempts",
                new[] { "UserId", "TenantId" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey",
                "AbpUserLogins",
                new[] { "TenantId", "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserLogins_TenantId_UserId",
                "AbpUserLogins",
                new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex("IX_AbpUserLogins_UserId", "AbpUserLogins", "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserNotifications_UserId_State_CreationTime",
                "AbpUserNotifications",
                new[] { "UserId", "State", "CreationTime" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId",
                "AbpUserOrganizationUnits",
                new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserOrganizationUnits_TenantId_UserId",
                "AbpUserOrganizationUnits",
                new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserRoles_TenantId_RoleId",
                "AbpUserRoles",
                new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserRoles_TenantId_UserId",
                "AbpUserRoles",
                new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex("IX_AbpUserRoles_UserId", "AbpUserRoles", "UserId");

            migrationBuilder.CreateIndex("IX_AbpUsers_CreatorUserId", "AbpUsers", "CreatorUserId");

            migrationBuilder.CreateIndex("IX_AbpUsers_DeleterUserId", "AbpUsers", "DeleterUserId");

            migrationBuilder.CreateIndex("IX_AbpUsers_LastModifierUserId", "AbpUsers", "LastModifierUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_TenantId_NormalizedEmailAddress",
                "AbpUsers",
                new[] { "TenantId", "NormalizedEmailAddress" });

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_TenantId_NormalizedUserName",
                "AbpUsers",
                new[] { "TenantId", "NormalizedUserName" });

            migrationBuilder.CreateIndex(
                "IX_AbpUserTokens_TenantId_UserId",
                "AbpUserTokens",
                new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex("IX_AbpUserTokens_UserId", "AbpUserTokens", "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpWebhookSendAttempts_WebhookEventId",
                "AbpWebhookSendAttempts",
                "WebhookEventId");

            migrationBuilder.CreateIndex("IX_Apartments_ApartmentCategory", "Apartments", "ApartmentCategory");

            migrationBuilder.CreateIndex("IX_Rooms_RoomsCategory", "Rooms", "RoomsCategory");
        }
    }
}