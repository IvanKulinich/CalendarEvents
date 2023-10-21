namespace CalendarEvents.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }

        Task<int> SaveAsync();
    }
}
