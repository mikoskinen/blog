using System.Collections.Generic;

namespace caliburn_micro_datatemplate_selector
{
    public class Folder
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Folder> SubFolders { get; private set; }

        public Folder(int id, string name, List<Folder> subFolders)
        {
            Id = id;
            Name = name;
            SubFolders = subFolders;
        }
    }
}