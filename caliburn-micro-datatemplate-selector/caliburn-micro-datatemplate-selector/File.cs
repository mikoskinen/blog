namespace caliburn_micro_datatemplate_selector
{
    public class File
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Size { get; private set; }

        public File(int id, string name, double size)
        {
            Id = id;
            Name = name;
            Size = size;
        }
    }
}
