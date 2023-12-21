using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.domain.layer.Entities
{
    public class Auditoria
    {
        public string Id { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy{ get; set; }
        public DateTimeOffset CreatiedDate { get; set; }
        public DateTimeOffset MotifiedDate { get; set; }
        public bool Del { get; set; }
        public Auditoria()
        {
            Id = Guid.NewGuid().ToString().ToUpper();
            CreateBy = 
            ModifiedBy = string.Empty;
        }
    }
}
