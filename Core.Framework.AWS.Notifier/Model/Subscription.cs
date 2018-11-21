namespace Core.Framework.AWS.Notifier.Model
{
    public class Subscription
    {
        public string Protocol { get; set; }
        public string Endpoint { get; set; }
        public string Owner { get; set; }
        public string Arn { get; set; }
        public Topic Topic { get; set; }
    }
}
