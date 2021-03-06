using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagotchi
{
	public interface IDataStore<T>
	{
		//CRUD operation
		bool CreateItem(T item);
		T ReadItem();
		bool UpdateItem(T item);
		bool DeleteItem(T item);
	}

}
