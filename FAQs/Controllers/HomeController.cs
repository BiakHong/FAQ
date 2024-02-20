using FAQs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace FAQs.Controllers
{
    public class HomeController : Controller
    {
        private FAQsContext context { get; set; }
        public HomeController(FAQsContext ctx)
        {
            context = ctx;
        }

        [Route("topic/{topic}/category/{category}")]
        [Route("topic/{topic}")]
        [Route("category/{category}")]
        [Route("/")]
        public IActionResult Index(string topic, string category)
        {
            //Selecting all FAQs from the database
            var faqs = context.FQs.Include(f => f.Category).Include(f => f.Topic).OrderBy(f => f.Question).ToList();

            //Selecting all topics from the database
            ViewBag.Topics = context.Topic.OrderBy(t => t.TopicName).ToList();
            ViewBag.Categories = context.Category.OrderBy(c => c.CategoryName).ToList();
            ViewBag.SelectedTopic = topic;

            if (!string.IsNullOrEmpty(topic))
            {
                faqs = faqs.Where(f => f.Topic.TopicId == topic).ToList();
            }

            if (!string.IsNullOrEmpty(category))
            {
                faqs = faqs.Where(f => f.Category.CategoryId == category).ToList();
            }


            return View(faqs);
        }

    }

}

