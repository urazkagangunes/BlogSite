using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Post.Request;
using BlogSite.Models.Dtos.Post.Response;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;

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

    ReturnModel<PostResponseDto> IPostService.Remove(Guid id)
    {
        Post post = _postRepository.GetById(id);
        Post deletedPost = _postRepository.Remove(post);

        PostResponseDto response = _mapper.Map<PostResponseDto>(deletedPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    ReturnModel<PostResponseDto> IPostService.Update(UpdatePostRequest updated)
    {
        Post post =_postRepository.GetById(updated.Id);
        
        Post update = new Post
        {
            CategoryId = post.CategoryId,
            Content = updated.Content,
            Title = updated.Title,
            AuthorId = post.AuthorId,
            CreatedDate = post.CreatedDate,
        };

        Post updatedPost = _postRepository.Update(update);

        PostResponseDto responseDto = _mapper.Map<PostResponseDto>(updatedPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = responseDto,
            Message = "Post güncellendi.",
            StatusCode = 200,
            Success = true
        };
    }

    ReturnModel<PostResponseDto> IPostService.Add(CreatePostRequest create)
    {
        Post createdPost = _mapper.Map<Post>(create);
        createdPost.Id = Guid.NewGuid();

        _postRepository.Add(createdPost);

        PostResponseDto response = _mapper.Map<PostResponseDto>(createdPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Eklendi",
            StatusCode = 200,
            Success = true
        };
    }

    ReturnModel<List<PostResponseDto>> IPostService.GetAll()
    {
        List<Post> posts = _postRepository.GetAll().ToList();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = "Tüm veriler getirildi.",
            StatusCode = 200,
            Success = true
        };
    }

    ReturnModel<PostResponseDto> IPostService.GetById(Guid id)
    {
        Post? post = _postRepository.GetById(id);
        PostResponseDto responseDto = _mapper.Map<PostResponseDto>(post);

        return new ReturnModel<PostResponseDto>
        {
            Data = responseDto,
            Message = "Verilen id'ye ait veri getirildi.",
            StatusCode = 200,
            Success = true
        };
    }
}
