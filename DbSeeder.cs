using KaryeramAPI.Data;
using KaryeramAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KaryeramAPI
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.Locations.Any())
            {
                context.Locations.AddRange(
                    new Location { Id = 1, Name = "Ağdam" },
                    new Location { Id = 2, Name = "Ağdaş" },
                    new Location { Id = 3, Name = "Ağcəbədi" },
                    new Location { Id = 4, Name = "Ağstafa" },
                    new Location { Id = 5, Name = "Ağsu" },
                    new Location { Id = 6, Name = "Astara" },
                    new Location { Id = 7, Name = "Ağdərə" },
                    new Location { Id = 8, Name = "Babək" },
                    new Location { Id = 9, Name = "Bakı" },
                    new Location { Id = 10, Name = "Balakən" },
                    new Location { Id = 11, Name = "Bərdə" },
                    new Location { Id = 12, Name = "Beyləqan" },
                    new Location { Id = 13, Name = "Biləsuvar" },
                    new Location { Id = 14, Name = "Daşkəsən" },
                    new Location { Id = 15, Name = "Füzuli" },
                    new Location { Id = 16, Name = "Gədəbəy" },
                    new Location { Id = 17, Name = "Gəncə" },
                    new Location { Id = 18, Name = "Goranboy" },
                    new Location { Id = 19, Name = "Göyçay" },
                    new Location { Id = 20, Name = "Göygol" },
                    new Location { Id = 21, Name = "Hacıqabul" },
                    new Location { Id = 22, Name = "İmişli" },
                    new Location { Id = 23, Name = "İsmayıllı" },
                    new Location { Id = 24, Name = "Cəbrayıl" },
                    new Location { Id = 25, Name = "Culfa" },
                    new Location { Id = 26, Name = "Kəlbəcər" },
                    new Location { Id = 27, Name = "Xaçmaz" },
                    new Location { Id = 28, Name = "Xankəndi" },
                    new Location { Id = 29, Name = "Xocavənd" },
                    new Location { Id = 30, Name = "Xırdalan" },
                    new Location { Id = 31, Name = "Kürdəmir" },
                    new Location { Id = 32, Name = "Lənkəran" },
                    new Location { Id = 33, Name = "Lerik" },
                    new Location { Id = 34, Name = "Masallı" },
                    new Location { Id = 35, Name = "Mingəçevir" },
                    new Location { Id = 36, Name = "Naxçıvan" },
                    new Location { Id = 37, Name = "Naftalan" },
                    new Location { Id = 38, Name = "Neftçala" },
                    new Location { Id = 39, Name = "Oğuz" },
                    new Location { Id = 40, Name = "Ordubad" },
                    new Location { Id = 41, Name = "Qəbələ" },
                    new Location { Id = 42, Name = "Qax" },
                    new Location { Id = 43, Name = "Qazax" },
                    new Location { Id = 44, Name = "Quba" },
                    new Location { Id = 45, Name = "Qubadlı" },
                    new Location { Id = 46, Name = "Qusar" },
                    new Location { Id = 47, Name = "Saatlı" },
                    new Location { Id = 48, Name = "Sabirabad" },
                    new Location { Id = 49, Name = "Şabran" },
                    new Location { Id = 50, Name = "Şahbuz" },
                    new Location { Id = 51, Name = "Şəki" },
                    new Location { Id = 52, Name = "Şamaxı" },
                    new Location { Id = 53, Name = "Şəmkir" },
                    new Location { Id = 54, Name = "Şərur" },
                    new Location { Id = 55, Name = "Şirvan" },
                    new Location { Id = 56, Name = "Siyəzən" },
                    new Location { Id = 57, Name = "Şuşa" },
                    new Location { Id = 58, Name = "Sumqayıt" },
                    new Location { Id = 59, Name = "Tərtər" },
                    new Location { Id = 60, Name = "Tovuz" },
                    new Location { Id = 61, Name = "Ucar" },
                    new Location { Id = 62, Name = "Yardımlı" },
                    new Location { Id = 63, Name = "Yevlax" },
                    new Location { Id = 64, Name = "Zaqatala" },
                    new Location { Id = 65, Name = "Zərdab" },
                    new Location { Id = 66, Name = "Zəngilan" },
                    new Location { Id = 67, Name = "Digər" }
                );
            }

            if (!context.JobCategories.Any())
            {
                context.JobCategories.AddRange(
                    new JobCategory { Id = 1, Name = "Memarlıq və Tikinti" },
                    new JobCategory { Id = 2, Name = "Administrasiya və İdarəetmə" },
                    new JobCategory { Id = 3, Name = "Dizayn" },
                    new JobCategory { Id = 4, Name = "İnformasiya Texnologiyaları" },
                    new JobCategory { Id = 5, Name = "Tibb və Əczaçılıq" },
                    new JobCategory { Id = 6, Name = "Marketinq və Reklam" },
                    new JobCategory { Id = 7, Name = "Təhsil və Elm" },
                    new JobCategory { Id = 8, Name = "Xidmət Sektoru" },
                    new JobCategory { Id = 9, Name = "Satış və Daşınmaz Əmlak" },
                    new JobCategory { Id = 10, Name = "Sənaye və Kənd Təsərrüfatı" },
                    new JobCategory { Id = 11, Name = "İstehsal və Servis" },
                    new JobCategory { Id = 12, Name = "Media və Kreativ Sektor " },
                    new JobCategory { Id = 13, Name = "Maliyyə və İqtisadiyyat" },
                    new JobCategory { Id = 14, Name = "Hüquq" },
                    new JobCategory { Id = 15, Name = "Müxtəlif / Digər" }
                );
            }

            if (!context.JobSubcategories.Any())
            {
                context.JobSubcategories.AddRange(
                     new JobSubcategory { Id = 1, Name = "Memar", JobCategoryId = 1 },
                    new JobSubcategory { Id = 2, Name = "Mühəndis, konstruktor", JobCategoryId = 1 },
                    new JobSubcategory { Id = 3, Name = "Prorab", JobCategoryId = 1 },
                    new JobSubcategory { Id = 4, Name = "Briqadir", JobCategoryId = 1 },
                    new JobSubcategory { Id = 5, Name = "Usta", JobCategoryId = 1 },
                    new JobSubcategory { Id = 6, Name = "Tikinti ixtisasları üzrə fəhlə", JobCategoryId = 1 },
                    new JobSubcategory { Id = 7, Name = "Elektrik", JobCategoryId = 1 },
                    new JobSubcategory { Id = 8, Name = "Santexnik", JobCategoryId = 1 },
                    new JobSubcategory { Id = 9, Name = "Digər inşaat sahələri", JobCategoryId = 1 },

                    // Administrasiya və İdarəetmə (Id = 2)
                    new JobSubcategory { Id = 10, Name = "Administrator", JobCategoryId = 2 },
                    new JobSubcategory { Id = 11, Name = "Asistent", JobCategoryId = 2 },
                    new JobSubcategory { Id = 12, Name = "Menecer", JobCategoryId = 2 },
                    new JobSubcategory { Id = 13, Name = "Ofis meneceri", JobCategoryId = 2 },
                    new JobSubcategory { Id = 14, Name = "Katibə / Referent", JobCategoryId = 2 },
                    new JobSubcategory { Id = 15, Name = "Resepsiyon", JobCategoryId = 2 },
                    new JobSubcategory { Id = 16, Name = "Heyətin idarəolunması", JobCategoryId = 2 },
                    new JobSubcategory { Id = 17, Name = "Digər idarəçilik", JobCategoryId = 2 },

                    // Dizayn (Id = 3)
                    new JobSubcategory { Id = 18, Name = "İnteryer dizayneri", JobCategoryId = 3 },
                    new JobSubcategory { Id = 19, Name = "Geyim dizayneri", JobCategoryId = 3 },
                    new JobSubcategory { Id = 20, Name = "Grafik dizayner", JobCategoryId = 3 },
                    new JobSubcategory { Id = 21, Name = "Rəssam", JobCategoryId = 3 },
                    new JobSubcategory { Id = 22, Name = "Digər qrafika və rəsm", JobCategoryId = 3 },

                    // İnformasiya Texnologiyaları (Id = 4)
                    new JobSubcategory { Id = 23, Name = "IT mütəxəssis / məsləhətçi", JobCategoryId = 4 },
                    new JobSubcategory { Id = 24, Name = "Veb-dizayner", JobCategoryId = 4 },
                    new JobSubcategory { Id = 25, Name = "Veb-programçı", JobCategoryId = 4 },
                    new JobSubcategory { Id = 26, Name = "Proqramçı / Proqramlaşdırma", JobCategoryId = 4 },
                    new JobSubcategory { Id = 27, Name = "Məlumat bazalarının idarə edilməsi", JobCategoryId = 4 },
                    new JobSubcategory { Id = 28, Name = "Sistem administratoru", JobCategoryId = 4 },
                    new JobSubcategory { Id = 29, Name = "Texniki avadanlıq mütəxəssisi", JobCategoryId = 4 },
                    new JobSubcategory { Id = 30, Name = "IT layihə meneceri", JobCategoryId = 4 },
                    new JobSubcategory { Id = 31, Name = "Digər IT sahələri", JobCategoryId = 4 },

                    // Tibb və Əczaçılıq (Id = 5)
                    new JobSubcategory { Id = 32, Name = "Həkim", JobCategoryId = 5 },
                    new JobSubcategory { Id = 33, Name = "Tibb bacısı / Sanitar", JobCategoryId = 5 },
                    new JobSubcategory { Id = 34, Name = "Tibbi personal", JobCategoryId = 5 },
                    new JobSubcategory { Id = 35, Name = "Tibbi nümayəndə", JobCategoryId = 5 },
                    new JobSubcategory { Id = 36, Name = "Əczaçı", JobCategoryId = 5 },
                    new JobSubcategory { Id = 37, Name = "Digər tibb", JobCategoryId = 5 },

                    // Marketinq və Reklam (Id = 6)
                    new JobSubcategory { Id = 38, Name = "Kopirayter", JobCategoryId = 6 },
                    new JobSubcategory { Id = 39, Name = "Marketoloq", JobCategoryId = 6 },
                    new JobSubcategory { Id = 40, Name = "Reklam / PR", JobCategoryId = 6 },
                    new JobSubcategory { Id = 41, Name = "İctimaiyyətlə əlaqələr", JobCategoryId = 6 },
                    new JobSubcategory { Id = 42, Name = "Promouter", JobCategoryId = 6 },
                    new JobSubcategory { Id = 43, Name = "Digər bazar fəaliyyəti", JobCategoryId = 6 },

                    // Təhsil və Elm (Id = 7)
                    new JobSubcategory { Id = 44, Name = "Təlimatçı", JobCategoryId = 7 },
                    new JobSubcategory { Id = 45, Name = "Müəllim", JobCategoryId = 7 },
                    new JobSubcategory { Id = 46, Name = "Repetitor", JobCategoryId = 7 },
                    new JobSubcategory { Id = 47, Name = "Xüsusi təhsil / təlim", JobCategoryId = 7 },
                    new JobSubcategory { Id = 48, Name = "Digər tədris", JobCategoryId = 7 },

                    // Xidmət Sektoru (Id = 8)
                    new JobSubcategory { Id = 49, Name = "Sürücü", JobCategoryId = 8 },
                    new JobSubcategory { Id = 50, Name = "Kuryer", JobCategoryId = 8 },
                    new JobSubcategory { Id = 51, Name = "Dayə", JobCategoryId = 8 },
                    new JobSubcategory { Id = 52, Name = "Ofisiant", JobCategoryId = 8 },
                    new JobSubcategory { Id = 53, Name = "Mühafizə / Təhlükəsizlik", JobCategoryId = 8 },
                    new JobSubcategory { Id = 54, Name = "Bərbər / kosmetoloq", JobCategoryId = 8 },
                    new JobSubcategory { Id = 55, Name = "Tərcüməçi", JobCategoryId = 8 },
                    new JobSubcategory { Id = 56, Name = "Aşpaz", JobCategoryId = 8 },
                    new JobSubcategory { Id = 57, Name = "Qabyuyan", JobCategoryId = 8 },
                    new JobSubcategory { Id = 58, Name = "Fəhlə", JobCategoryId = 8 },
                    new JobSubcategory { Id = 59, Name = "Restoran və kafelər", JobCategoryId = 8 },
                    new JobSubcategory { Id = 60, Name = "Turizm və mehmanxana", JobCategoryId = 8 },
                    new JobSubcategory { Id = 61, Name = "Xadimə / təmizlik", JobCategoryId = 8 },
                    new JobSubcategory { Id = 62, Name = "Digər xidmət sahələri", JobCategoryId = 8 },

                    // Satış və Daşınmaz Əmlak (Id = 9)
                    new JobSubcategory { Id = 63, Name = "Daşınmaz əmlak agenti / makler", JobCategoryId = 9 },
                    new JobSubcategory { Id = 64, Name = "Satış üzrə mütəxəssis", JobCategoryId = 9 },
                    new JobSubcategory { Id = 65, Name = "Ekspeditor", JobCategoryId = 9 },
                    new JobSubcategory { Id = 66, Name = "Merçandayzer", JobCategoryId = 9 },
                    new JobSubcategory { Id = 67, Name = "Satıcı", JobCategoryId = 9 },
                    new JobSubcategory { Id = 68, Name = "Anbardar", JobCategoryId = 9 },
                    new JobSubcategory { Id = 69, Name = "Digər satış sahələri", JobCategoryId = 9 },

                    // Sənaye və Kənd Təsərrüfatı (Id = 10)
                    new JobSubcategory { Id = 70, Name = "Avtomatlaşdırılmış layihələndirmə", JobCategoryId = 10 },
                    new JobSubcategory { Id = 71, Name = "Geologiya və ətraf mühit mütəxəssisi", JobCategoryId = 10 },
                    new JobSubcategory { Id = 72, Name = "Mühəndis", JobCategoryId = 10 },
                    new JobSubcategory { Id = 73, Name = "Kənd təsərrüfatı işçisi", JobCategoryId = 10 },
                    new JobSubcategory { Id = 74, Name = "Tikinti sahələri", JobCategoryId = 10 },
                    new JobSubcategory { Id = 75, Name = "Digər sənaye sahələri", JobCategoryId = 10 },

                    // İstehsal və Servis (Id = 11)
                    new JobSubcategory { Id = 76, Name = "Avtoslesar", JobCategoryId = 11 },
                    new JobSubcategory { Id = 77, Name = "Avtoelektrik", JobCategoryId = 11 },
                    new JobSubcategory { Id = 78, Name = "Mühəndis / texnoloq", JobCategoryId = 11 },
                    new JobSubcategory { Id = 79, Name = "İşçi / mexanik", JobCategoryId = 11 },
                    new JobSubcategory { Id = 80, Name = "Toxucu / biçici / dərzi", JobCategoryId = 11 },
                    new JobSubcategory { Id = 81, Name = "Digər istehsal sahələri", JobCategoryId = 11 },

                    // Media və Kreativ Sektor (Id = 12)
                    new JobSubcategory { Id = 82, Name = "Video operator", JobCategoryId = 12 },
                    new JobSubcategory { Id = 83, Name = "Fotoqraf", JobCategoryId = 12 },
                    new JobSubcategory { Id = 84, Name = "Freelancer", JobCategoryId = 12 },
                    new JobSubcategory { Id = 85, Name = "Jurnalist", JobCategoryId = 12 },
                    new JobSubcategory { Id = 86, Name = "Telefonda operator", JobCategoryId = 12 },
                    new JobSubcategory { Id = 87, Name = "Poliqrafiya / nəşriyyat", JobCategoryId = 12 },
                    new JobSubcategory { Id = 88, Name = "Oyun / model / şou-biznes", JobCategoryId = 12 },
                    new JobSubcategory { Id = 89, Name = "Digər peşələr", JobCategoryId = 12 },

                    // Maliyyə və İqtisadiyyat (Id = 13)
                    new JobSubcategory { Id = 90, Name = "Auditor", JobCategoryId = 13 },
                    new JobSubcategory { Id = 91, Name = "Bank xidməti", JobCategoryId = 13 },
                    new JobSubcategory { Id = 92, Name = "Mühasib", JobCategoryId = 13 },
                    new JobSubcategory { Id = 93, Name = "Kassir", JobCategoryId = 13 },
                    new JobSubcategory { Id = 94, Name = "Kredit mütəxəssisi", JobCategoryId = 13 },
                    new JobSubcategory { Id = 95, Name = "Sığorta mütəxəssisi", JobCategoryId = 13 },
                    new JobSubcategory { Id = 96, Name = "Maliyyə analitiki", JobCategoryId = 13 },
                    new JobSubcategory { Id = 97, Name = "İqtisadçı", JobCategoryId = 13 },
                    new JobSubcategory { Id = 98, Name = "Digər maliyyə sahələri", JobCategoryId = 13 },

                    // Hüquq (Id = 14)
                    new JobSubcategory { Id = 99, Name = "Vəkil", JobCategoryId = 14 },
                    new JobSubcategory { Id = 100, Name = "Notarius", JobCategoryId = 14 },
                    new JobSubcategory { Id = 101, Name = "Hüquqşünas", JobCategoryId = 14 },
                    new JobSubcategory { Id = 102, Name = "Cinayət hüququ üzrə mütəxəssis", JobCategoryId = 14 },
                    new JobSubcategory { Id = 103, Name = "Digər hüquq sahələri", JobCategoryId = 14 },

                    // Müxtəlif / Digər (Id = 15)
                    new JobSubcategory { Id = 104, Name = "Tələbələr üçün işlər", JobCategoryId = 15 },
                    new JobSubcategory { Id = 105, Name = "Freelancer", JobCategoryId = 15 },
                    new JobSubcategory { Id = 106, Name = "Digər peşələr", JobCategoryId = 15 }
                );
            }


            await context.SaveChangesAsync();
        }
    }
}
