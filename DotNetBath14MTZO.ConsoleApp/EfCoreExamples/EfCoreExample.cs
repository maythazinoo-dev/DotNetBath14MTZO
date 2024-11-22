using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.ConsoleApp.EfCoreExamples
{
    public class EfCoreExample
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();

        public void Read()
        {
            var list = _appDbContext.TableBlog.ToList();
            foreach (var item in list)
            {
                Console.WriteLine("Blog Id..." + item.Id);
                Console.WriteLine("Blog Title..." + item.Title);
                Console.WriteLine("Blog Author..." + item.Author);
                Console.WriteLine("Blog Content..." + item.Content);
            }
        }

        public void Edit(string id)
        {
            //var item = appDbContext.TableBlog.Where(item => item.Id == id);
            var item = _appDbContext.TableBlog.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("Data not found!");
                return;
            }
            Console.WriteLine("Blog Id..." + item.Id);
            Console.WriteLine("Blog Title..." + item.Title);
            Console.WriteLine("Blog Author..." + item.Author);
            Console.WriteLine("Blog Content..." + item.Content);

        }

        public void Create(string title, string author, string content)
        {

            var blog = new TblBlog()
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Author = author,
                Content = content
            };

            _appDbContext.TableBlog.Add(blog);
            var result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        public void Update(string id, string title, string author, string content)
        {
            var item = _appDbContext.TableBlog.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (item is null)

            {
                Console.WriteLine("No Data found.");
                return;
            }
            item.Title = title;
            item.Author = author;
            item.Content = content;

            _appDbContext.Entry(item).State = EntityState.Modified;
            var result = _appDbContext.SaveChanges();

            string message = result > 0 ? "Updating Successful.." : "Updating Failed...";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            var item = _appDbContext.TableBlog.AsNoTracking().FirstOrDefault(x => x.Id == id);
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
