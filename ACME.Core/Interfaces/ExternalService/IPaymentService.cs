namespace ACME.Core.Interfaces.ExternalService;

public interface IPaymentService
{
    bool Pay(object dataToPay);
}