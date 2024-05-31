using ACME.Core.Interfaces.ExternalService;

namespace ACME.Core.ExternalService;

internal class PaymentService : IPaymentService
{
    public bool Pay(object dataToPay)
    {
        if (dataToPay == null) throw new ArgumentNullException("dataToPay");
        return true;
    }
}
