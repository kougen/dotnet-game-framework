namespace GameFramework.Entities
{
    public interface IPlayer
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
    }
}
