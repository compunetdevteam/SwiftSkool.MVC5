using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.Abstractions
{
    public interface IPaymentManager
    {
        Task<int> CreatePayment(PaymentInputModel payment);
    }
}