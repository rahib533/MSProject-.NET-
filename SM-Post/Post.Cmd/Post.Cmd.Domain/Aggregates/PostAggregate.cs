using CQRS.Core.Domain;
using Post.Common.Events;

namespace Post.Cmd.Domain.Aggregates
{
    public class PostAggregate : AggregateRoot
    {
        private bool _active;
        private string _author;

        private readonly Dictionary<Guid, (string, string)> _comments = new ();

        public bool Active
        {
            get => _active; set => _active = value;
        }

        public PostAggregate()
        {

        }

        public PostAggregate(Guid id, string author, string message)
        {
            RaiseEvent(new PostCreatedEvent
            {
                Id = id,
                Author = author,
                Message = message,
                DatePosted = DateTime.UtcNow
            });
        }

        public void Apply(PostCreatedEvent @event)
        {
            _id = @event.Id;
            _active = true;
            _author = @event.Author;

        }

        public void EditMessage(string message)
        {
            if (!_active)
            {
                throw new InvalidOperationException("You can not edit the message of an inactive post");
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new InvalidOperationException 
                ($"The value of {nameof(message)} can not be null or empty. Please provide a valid {nameof(message)}!");
            }
            RaiseEvent(new MessageUpdatedEvent{
                Id = _id,
                Message = message
            });
        }

        public void Apply(MessageUpdatedEvent @event)
        {
            _id = @event.Id;
        }

        public void LikePost()
        {
            if (!_active)
            {
                throw new InvalidOperationException("You can not like an inactive post!");
            }
            RaiseEvent(new PostLikedEvent
            {
                Id = _id
            });
        }

        public void Apply(PostLikedEvent @event)
        {
            _id = @event.Id;
        }

        public void AddComment(string comment, string username)
        {
            if (!_active)
            {
                throw new InvalidOperationException("You can not add a comment to an inactive post!");
            }

            if (string.IsNullOrWhiteSpace(comment))
            {
                throw new InvalidOperationException
                ($"The value of {nameof(comment)} can not be null or empty. Please provide a valid {nameof(comment)}!");
            }

            RaiseEvent(new CommentAddedEvent
            {
                Id = _id,
                CommentId = Guid.NewGuid(),
                Comment = comment,
                Username = username,
                CommentDate = DateTime.UtcNow
            });
        }

        public void Apply(CommentAddedEvent @event)
        {
            _id = @event.Id;
            _comments.Add(@event.CommentId, new (@event.Comment, @event.Username));
        }
    }
}