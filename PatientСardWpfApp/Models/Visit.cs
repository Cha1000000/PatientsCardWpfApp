using System;

namespace PatientСardWpfApp.Models
{
    class Visit
    {
        public int pid;
        public DateTime _date;
        public string _type;
        public string _diagnosis;

        public Visit() {  }

        public Visit(int id, DateTime dateTime, string vType, string diagnosis)
        {
            pid = id;
            _date = dateTime;
            _type = vType;
            _diagnosis = diagnosis;
        }
    }
}
