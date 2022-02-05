using System.ComponentModel.DataAnnotations;

namespace Yarp.ReverseProxy.Infrastructure.Entity
{
    public class SessionAffinityOptionSetting : KeyValueEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
