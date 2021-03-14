using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Model.Timetable
{
    public class TimetableData
    {
        public string id { get; set; }
        public string classname { get; set; }
        public string class_id { get; set; }        
        public DateTime createddate { get; set; }
        public string createdby { get; set; }
        public string status { get; set; }
        public List<ScheduledTimings> scheduleData { get; set; }
    }
    public class ScheduledTimings
    {
        public string id { get; set; }
        public string section_id { get; set; }
        public string subject_id { get; set; }
        public string teacher_id { get; set; }
        public string section { get; set; }
        public string teacher { get; set; }
        public string subject { get; set; }
        public string periodFrom { get; set; }
        public string periodTo { get; set; }
    }
}
