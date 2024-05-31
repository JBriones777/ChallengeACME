using ACME.Core.CustomEntity;
using ACME.Core.Entities;
using ACME.Core.ExternalService;
using ACME.Core.Interfaces.ExternalService;
using ACME.Core.Interfaces.Services;
using ACME.Core.Repositories;
using System.Runtime.InteropServices;

namespace ACME.Core.Services;

public class ContractCourseService : IContractCourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentService _paymentService;

    public ContractCourseService(IPaymentService paymentService = null)
    {
        _unitOfWork = new UnitOfWork();
        _paymentService = paymentService ?? new PaymentService();
    }

    public ContractCourse ContractCourse(Guid studenId, Guid courseId, decimal amount)
    {
        var student = _unitOfWork.StudentRepository.GetById(studenId);
        if (student == null) throw new KeyNotFoundException("Student not found");

        var course = _unitOfWork.CourseRepository.GetById(courseId);
        if (course == null) throw new KeyNotFoundException("Course not found");

        if (amount < course.RegistrationFee) throw new InvalidOperationException("The amount paid is less than the course fee");

        var successPayment = _paymentService.Pay(new { Amount = amount });
        if (!successPayment) throw new ExternalException("An error occurred while trying to make the payment");

        var contractCourse = new ContractCourse
        {
            Amount = amount,
            Course = course,
            CourseId = courseId,
            Student = student,
            StudentId = studenId,
        };
        _unitOfWork.ContractCourseRepository.Create(contractCourse);
        return contractCourse;
    }

    public PaginationInfo<ContractCourse> GetListContractCourse(DateTime startDate, DateTime endDate, int page = 1, int pageSize = 10)
    {
        if (startDate > endDate) throw new ArgumentException("The start date cannot be greater than the end date");
        var result = _unitOfWork.ContractCourseRepository.GetByRange(startDate, endDate, page, pageSize);
        return result;
    }

}
