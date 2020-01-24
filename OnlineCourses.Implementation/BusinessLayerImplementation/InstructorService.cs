using OnlineCourses.Implementation.Helper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.Requests;
using OnlineCourses.Types.Responses;
using OnlineCourses.Types.Types;

namespace OnlineCourses.Implementation.BusinessLayerImplementation
{
    public class InstructorService : IInstructor
    {
        private readonly IService _dbService;
        private readonly IValidation _validation;

        public InstructorService(IService dbService, IValidation validation)
        {
            _dbService = dbService;
            _validation = validation;
        }

        public GetInstructorsResponse FetchInstructors()
        {
            var cache = Cache.Get("instructors", () => _dbService.GetInstructors(), 1);//maybe do paging
            return cache;
        }

        public GetInstructorByIdResponse FetchInstructorById(GetInstructorByIdRequest request)
        {
            _validation.NotValidId(request.InstructorId);

            var cache = Cache.Get(request.InstructorId.ToString(), () => _dbService.GetInstructorById(request));
            return cache;
        }

        public bool CreateNewInstructor(CreateInstructorAccountRequest request)
        {
            ValidateUserData(request.ConvertToInstructorData());

            return _dbService.CreateInstructorAccount(request);
        }

        public bool UpdateInstructor(UpdateInstructorDataRequest request)
        {
            ValidateUserData(request.ConvertToInstructorData());

            return _dbService.UpdateInstructorData(request);
        }

        private void ValidateUserData(InstructorData request)
        {
            _validation.NotValidId(request.Id);

            _validation.NotValidField(request.FullName, 50);

            _validation.NotValidEmail(request.Email);

            _validation.NotValidField(request.Bio, 20);

            _validation.NotValidField(request.Language, 20);

        }
    }
}
