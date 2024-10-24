﻿using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Comment.Request;
using BlogSite.Models.Dtos.Comment.Response;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    ReturnModel<CommentResponseDto> ICommentService.Add(CreateCommentRequest createCommentRequest)
    {
        try
        {
            Comment createComment = _mapper.Map<Comment>(createCommentRequest);

            _commentRepository.Add(createComment);

            CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(createComment);

            return new ReturnModel<CommentResponseDto>
            {
                Data = commentResponseDto,
                Message = "Comment added.",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ReturnModel<CommentResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }

    ReturnModel<List<CommentResponseDto>> ICommentService.GetAll()
    {
        try
        {
            List<Comment> comments = _commentRepository.GetAll().ToList();
            List<CommentResponseDto> commentResponseDto = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = commentResponseDto,
                Message = "Whole Comment Listed.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
    }

    ReturnModel<CommentResponseDto> ICommentService.GetById(Guid id)
    {
        try
        {
            Comment? comment = _commentRepository.GetById(id);
            CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(comment);

            return new ReturnModel<CommentResponseDto>
            {
                Data = commentResponseDto,
                Message = "Wanted id Comment getted.",
                StatusCode = 200,
                Success = true,
            };
        }
        catch (Exception ex)
        {
            return new ReturnModel<CommentResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }

    }

    ReturnModel<CommentResponseDto> ICommentService.Remove(Guid id)
    {
        try
        {
            Comment? comment = _commentRepository.GetById(id);
            Comment? deletedComment = _commentRepository.Remove(comment);

            CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(deletedComment);

            return new ReturnModel<CommentResponseDto>
            {
                Data = commentResponseDto,
                Message = "Comment deleted.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return new ReturnModel<CommentResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }

    ReturnModel<CommentResponseDto> ICommentService.Update(UpdateCommentRequest updateCommentRequest)
    {
        try
        {
            Comment? comment = _commentRepository.GetById(updateCommentRequest.Id);
            Comment updateComment = new Comment
            {
                Text = updateCommentRequest.Text,
                UserId = comment.UserId,
                PostId = comment.PostId,
            };

            Comment? updatedComment = _commentRepository.Update(updateComment);
            CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(updatedComment);

            return new ReturnModel<CommentResponseDto>
            {
                Data = commentResponseDto,
                Message = "Comment updated.",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ReturnModel<CommentResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
    }

}
