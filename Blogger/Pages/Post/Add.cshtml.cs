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
        public void OnPost(IFormCollection collection)
        {
            POST post = new POST();
            post.Title = collection["title"].ToString();
            post.Description = collection["description"].ToString();
            post.Content = collection["content"].ToString();
            post.CreatedBy = "System";
            post.ModifiedBy = "System";
            post.CreatedOnUtc =DateTime.Now;
            post.CreatedIp = HttpContext.Connection.RemoteIpAddress?.ToString();
           

            _postRepository.Add(post);

        }
    }
}
