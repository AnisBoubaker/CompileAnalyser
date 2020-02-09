namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CourseGroupUser
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string CourseGroupId { get; set; }

        public virtual CourseGroup CourseGroup { get; set; }
    }
}
