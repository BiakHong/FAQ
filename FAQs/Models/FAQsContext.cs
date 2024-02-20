using Microsoft.EntityFrameworkCore;

namespace FAQs.Models
{
    public class FAQsContext : DbContext
    {
        public FAQsContext(DbContextOptions<FAQsContext> options)
            : base(options)
        {

        }
        public DbSet<FAQ> FQs { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FAQ>().HasData(
                 new FAQ
                 {
                     FaqId = 1,
                     Question = "What is Bootstrap?",
                     Answer = "A CSS framework for creating responsive web apps for multiple screen sizes.",
                     CategoryId = "gen",
                     TopicId = "bst"

                 },
                new FAQ
                {
                    FaqId = 2,
                    Question = "When is C#?",
                    Answer = "A general purpose object oriented language that uses a concise, Java-like syntax.",
                    CategoryId = "gen",
                    TopicId = "c#"
                },
                new FAQ
                {
                    FaqId = 3,
                    Question = "What is JavaScript?",
                    Answer = "A general purposse scripting language that executes in a web browser.",
                    CategoryId = "gen",
                    TopicId = "js"
                },
                new FAQ
                {
                    FaqId = 4,
                    Question = "When was Bootstrap first released?",
                    Answer = "In 2011",
                    CategoryId = "hist",
                    TopicId = "bst"
                },
                new FAQ
                {
                    FaqId = 5,
                    Question = "When was C# first released?",
                    Answer = "In 2002",
                    CategoryId = "hist",
                    TopicId = "C#"
                },
                new FAQ
                {
                    FaqId = 6,
                    Question = "When was JavaScriptk released?",
                    Answer = "On December 4, 1995.",
                    CategoryId = "hist",
                    TopicId = "js"
                }
                );
            modelBuilder.Entity<Category>().HasData(
                               new Category { CategoryId = "gen", CategoryName = "General" },
                               new Category { CategoryId = "hist", CategoryName = "History" }
            );

            modelBuilder.Entity<Topic>().HasData(
                               new Topic { TopicId = "c#", TopicName = "C#" },
                               new Topic { TopicId = "js", TopicName = "JavaScript" },
                               new Topic { TopicId = "bst", TopicName = "BootStrap" }
                               );

        }
    }
}