using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSistem.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "IdBank", "Name" },
                values: new object[,]
                {
                    { new Guid("6a38147d-92e0-43b8-8006-46649f9f6661"), "Белинвестбанк" },
                    { new Guid("6dd76ba9-0b62-49bd-8abb-f8f803013c46"), "Белагропромбанк" },
                    { new Guid("3d564a3e-67b8-42f6-a262-a29f7059a930"), "Беларусбанк" },
                    { new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73"), "Приорбанк" },
                    { new Guid("484426b9-677b-470b-b6b6-95c65b4efa32"), "ВТБбанк" }
                });

            migrationBuilder.InsertData(
                table: "CardOwners",
                columns: new[] { "IdCardOwner", "Name" },
                values: new object[,]
                {
                    { new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605"), "Кирилл" },
                    { new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81"), "Гриша" },
                    { new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7"), "Саша" },
                    { new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99"), "Дима" },
                    { new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a"), "Влад" }
                });

            migrationBuilder.InsertData(
                table: "SocialStatuses",
                columns: new[] { "IdSocialStatus", "Name" },
                values: new object[,]
                {
                    { new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431"), "Пенсионер" },
                    { new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4"), "Инвалид" },
                    { new Guid("04fadf24-1488-4197-9ae6-a8737ffe8337"), "Ветеран" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "IdTown", "Name" },
                values: new object[,]
                {
                    { new Guid("dd73f9af-e3c3-4ac3-b1c7-eea6cc3ae970"), "Витебск" },
                    { new Guid("2e4811ba-4642-4fe6-81fe-74c630179ac0"), "Полоцк" },
                    { new Guid("30d0d56f-0050-414a-b6da-8dc810f974e4"), "Новополоцк" },
                    { new Guid("76fc6ed2-cb47-46c1-bd18-eb4ae0990bd3"), "Минск" },
                    { new Guid("e89e58ea-0e90-497a-af2e-b034a4057332"), "Могилёв" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "IdAccount", "Balance", "IdBank", "IdCardOwner" },
                values: new object[,]
                {
                    { new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438"), 10m, new Guid("6a38147d-92e0-43b8-8006-46649f9f6661"), new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99") },
                    { new Guid("ec38f0a8-be2b-4f91-9af0-47ab5d1769c3"), 60m, new Guid("484426b9-677b-470b-b6b6-95c65b4efa32"), new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99") },
                    { new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca"), 20m, new Guid("6dd76ba9-0b62-49bd-8abb-f8f803013c46"), new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a") },
                    { new Guid("8c961fbe-9316-41b0-913c-6fed6977d479"), 70m, new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73"), new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a") },
                    { new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6"), 30m, new Guid("3d564a3e-67b8-42f6-a262-a29f7059a930"), new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81") },
                    { new Guid("93ad8e5c-cd32-4cd9-8944-224e76d6d24d"), 40m, new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73"), new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7") },
                    { new Guid("e4150c2e-c74a-400b-9fee-48b09ef3e805"), 50m, new Guid("484426b9-677b-470b-b6b6-95c65b4efa32"), new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605") }
                });

            migrationBuilder.InsertData(
                table: "BankBranches",
                columns: new[] { "IdBankBranch", "IdBank", "IdTown" },
                values: new object[,]
                {
                    { new Guid("3d3296ce-721f-4163-a301-59ec00c7f072"), new Guid("6dd76ba9-0b62-49bd-8abb-f8f803013c46"), new Guid("dd73f9af-e3c3-4ac3-b1c7-eea6cc3ae970") },
                    { new Guid("46c14374-6f18-483c-8e87-bafb41bf589f"), new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73"), new Guid("dd73f9af-e3c3-4ac3-b1c7-eea6cc3ae970") },
                    { new Guid("e2fe6e32-ee54-4d60-9047-a413022a61fd"), new Guid("3d564a3e-67b8-42f6-a262-a29f7059a930"), new Guid("76fc6ed2-cb47-46c1-bd18-eb4ae0990bd3") },
                    { new Guid("21a121e9-0080-46e3-8f6a-991759ad5cce"), new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73"), new Guid("30d0d56f-0050-414a-b6da-8dc810f974e4") },
                    { new Guid("0fe5c450-9e15-4ef9-846e-88e2604373a6"), new Guid("6dd76ba9-0b62-49bd-8abb-f8f803013c46"), new Guid("30d0d56f-0050-414a-b6da-8dc810f974e4") },
                    { new Guid("8264c1c2-e917-4f2a-8ab0-7a498d777061"), new Guid("484426b9-677b-470b-b6b6-95c65b4efa32"), new Guid("2e4811ba-4642-4fe6-81fe-74c630179ac0") },
                    { new Guid("f020bb52-e8b1-4a26-8ff5-4492fda5ea38"), new Guid("6a38147d-92e0-43b8-8006-46649f9f6661"), new Guid("e89e58ea-0e90-497a-af2e-b034a4057332") },
                    { new Guid("0de6a4fd-4a66-4e61-a38b-69d2e431f003"), new Guid("484426b9-677b-470b-b6b6-95c65b4efa32"), new Guid("e89e58ea-0e90-497a-af2e-b034a4057332") },
                    { new Guid("055c34da-6528-4795-bfe3-9431bd7a46f5"), new Guid("6a38147d-92e0-43b8-8006-46649f9f6661"), new Guid("2e4811ba-4642-4fe6-81fe-74c630179ac0") }
                });

            migrationBuilder.InsertData(
                table: "OwnerStatuses",
                columns: new[] { "IdOwnerStatus", "IdCardOwner", "IdSocialStatus" },
                values: new object[,]
                {
                    { new Guid("432ac8d8-7005-414c-a99e-d9856374eb77"), new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81"), new Guid("04fadf24-1488-4197-9ae6-a8737ffe8337") },
                    { new Guid("bc5dce62-0a49-40bf-84e1-c0311563b3c3"), new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a"), new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4") },
                    { new Guid("3d39c7b1-267a-4408-b2a9-d6ec991379fd"), new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7"), new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431") },
                    { new Guid("04d4822c-41fe-43e0-bddb-ea467f25d629"), new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99"), new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431") },
                    { new Guid("3603c9b7-5114-49d5-9404-ea82cd7ccd8c"), new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605"), new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4") }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "IdCard", "Balance", "IdAccount" },
                values: new object[,]
                {
                    { new Guid("f23feeee-f76a-4d42-8aea-b415c84b33bf"), 100m, new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438") },
                    { new Guid("08d12db6-f707-4735-b612-66f94eaa6487"), 30m, new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438") },
                    { new Guid("0081aec8-f88f-4b8e-976c-b6d121b3117e"), 50m, new Guid("ec38f0a8-be2b-4f91-9af0-47ab5d1769c3") },
                    { new Guid("3daf872c-6883-4e46-b63a-c95216945ad5"), 90m, new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca") },
                    { new Guid("02f10620-caf8-413b-bb75-a77a51f70bde"), 20m, new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca") },
                    { new Guid("92c2423a-4820-4331-aa13-c3d8b3b735b8"), 40m, new Guid("8c961fbe-9316-41b0-913c-6fed6977d479") },
                    { new Guid("7b17c592-e5ed-4d39-8380-f72572c667eb"), 80m, new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6") },
                    { new Guid("abae553f-c457-4ad8-bc22-3eb0f8288f6e"), 10m, new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6") },
                    { new Guid("d89c3f65-808b-4a74-9efa-7e21ede465c6"), 70m, new Guid("93ad8e5c-cd32-4cd9-8944-224e76d6d24d") },
                    { new Guid("f3b534c8-422b-46b0-86ec-43823409dc65"), 60m, new Guid("e4150c2e-c74a-400b-9fee-48b09ef3e805") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankBranches",
                keyColumn: "IdBankBranch",
                keyValue: new Guid("055c34da-6528-4795-bfe3-9431bd7a46f5"));

            migrationBuilder.DeleteData(
                table: "BankBranches",
                keyColumn: "IdBankBranch",
                keyValue: new Guid("0de6a4fd-4a66-4e61-a38b-69d2e431f003"));

            migrationBuilder.DeleteData(
                table: "BankBranches",
                keyColumn: "IdBankBranch",
                keyValue: new Guid("0fe5c450-9e15-4ef9-846e-88e2604373a6"));

            migrationBuilder.DeleteData(
                table: "BankBranches",
                keyColumn: "IdBankBranch",
                keyValue: new Guid("21a121e9-0080-46e3-8f6a-991759ad5cce"));

            migrationBuilder.DeleteData(
                table: "BankBranches",
                keyColumn: "IdBankBranch",
                keyValue: new Guid("3d3296ce-721f-4163-a301-59ec00c7f072"));

            migrationBuilder.DeleteData(
                table: "BankBranches",
                keyColumn: "IdBankBranch",
                keyValue: new Guid("46c14374-6f18-483c-8e87-bafb41bf589f"));

            migrationBuilder.DeleteData(
                table: "BankBranches",
                keyColumn: "IdBankBranch",
                keyValue: new Guid("8264c1c2-e917-4f2a-8ab0-7a498d777061"));

            migrationBuilder.DeleteData(
                table: "BankBranches",
                keyColumn: "IdBankBranch",
                keyValue: new Guid("e2fe6e32-ee54-4d60-9047-a413022a61fd"));

            migrationBuilder.DeleteData(
                table: "BankBranches",
                keyColumn: "IdBankBranch",
                keyValue: new Guid("f020bb52-e8b1-4a26-8ff5-4492fda5ea38"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("0081aec8-f88f-4b8e-976c-b6d121b3117e"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("02f10620-caf8-413b-bb75-a77a51f70bde"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("08d12db6-f707-4735-b612-66f94eaa6487"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("3daf872c-6883-4e46-b63a-c95216945ad5"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("7b17c592-e5ed-4d39-8380-f72572c667eb"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("92c2423a-4820-4331-aa13-c3d8b3b735b8"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("abae553f-c457-4ad8-bc22-3eb0f8288f6e"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("d89c3f65-808b-4a74-9efa-7e21ede465c6"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("f23feeee-f76a-4d42-8aea-b415c84b33bf"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "IdCard",
                keyValue: new Guid("f3b534c8-422b-46b0-86ec-43823409dc65"));

            migrationBuilder.DeleteData(
                table: "OwnerStatuses",
                keyColumn: "IdOwnerStatus",
                keyValue: new Guid("04d4822c-41fe-43e0-bddb-ea467f25d629"));

            migrationBuilder.DeleteData(
                table: "OwnerStatuses",
                keyColumn: "IdOwnerStatus",
                keyValue: new Guid("3603c9b7-5114-49d5-9404-ea82cd7ccd8c"));

            migrationBuilder.DeleteData(
                table: "OwnerStatuses",
                keyColumn: "IdOwnerStatus",
                keyValue: new Guid("3d39c7b1-267a-4408-b2a9-d6ec991379fd"));

            migrationBuilder.DeleteData(
                table: "OwnerStatuses",
                keyColumn: "IdOwnerStatus",
                keyValue: new Guid("432ac8d8-7005-414c-a99e-d9856374eb77"));

            migrationBuilder.DeleteData(
                table: "OwnerStatuses",
                keyColumn: "IdOwnerStatus",
                keyValue: new Guid("bc5dce62-0a49-40bf-84e1-c0311563b3c3"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "IdAccount",
                keyValue: new Guid("8c961fbe-9316-41b0-913c-6fed6977d479"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "IdAccount",
                keyValue: new Guid("93ad8e5c-cd32-4cd9-8944-224e76d6d24d"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "IdAccount",
                keyValue: new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "IdAccount",
                keyValue: new Guid("e4150c2e-c74a-400b-9fee-48b09ef3e805"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "IdAccount",
                keyValue: new Guid("ec38f0a8-be2b-4f91-9af0-47ab5d1769c3"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "IdAccount",
                keyValue: new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "IdAccount",
                keyValue: new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca"));

            migrationBuilder.DeleteData(
                table: "SocialStatuses",
                keyColumn: "IdSocialStatus",
                keyValue: new Guid("04fadf24-1488-4197-9ae6-a8737ffe8337"));

            migrationBuilder.DeleteData(
                table: "SocialStatuses",
                keyColumn: "IdSocialStatus",
                keyValue: new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4"));

            migrationBuilder.DeleteData(
                table: "SocialStatuses",
                keyColumn: "IdSocialStatus",
                keyValue: new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431"));

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "IdTown",
                keyValue: new Guid("2e4811ba-4642-4fe6-81fe-74c630179ac0"));

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "IdTown",
                keyValue: new Guid("30d0d56f-0050-414a-b6da-8dc810f974e4"));

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "IdTown",
                keyValue: new Guid("76fc6ed2-cb47-46c1-bd18-eb4ae0990bd3"));

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "IdTown",
                keyValue: new Guid("dd73f9af-e3c3-4ac3-b1c7-eea6cc3ae970"));

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "IdTown",
                keyValue: new Guid("e89e58ea-0e90-497a-af2e-b034a4057332"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "IdBank",
                keyValue: new Guid("3d564a3e-67b8-42f6-a262-a29f7059a930"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "IdBank",
                keyValue: new Guid("484426b9-677b-470b-b6b6-95c65b4efa32"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "IdBank",
                keyValue: new Guid("6a38147d-92e0-43b8-8006-46649f9f6661"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "IdBank",
                keyValue: new Guid("6dd76ba9-0b62-49bd-8abb-f8f803013c46"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "IdBank",
                keyValue: new Guid("ab08b7ab-7b08-49b4-997d-f556d87bca73"));

            migrationBuilder.DeleteData(
                table: "CardOwners",
                keyColumn: "IdCardOwner",
                keyValue: new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99"));

            migrationBuilder.DeleteData(
                table: "CardOwners",
                keyColumn: "IdCardOwner",
                keyValue: new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a"));

            migrationBuilder.DeleteData(
                table: "CardOwners",
                keyColumn: "IdCardOwner",
                keyValue: new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81"));

            migrationBuilder.DeleteData(
                table: "CardOwners",
                keyColumn: "IdCardOwner",
                keyValue: new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7"));

            migrationBuilder.DeleteData(
                table: "CardOwners",
                keyColumn: "IdCardOwner",
                keyValue: new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605"));
        }
    }
}
