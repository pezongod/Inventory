namespace Inventory.Classer
{
    public class Typ : IEntity
    {
        public int Id { get; set; }
        public int TypId { get; set; }

        public string Namn { get; set; }
    }
}