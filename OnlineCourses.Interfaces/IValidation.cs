namespace OnlineCourses.Interfaces
{
    public interface IValidation
    {
        void NotValidId(int id);

        void NotValidField(string input, int lenght);

        void NotValidEmail(string email);
    }
}
