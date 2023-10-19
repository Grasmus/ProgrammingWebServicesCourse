using MimeKit;

namespace TrainStation.Services.Helpers
{
    public class Message
    {
        public MailboxAddress To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(string to, string subject, string content, string name)
        {
            To = new MailboxAddress(name, to);
            Subject = subject;
            Content = content;
        }
    }
}
