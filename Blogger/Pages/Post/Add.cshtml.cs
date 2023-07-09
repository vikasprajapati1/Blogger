using Core.BusinessObject;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages.Post
{
    public class AddModel : PageModel
    {
        private readonly IPostRepository _postRepository;
        public AddModel(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            POST post = new POST();
            post.Title = "Title";
            post.Description = "Description";
            post.Content = "Contenttttt";

            _postRepository.Add(post);

        }
    }
}
