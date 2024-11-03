using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Post.Request;
using BlogSite.Models.Dtos.Post.Response;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Rules;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public sealed class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly PostBusinessRules _businessRules;
    public PostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules businessRules)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<PostResponseDto> Remove(Guid id)
    {
        try
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
        catch (Exception ex)
        {
            return new ReturnModel<PostResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequest updated)
    {
        try
        {
            Post post = _postRepository.GetById(updated.Id);

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
        catch(Exception ex)
        {
            return new ReturnModel<PostResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequest create, string userId)
    {
        try
        {
            Post createdPost = _mapper.Map<Post>(create);
            createdPost.Id = Guid.NewGuid();
            createdPost.AuthorId = userId;

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
        catch (Exception ex)
        {
            return new ReturnModel<PostResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        try
        {
            List<Post> posts = _postRepository.GetAll();
            List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

            return new ReturnModel<List<PostResponseDto>>
            {
                Data = responses,
                Message = "Tüm veriler getirildi.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return new ReturnModel<List<PostResponseDto>>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {
        try
        {
            Post? post = _postRepository.GetById(id);
            _businessRules.PostIsNullCheck(post);
            PostResponseDto responseDto = _mapper.Map<PostResponseDto>(post);

            return new ReturnModel<PostResponseDto>
            {
                Data = responseDto,
                Message = "Verilen id'ye ait veri getirildi.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return new ReturnModel<PostResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {
        throw new NotImplementedException();
    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string id)
    {
        try
        {
            var posts = _postRepository.GetAll(x => x.AuthorId == id);
            var responses = _mapper.Map<List<PostResponseDto>>(posts);

            return new ReturnModel<List<PostResponseDto>>
            {
                Data = responses,
                Message = "Author id listed",
                StatusCode = 200,
                Success = true
            };

        }
        catch(Exception ex)
        {
            return new ReturnModel<List<PostResponseDto>>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
    }
}
