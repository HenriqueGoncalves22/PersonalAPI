﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 167, 56, 235, 8, 246, 13, 41, 20, 26, 251, 137, 92, 171, 166, 251, 183, 222, 23, 178, 38, 155, 169, 91, 99, 255, 80, 4, 12, 143, 17, 222, 120, 134, 113, 117, 199, 68, 64, 22, 73, 6, 141, 128, 163, 227, 67, 48, 77, 139, 101, 176, 159, 192, 101, 130, 136, 184, 213, 195, 67, 18, 145, 225, 147 }, new byte[] { 148, 22, 247, 104, 111, 138, 108, 137, 119, 227, 83, 39, 220, 210, 200, 107, 12, 40, 231, 182, 147, 126, 48, 98, 168, 191, 236, 91, 223, 168, 236, 244, 74, 151, 197, 182, 0, 104, 52, 111, 14, 3, 70, 209, 159, 105, 184, 213, 131, 207, 211, 221, 45, 72, 220, 81, 130, 45, 85, 238, 110, 97, 9, 143, 6, 70, 219, 127, 32, 45, 160, 30, 39, 133, 146, 197, 122, 215, 101, 245, 250, 102, 68, 233, 238, 198, 54, 144, 185, 230, 118, 52, 210, 177, 138, 142, 239, 147, 154, 54, 128, 124, 104, 210, 136, 94, 129, 92, 229, 178, 185, 167, 17, 195, 215, 29, 151, 11, 210, 179, 38, 237, 72, 158, 101, 28, 111, 101 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 70, 65, 222, 201, 180, 48, 91, 244, 49, 235, 141, 83, 185, 100, 31, 34, 55, 88, 84, 105, 8, 136, 250, 72, 10, 151, 3, 27, 189, 152, 43, 230, 242, 95, 231, 207, 178, 162, 21, 80, 20, 2, 83, 121, 119, 158, 15, 217, 239, 250, 5, 136, 57, 224, 54, 206, 246, 90, 216, 84, 107, 1, 55, 199 }, new byte[] { 32, 62, 64, 103, 147, 235, 241, 186, 26, 231, 237, 92, 247, 248, 111, 182, 139, 220, 167, 170, 165, 91, 16, 38, 91, 67, 75, 74, 237, 128, 104, 230, 179, 217, 2, 244, 85, 81, 180, 173, 97, 19, 105, 197, 4, 50, 41, 113, 33, 146, 117, 40, 196, 215, 228, 201, 37, 75, 74, 53, 208, 34, 57, 194, 71, 181, 78, 229, 178, 18, 168, 1, 129, 172, 68, 87, 234, 89, 180, 154, 132, 176, 24, 38, 98, 227, 161, 100, 131, 247, 153, 139, 213, 234, 36, 187, 138, 164, 103, 69, 24, 189, 44, 120, 205, 38, 94, 8, 126, 59, 75, 9, 113, 235, 192, 76, 236, 78, 133, 106, 130, 27, 47, 172, 129, 149, 89, 251 } });
        }
    }
}
