using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class Comment
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string Content { get; set; } = string.Empty;
        public int RecordId { get; set; } = 0;
        public int ModuleId { get; set; } = 0;

    }

    public class CommentUp
    {
        public int Id { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public string Content { get; set; } = string.Empty;
        public int RecordId { get; set; } = 0; 
        public int ModuleId { get; set; } = 0;
         
    }

}
