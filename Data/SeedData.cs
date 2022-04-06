using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cheffie.Models;

namespace Cheffie.Data
{

    public class SeedData
    {
        public class DbInitializer
        {
            private readonly CheffieContext context;
            public DbInitializer(CheffieContext context)
            {
                this.context = context;
            }


            public void Initialize()
            {
                // context.Database.EnsureCreated();

                // Look for any students.
                if (context.Cook.Any())
                {
                    return;   // DB has been seeded
                }

                else
                {


                    var cooks = new Cook[]
                {
             new Cook{Name="Иван Иванов",Email="testing@test.com", Skill="Начинаещ", DOB=DateTime.Parse("2000-05-01"), FilePath="file1.jpg"},
             new Cook{Name="Петко Александров",Email="zdr@gmail.com", Skill="Напреднал", DOB=DateTime.Parse("1999-08-09"), FilePath="file2.jpg"},
             new Cook{Name="Мая Александрова",Email="ko@abv.bg", Skill="Шеф", DOB=DateTime.Parse("2003-05-06"), FilePath="file3.jpg"}

                };
                    foreach (Cook s in cooks)
                    {
                        context.Cook.Add(s);
                    }
                    context.SaveChanges();

                    var posts = new Post[]
                    {
            new Post{
                CookId=cooks.Single(i => i.Name=="Иван Иванов").CookId,
                Title="Две сестри", 
                Content="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of" +
                " classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a" +
                " Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin " +
                "words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical" +
                " literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of" +
                " de Finibus Bonorum et Malorum(The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a" +
                " treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, " +
                "Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.",
                PostDate=DateTime.Parse("2000-05-01")},

            new Post{CookId=cooks.Single(i => i.Name=="Петко Александров").CookId,
                Title="Чужденецът",
                Content="The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",PostDate=DateTime.Parse("2000-05-01") },
            
             new Post{CookId=cooks.Single(i => i.Name=="Петко Александров").CookId, 
                 Title="Суша", 
                 Content="The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.", PostDate=DateTime.Parse("2000-05-01")}

                    };
                    foreach (Post c in posts)
                    {
                        context.Post.Add(c);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
