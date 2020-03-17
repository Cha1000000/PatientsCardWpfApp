using System;

namespace PatientСardWpfApp.Models
{
    public class Visit
    {
        public int id;
        public DateTime _date;
        public string _type;
        public string _diagnosis;
        public int pid;

        public Visit() {  }

        public Visit(int Pid, DateTime dateTime, string vType, string diagnosis)
        {
            pid = Pid;
            _date = dateTime;
            _type = vType;
            _diagnosis = diagnosis;
        }
    }
}
