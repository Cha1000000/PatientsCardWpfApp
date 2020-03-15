
namespace PatientСardWpfApp.Models
{
    class PersonalCard
    {
        public int _id;
        public string _name;
        public string _surname;
        public string _patronymic;
        public string _sex;
        public string _birthday;
        public string _adress;
        public string _phone;

        public PersonalCard() {}
        public PersonalCard(int id, string name, string surname, string patronymic, string sex, string birthday, string phone, string adress)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _sex = sex;
            _birthday = birthday;
            _adress = adress;
            _phone = phone;
        }
    }
}
