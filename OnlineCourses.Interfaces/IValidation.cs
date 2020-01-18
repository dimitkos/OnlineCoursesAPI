using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Interfaces
{
    public interface IValidation
    {
        void NotValidId(int id);

        void NotValidField(string input, int lenght);

        void NotValidEmail(string email);
    }
}
