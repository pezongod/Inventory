namespace Inventory
{
    internal class MenuItems
    {
        public string Name { get; set; }
        public Page Connection { get; set; }

        public MenuItems(string name, Page con)
        {
            Name = name;
            Connection = con;
        }
    }
}