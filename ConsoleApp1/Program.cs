using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type in one of the following commands:");
            Console.WriteLine("AddBlogs - This will add urls to the Blog table");
            Console.WriteLine("ShowBlogs - This will display all the blogs in the Blogs table");
            Console.WriteLine("DeleteBlogs - This will delete all the blogs in the Blogs table");
            prompt();
        }

        static void prompt()
        {
            Console.Write("Please enter a command: ");
            string command = Console.ReadLine();

            if (command == "AddBlogs")
                addBlogValues();
            else if (command == "ShowBlogs")
                showBlogValues();
            else if (command == "DeleteBlogs")
                deleteBlogValues();

        }


        static void addBlogValues()
        {
            using (var db = new ModelContext())
            {
                db.Blogs.Add(new Blog { Url = "https://google.com" });
                db.Blogs.Add(new Blog { Url = "https://yahoo.com" });
                db.Blogs.Add(new Blog { Url = "https://bing.com" });
                db.Blogs.Add(new Blog { Url = "https://myspace.com" });
                db.Blogs.Add(new Blog { Url = "https://shazam.com" });

                var count = db.SaveChanges();

                db.Dispose();

                Console.WriteLine("{0} records have been added to the database.", count.ToString());
            }

            prompt();
        }

        static void deleteBlogValues()
        {
            using (var db = new ModelContext())
            {
                var allrecords = from x in db.Blogs select x;
                db.Blogs.RemoveRange(allrecords);

                var count = db.SaveChanges();

                db.Dispose();

                Console.WriteLine("{0} records have been removed to the database.", count.ToString());
            }

            prompt();
        }

        static void showBlogValues()
        {
            using (var db = new ModelContext())
            {

                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }

                var count = db.Blogs.Count();
                db.Dispose();

                Console.WriteLine("{0} records have been displayed.", count.ToString());
            }

            prompt();
        }
    }
}
