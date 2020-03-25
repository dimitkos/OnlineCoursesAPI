namespace OnlineCourses.Interfaces
{
    public interface IEmailProvider
    {
        void Send(string email, string name);
    }
}
