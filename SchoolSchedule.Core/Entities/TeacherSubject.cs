using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSchedule.Core
{
    public class TeacherSubject
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int SubjectId {  get; set; }
        public Subject? Subject { get; set; }
    }
}
