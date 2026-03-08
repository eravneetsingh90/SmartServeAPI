namespace SmartServe.Domain.Stores
{
	namespace SmartServe.Domain.Stores
	{
		public interface IBaseStore<T, TKey> where T : class
		{
			Task<List<T>> GetAllAsync(int tenantId);
			Task<T?> GetByIdAsync(int tenantId,TKey id);
			void Add(T entity);
			void AddRange(List<T> entities);
			void Update(T entity);
			void UpdateRange(List<T> entities);
			void RemoveRange(List<T> entities);
			void Attach(T entity);
			void Remove(T entity);
			Task SaveAsync();
		}

	}

}
