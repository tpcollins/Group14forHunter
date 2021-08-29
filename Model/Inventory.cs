using API.Database;
using API.Interfaces;

namespace API.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public string ItemCategory { get; set; }
        public string RentStatus { get; set; }
        public string ItemCondition { get; set; }
        public int ItemCount { get; set; }

        public ICreateInventory CreateBehavior { get; set; } // CreateBehavior for Create class
        public IReadInventory ReadBehavior { get; set; } // ReadBehavior for Read class
        public IUpdateInventory UpdateBehavior { get; set; } // UpdateBehavior for Update class
        public IDeleteInventory DeleteBehavior { get; set; } // DeleteBehavior for Delete class

        public Inventory()
        {
            CreateBehavior = new CreateInventory();
            ReadBehavior = new ReadInventory();
            UpdateBehavior = new UpdateInventory();
            DeleteBehavior = new DeleteInventory();
        }
        public override string ToString()
        {
            return Id + " " + ItemCategory + " " + RentStatus + " " + ItemCondition + " " + ItemCount;
        }
    }
}