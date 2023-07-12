using Core.BusinessObject;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages.Post
{
    public class DetailModel : PageModel
    {
       private readonly IPostRepository _postRepository;
        public DetailModel(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
       public string Title { get; set; }
       public string Description { get; set; }
        public string Content { get; set; }
        public IActionResult OnGet(int id)
        {
           POST post = _postRepository.GetById(id);
            Title = post.Title;

            Description = post.Description;
            Content = post.Content;

           return Page();
        }
    }
}
