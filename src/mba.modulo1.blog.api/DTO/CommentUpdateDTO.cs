﻿using System.ComponentModel.DataAnnotations;

namespace MBA.Modulo1.Blog.API.DTO;
public class CommentUpdateDTO
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Content { get; set; }
}
