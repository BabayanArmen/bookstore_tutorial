using System.Reflection;

namespace BookStore.DTOs.Author
{
    public class CreateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public List<int>? BookIds { get; set; }
        public List<int>? PublisherIds { get; set; }
    }
}


//One condition: Assembly.GetExecutingAssembly() must contain your validator classes. If they are in another project/assembly, scan that assembly instead.