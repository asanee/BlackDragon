using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlackDragon.TimeSheets.Shared
{
    public class CircleFullDto
    {
        public long ID { get; set; }

        public bool CanJoin { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IList<ProfileFacadeDto> Members { get; set; }

        public ProfileFacadeDto Owner { get; set; }

        public IList<DocumentFacadeDto> Documents { get; set; }
    }
}