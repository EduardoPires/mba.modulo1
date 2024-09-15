﻿using mba.modulo1.blog.domain.Entities;
using MBA.Modulo1.Blog.Domain.Entities.Validations;
using MBA.Modulo1.Blog.Domain.Interfaces;

namespace MBA.Modulo1.Blog.Domain.Services;

public class CommentService : BaseService, ICommentService
{
    private readonly ICommnetRepository _commentRepository;

    public CommentService(ICommnetRepository commentRepository, INotifier notifier) : base(notifier)
    {
        _commentRepository = commentRepository;
    }

    public async Task AddAsync(Comment comment)
    {
        if (!Validate(new CommentValidation(), comment)) return;

        await _commentRepository.AddAsync(comment);
    }

    public async Task UpdateAsync(Comment post)
    {
        if (!Validate(new CommentValidation(), post)) return;
        await _commentRepository.UpdateAsync(post);
    }

    public async Task DeleteAsync(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment != null)
        {
            Notify("Comentário não encontrado!");
            return;
        }

        await _commentRepository.DeleteByIdAsync(id);
    }

    public void Dispose() => _commentRepository.Dispose();

}