using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZOPractce.ConsoleApp.EFCorePractices
{
    public class EFCorePractice
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();

        public void Read()
        {
            var list = _appDbContext.TableBlog.ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item.id);
                Console.WriteLine(item.title);
                Console.WriteLine(item.author);
                Console.WriteLine(item.content);
            }
        }

        public void Edit(string Id)
        {
            var item= _appDbContext.TableBlog.FirstOrDefault(x => x.id==Id);
            if(item is null)
            {
                Console.WriteLine("Not data found");
                return;
            }

            Console.WriteLine(item.id);
            Console.WriteLine(item.title);
            Console.WriteLine(item.author);
            Console.WriteLine(item.content);

        }

        public void create(string title,string author,string content)
        {
            var blog = new Tbl_Blog()
            {
                id = Guid.NewGuid().ToString(),
                title = title,
                author = author,
                content = content

            };

            _appDbContext.TableBlog.Add(blog);
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);

        }

        public void Update(string id, string title, string author, string content)
        {
            var item = _appDbContext.TableBlog.AsNoTracking().FirstOrDefault(x => x.id == id);
            if (item is null)

            {
                Console.WriteLine("No Data found.");
                return;
            }
            item.title = title;
            item.author = author;
            item.content = content;

            _appDbContext.Entry(item).State = EntityState.Modified;
            var result = _appDbContext.SaveChanges();

            string message = result > 0 ? "Updating Successful.." : "Updating Failed...";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            var item = _appDbContext.TableBlog.AsNoTracking().FirstOrDefault(x => x.id == id);
            if (item is null)
            {
                Console.WriteLine("Data not  found");
                return;

            }
            _appDbContext.Entry(item).State = EntityState.Deleted;
            var result = _appDbContext.SaveChanges();

            string message = result > 0 ? "Deleted Sucessfel!!!" : "Deleted Failed!!!";
            Console.WriteLine(message);


        }

    }
}


