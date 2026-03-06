using SmartServe.Domain.Models;
using SmartServe.EFCore.Db;
using SmartServe.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartServe.Domain.Stores
{
	public class StockTransactionStore : BaseStore<StockTransactionEntity,int>, IStockTransactionStore
	{

		public StockTransactionStore(SmartServeDbContext db) : base(db)
		{
		}

	}

}
