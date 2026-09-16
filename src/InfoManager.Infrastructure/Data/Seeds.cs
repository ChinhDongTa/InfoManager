using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Infrastructure.Data;

internal static class Seeds
{
    public static void SeedData(ModelBuilder builder)
    {
        builder.Entity<FamilyRelation>().HasData(
            new FamilyRelation { Id = "10d0bb42-d9c6-4c28-be58-e64e50a2a911", Name = "Ông cố nội" },
            new FamilyRelation { Id = "8f817c44-2b9f-4e75-8999-957b3c3e5d8f", Name = "Bà cố nội" },
            new FamilyRelation { Id = "e2b21928-c91c-4534-917b-41971c52bb51", Name = "Ông cố ngoại" },
            new FamilyRelation { Id = "ba609a13-4f83-4075-a78d-55c18e730190", Name = "Bà cố ngoại" },
            new FamilyRelation { Id = "52edc712-0f51-48bd-ab9d-17dd2bafa639", Name = "Ông nội" },
            new FamilyRelation { Id = "87655c00-f770-4af5-88ee-cdac045b97bd", Name = "Bà nội" },
            new FamilyRelation { Id = "7cd4de3d-6294-4e13-b9c5-fbad7a9ea174", Name = "Ông ngoại" },
            new FamilyRelation { Id = "40172842-82bb-4e4e-8403-b7bb5c91ecd4", Name = "Bà ngoại" },
            new FamilyRelation { Id = "23297e2b-78f1-42ad-97d3-ef1a1ff6b943", Name = "Cha" },
            new FamilyRelation { Id = "dad4eb62-9681-4011-9d36-4ac199f0c239", Name = "Mẹ" },
            new FamilyRelation { Id = "a14ec1c2-6563-4ec8-a022-7318ebd236f0", Name = "Con trai" },
            new FamilyRelation { Id = "506424e6-db25-48d9-9841-d4454dbb97ef", Name = "Con gái" }
        );
        builder.Entity<Category>().HasData(
            new Category { Id = "6c6bb70b-c45c-4a88-967a-b2e7584a2999", Name = "Chi tiêu hàng ngày" },
            new Category { Id = "69beb3c5-44e5-411c-95e2-acdae6ed6804", Name = "Mua sắm" },
            new Category { Id = "6ed08184-788e-4530-848f-ec53882140f5", Name = "Giải trí" },
            new Category { Id = "f68a4c51-fb49-493b-96c4-7c9f1c298235", Name = "Học tập" },

            new Category { Id = "a8fe7c3e-4fa7-4396-a74c-a179dfac9444", Name = "Sức khỏe" },
            new Category { Id = "4814d70b-6202-470b-99ac-778748c743a2", Name = "Đầu tư" },
            new Category { Id = "6e6f59f5-7f5a-496d-9dd9-e8582c86f30b", Name = "Bán hàng" },
            new Category { Id = "014af7c9-397d-48f4-96f3-b12d80d1a5e4", Name = "Lương" },
            new Category { Id = "3f22bd16-2e0a-4d2e-92d7-4442c27dfaa8", Name = "Hiếu hỉ" },
            new Category { Id = "92ea6071-2279-42a1-899e-ea287086be66", Name = "Nông nghiệp" },
            new Category { Id = "64154fed-88e8-4ecf-9404-abd1a1692228", Name = "Công nghệ thông tin" }
            );
    }
}

//public enum ExperienceCategory
//{
//    [Display(Name = "Nông nghiệp")]
//    Agriculture = 0,
//    [Display(Name = "Công nghệ thông tin")]
//    InformationTechnology = 2,
//    [Display(Name = "Học tập")]
//    Study = 3,
//    [Display(Name = "Du lịch")]
//    Travel = 4,
//    [Display(Name = "Ẩm thực")]
//    Culinary = 5,
//    [Display(Name = "Mua sắm")]
//    Shopping = 6,
//    [Display(Name = "Khác")]
//    Other = 99
//}