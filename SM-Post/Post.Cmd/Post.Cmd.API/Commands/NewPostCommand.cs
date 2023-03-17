using CQRS.Core.Commands;

namespace Post.Cmd.API.Commands
{
    public class NewPostCommand : BaseCommand
    {
        public string Author { get; set; }
        public string Message { get; set; }
    }
}