namespace OnlineCourses.Interfaces
{
    public interface IValidation
    {
        void NotValidId(int id, string name);

        void NotValidField(string input, int lenght, string fieldName);

        void NotValidEmail(string email);

        void NotValidRating(decimal number, string fieldName);

        void NotValidPrice(decimal price, string fieldName);
    }
}
