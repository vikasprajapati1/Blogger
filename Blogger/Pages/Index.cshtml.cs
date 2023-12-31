﻿using Core.BusinessObject;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        private readonly IPostRepository _postRepository;
        public IndexModel(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public List<POST> Posts { get; set; }

       

        public void OnGet()
        {
            Posts = _postRepository.GetAll();
        }
    }
}