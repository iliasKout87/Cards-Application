namespace Cards.Application.Contracts.Persistence
{
	public interface IAsyncRepository<T> where T : class
	{
		Task<IReadOnlyList<T>> GetAllAsync();

		Task<T> AddAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(T entity);
	}
}
