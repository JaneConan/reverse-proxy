using System.ComponentModel.DataAnnotations;

namespace Yarp.ReverseProxy.Infrastructure.Entity
{
    public class Metadata : KeyValueEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
