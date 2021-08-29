using System.Collections.Generic;
using API.Model;

namespace API.Interfaces
{
    public interface IReadInventory
    {
        public List<Inventory> ReadAllInventory();

        public Inventory ReadInventoryItem(int id);
    }
}