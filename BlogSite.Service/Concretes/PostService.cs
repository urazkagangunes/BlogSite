using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Post.Request;
using BlogSite.Models.Dtos.Post.Response;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;

namespace BlogSite.Service.Concretes;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    public Post Add(CreatePostRequest create)
    {
        Post post = _mapper.Map<Post>(create);
        Post createdPost = _postRepository.Add(post);

        return createdPost;
    }

    public List<PostResponseDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public PostResponseDto GetById(int id)
    {
        throw new NotImplementedException();
    }
}
