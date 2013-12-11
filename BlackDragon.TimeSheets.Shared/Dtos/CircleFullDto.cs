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

        public bool CanJoin
        {
            get
            {
                return !(IsOwner || IsAdded || IsRequested);
            }
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IList<ProfileFacadeDto> Members { get; set; }

        public IList<ProfileFacadeDto> Requestors { get; set; }

        public ProfileFacadeDto Owner { get; set; }

        public IList<DocumentFacadeDto> Documents { get; set; }

        public bool IsOwner { get; set; }

        public bool IsAdded { get; set; }

        public bool IsRequested { get; set; }
    }
}