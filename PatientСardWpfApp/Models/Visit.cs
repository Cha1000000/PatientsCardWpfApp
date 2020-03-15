using System;

namespace PatientСardWpfApp.Models
{
    class Visit
    {
        public DateTime _date;
        public string _type;
        public string _diagnosis;

        public Visit() { }

        public Visit(DateTime dateTime, string vType, string diagnosis)
        {
            _date = dateTime;
            _type = vType;
            _diagnosis = diagnosis;
        }
    }
}
