using OnlineCourses.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace OnlineCourses.Implementation.Helper
{
    public class Validations : IValidation
    {
        public void NotValidId(int id,string name)
        {
            if (IntIdIsInValid(id))
            {
                throw new Exception($"The {name} : {id} is not valid!");
            }
        }

        public void NotValidField(string input,int lenght, string fieldName)
        {
            if(CheckStringIsInValid(input,lenght))
            {
                throw new Exception($"The {fieldName}: {input} is not valid!");
            }
        }

        public void NotValidEmail(string email)
        {
            if(EmailIsInValid(email))
            {
                throw new Exception($" Email: {email} is not valid!");
            }
        }

        private bool IntIdIsInValid(int id)
        {
            if (id < 0 || id > int.MaxValue)
            {
                return true;
            }
            return false;
        }

        private bool CheckStringIsInValid(string input, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length >= maxLength)
            {
                return true;
            }
            return false;
        }

        private bool EmailIsInValid(string email)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_{|}~]+(\.[\w!#$%&'*+\-/=?\^_{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");
            Match match = regex.Match(email);
            if (match.Success)
            {
                return false;
            }
            return true;
        }


    }
}
