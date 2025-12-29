using KutuphaneAPI.Models;

namespace KutuphaneAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any books.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            // Publishers
            var publishers = new Publisher[]
            {
                new Publisher{Name="Yapı Kredi Yayınları", Address="İstanbul"},
                new Publisher{Name="İletişim Yayınları", Address="İstanbul"},
                new Publisher{Name="Can Yayınları", Address="İstanbul"},
                new Publisher{Name="İş Bankası Kültür Yayınları", Address="İstanbul"},
                new Publisher{Name="Metis Yayınları", Address="İstanbul"}
            };
            context.Publishers.AddRange(publishers);
            context.SaveChanges();

            // Authors
            var authors = new Author[]
            {
                new Author{Name="Orhan Pamuk", Bio="Nobel ödüllü Türk yazar."},
                new Author{Name="Sabahattin Ali", Bio="Kürk Mantolu Madonna'nın yazarı."},
                new Author{Name="Yaşar Kemal", Bio="Çukurova'nın efsanevi yazarı."},
                new Author{Name="J.K. Rowling", Bio="Harry Potter serisinin yazarı."},
                new Author{Name="George Orwell", Bio="1984 ve Hayvan Çiftliği yazarı."},
                new Author{Name="J.R.R. Tolkien", Bio="Yüzüklerin Efendisi yazarı."}
            };
            context.Authors.AddRange(authors);
            context.SaveChanges();

            // Categories
            var categories = new Category[]
            {
                new Category{Name="Roman"},
                new Category{Name="Klasik"},
                new Category{Name="Bilim Kurgu"},
                new Category{Name="Fantastik"},
                new Category{Name="Tarih"},
                new Category{Name="Deneme"}
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            // Books
            var books = new Book[]
            {
                new Book
                {
                    Title="Kürk Mantolu Madonna", 
                    ISBN="9789753638029", 
                    PublishYear=1943, 
                    StockCount=5, 
                    Publisher=publishers[0], // YKY
                    Authors=new List<Author>{authors[1]}, // Sabahattin Ali
                    Categories=new List<Category>{categories[0], categories[1]} // Roman, Klasik
                },
                new Book
                {
                    Title="Benim Adım Kırmızı", 
                    ISBN="9789750800049", 
                    PublishYear=1998, 
                    StockCount=3, 
                    Publisher=publishers[0], // YKY (Usually)
                    Authors=new List<Author>{authors[0]}, // Orhan Pamuk
                    Categories=new List<Category>{categories[0], categories[4]} // Roman, Tarih
                },
                new Book
                {
                    Title="1984", 
                    ISBN="9789750718533", 
                    PublishYear=1949, 
                    StockCount=10, 
                    Publisher=publishers[2], // Can
                    Authors=new List<Author>{authors[4]}, // Orwell
                    Categories=new List<Category>{categories[0], categories[2]} // Roman, Bilim Kurgu
                },
                new Book
                {
                    Title="Harry Potter ve Felsefe Taşı", 
                    ISBN="9789753638000", 
                    PublishYear=1997, 
                    StockCount=7, 
                    Publisher=publishers[0], // YKY
                    Authors=new List<Author>{authors[3]}, // Rowling
                    Categories=new List<Category>{categories[0], categories[3]} // Roman, Fantastik
                },
                new Book
                {
                    Title="Yüzüklerin Efendisi: Yüzük Kardeşliği", 
                    ISBN="9789753423450", 
                    PublishYear=1954, 
                    StockCount=4, 
                    Publisher=publishers[4], // Metis
                    Authors=new List<Author>{authors[5]}, // Tolkien
                    Categories=new List<Category>{categories[3], categories[1]} // Fantastik, Klasik
                },
                 new Book
                {
                    Title="İnce Memed 1", 
                    ISBN="9789750807080", 
                    PublishYear=1955, 
                    StockCount=6, 
                    Publisher=publishers[0], // YKY
                    Authors=new List<Author>{authors[2]}, // Yaşar Kemal
                    Categories=new List<Category>{categories[0], categories[1]} // Roman, Klasik
                }
            };
            context.Books.AddRange(books);
            context.SaveChanges();

            // Members
            var members = new Member[]
            {
                new Member{Name="Ahmet Yılmaz", Email="ahmet@example.com", Phone="5551112233"},
                new Member{Name="Ayşe Demir", Email="ayse@example.com", Phone="5554445566"},
                new Member{Name="Mehmet Öz", Email="mehmet@example.com", Phone="5557778899"},
                new Member{Name="Zeynep Kaya", Email="zeynep@example.com", Phone="5550001122"}
            };
            context.Members.AddRange(members);
            context.SaveChanges();
        }
    }
}
