
using Antlr.Runtime.Misc;
using FluentNHibernate.Conventions.Inspections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        [MinLength(100, ErrorMessage = "The content must contain at least 100 characters.")]
        public string Content { get; set; }
        public int? TeamId { get; set; }
        public int? CategoryId { get; set; }
        public int? LikeCount { get; set; }
        public int? CommentCount { get; set; }
        public int CommentID { get; set; }
        public string? PostUserName { get; set; }
        public string? PostTeamName { get; set; }
        public bool? IsEditorChoice { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public int? PictureId { get; set; }

        public virtual Picture? Picture{ get; set; }

        public virtual ICollection<Team>? Teams { get; set; } = new List<Team>();

        public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();

        public virtual ICollection<Category>? Category { get; set; } = new List<Category>();

    }
}
