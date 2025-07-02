using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KubWander.Migrations
{
    public partial class userIdentityUI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Удаляем внешние ключи, зависящие от users.id
            migrationBuilder.Sql("ALTER TABLE comments DROP CONSTRAINT IF EXISTS comments_user_id_fkey;");
            migrationBuilder.Sql("ALTER TABLE photos DROP CONSTRAINT IF EXISTS photos_user_id_fkey;");
            migrationBuilder.Sql("ALTER TABLE photo_reviews DROP CONSTRAINT IF EXISTS photo_reviews_reviewer_id_fkey;");
            migrationBuilder.Sql("ALTER TABLE user_achievements DROP CONSTRAINT IF EXISTS user_achievements_user_id_fkey;");
            migrationBuilder.Sql("ALTER TABLE user_quests DROP CONSTRAINT IF EXISTS user_quests_user_id_fkey;");

            // 2. Удаляем первичный ключ users_pkey
            migrationBuilder.DropPrimaryKey(
                name: "users_pkey",
                table: "users");

            // 3. Переименовываем столбцы для соответствия модели
            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "users",
                newName: "PasswordHash");

            // 4. Изменяем типы столбцов в таблице users
            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "user",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValueSql: "'user'::character varying");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registered_at",
                table: "users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "points",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            // 5. Изменяем тип столбца Id с integer на text
            migrationBuilder.Sql("ALTER TABLE users ALTER COLUMN \"Id\" TYPE text USING (\"Id\"::text);");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            // 6. Добавляем столбцы для IdentityUser
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            // 7. Изменяем типы user_id и reviewer_id в зависимых таблицах
            migrationBuilder.Sql("ALTER TABLE user_quests ALTER COLUMN user_id TYPE text USING (user_id::text);");
            migrationBuilder.Sql("ALTER TABLE user_achievements ALTER COLUMN user_id TYPE text USING (user_id::text);");
            migrationBuilder.Sql("ALTER TABLE photos ALTER COLUMN user_id TYPE text USING (user_id::text);");
            migrationBuilder.Sql("ALTER TABLE photo_reviews ALTER COLUMN reviewer_id TYPE text USING (reviewer_id::text);");
            migrationBuilder.Sql("ALTER TABLE comments ALTER COLUMN user_id TYPE text USING (user_id::text);");

            migrationBuilder.AlterColumn<DateTime>(
                name: "completed_at",
                table: "user_quests",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            // 8. Восстанавливаем первичный ключ
            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            // 9. Восстанавливаем внешние ключи
            migrationBuilder.Sql("ALTER TABLE comments ADD CONSTRAINT comments_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(\"Id\");");
            migrationBuilder.Sql("ALTER TABLE photos ADD CONSTRAINT photos_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(\"Id\");");
            migrationBuilder.Sql("ALTER TABLE photo_reviews ADD CONSTRAINT photo_reviews_reviewer_id_fkey FOREIGN KEY (reviewer_id) REFERENCES users(\"Id\") ON DELETE SET NULL;");
            migrationBuilder.Sql("ALTER TABLE user_achievements ADD CONSTRAINT user_achievements_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(\"Id\");");
            migrationBuilder.Sql("ALTER TABLE user_quests ADD CONSTRAINT user_quests_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(\"Id\");");

            // 10. Создаем индексы для Identity
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Удаляем индексы для Identity
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "users");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "users");

            // 2. Удаляем внешние ключи
            migrationBuilder.Sql("ALTER TABLE comments DROP CONSTRAINT IF EXISTS comments_user_id_fkey;");
            migrationBuilder.Sql("ALTER TABLE photos DROP CONSTRAINT IF EXISTS photos_user_id_fkey;");
            migrationBuilder.Sql("ALTER TABLE photo_reviews DROP CONSTRAINT IF EXISTS photo_reviews_reviewer_id_fkey;");
            migrationBuilder.Sql("ALTER TABLE user_achievements DROP CONSTRAINT IF EXISTS user_achievements_user_id_fkey;");
            migrationBuilder.Sql("ALTER TABLE user_quests DROP CONSTRAINT IF EXISTS user_quests_user_id_fkey;");

            // 3. Удаляем первичный ключ
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            // 4. Удаляем столбцы Identity
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "users");

            // 5. Переименовываем столбцы обратно
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "password_hash");

            // 6. Возвращаем типы столбцов
            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "'user'::character varying",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldDefaultValue: "user");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registered_at",
                table: "users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "points",
                table: "users",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            // 7. Возвращаем тип id в integer
            migrationBuilder.Sql("ALTER TABLE users ALTER COLUMN id TYPE integer USING (id::integer);");

            migrationBuilder.AlterColumn<string>(
                name: "password_hash",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            // 8. Возвращаем типы user_id и reviewer_id в integer
            migrationBuilder.Sql("ALTER TABLE user_quests ALTER COLUMN user_id TYPE integer USING (user_id::integer);");
            migrationBuilder.Sql("ALTER TABLE user_achievements ALTER COLUMN user_id TYPE integer USING (user_id::integer);");
            migrationBuilder.Sql("ALTER TABLE photos ALTER COLUMN user_id TYPE integer USING (user_id::integer);");
            migrationBuilder.Sql("ALTER TABLE photo_reviews ALTER COLUMN reviewer_id TYPE integer USING (reviewer_id::integer);");
            migrationBuilder.Sql("ALTER TABLE comments ALTER COLUMN user_id TYPE integer USING (user_id::integer);");

            migrationBuilder.AlterColumn<DateTime>(
                name: "completed_at",
                table: "user_quests",
                type: "timestamp without time zone",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            // 9. Восстанавливаем первичный ключ
            migrationBuilder.AddPrimaryKey(
                name: "users_pkey",
                table: "users",
                column: "id")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            // 10. Восстанавливаем внешние ключи
            migrationBuilder.Sql("ALTER TABLE comments ADD CONSTRAINT comments_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(id);");
            migrationBuilder.Sql("ALTER TABLE photos ADD CONSTRAINT photos_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(id);");
            migrationBuilder.Sql("ALTER TABLE photo_reviews ADD CONSTRAINT photo_reviews_reviewer_id_fkey FOREIGN KEY (reviewer_id) REFERENCES users(id) ON DELETE SET NULL;");
            migrationBuilder.Sql("ALTER TABLE user_achievements ADD CONSTRAINT user_achievements_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(id);");
            migrationBuilder.Sql("ALTER TABLE user_quests ADD CONSTRAINT user_quests_user_id_fkey FOREIGN KEY (user_id) REFERENCES users(id);");
        }
    }
}