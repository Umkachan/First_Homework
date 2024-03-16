using ProjectTypes.Interfaces;
using ProjectTypes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGroup
{
    public class MainClass
    {
        IAcademyGroupCommon<Person> _workModel;
        public MainClass(IAcademyGroupCommon<Person> workModel)
        {
            _workModel = workModel;
        }

        public void Start()
        {
            _workModel.Add(new Student("Alex", "Mich", 41));
            _workModel.Add(new Student("Marina", "Borm", 34, "+3809434234234"));
            _workModel.Add(new Student("Valia", "Valentinov", 34, "+3809434234234"));
            _workModel.Add(new Person("Thif"));
            _workModel.Search(new Person("", "", 34));
        }
    }
}
