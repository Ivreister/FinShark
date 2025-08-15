using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentMode)
        {
            return new CommentDto
            {
                Id = commentMode.Id,
                Title = commentMode.Title,
                Content = commentMode.Content,
                CreatedOn = commentMode.CreatedOn,
                StockId = commentMode.StockId
            };
        }
    }
}