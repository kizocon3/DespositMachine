using DespositMachine.Web.Models;

namespace DespositMachine.Web.Services
{
    public interface IDepositService
    {
        Task InsertAsync(ContainerType type);
        Voucher PrintVoucher();
        int CurrentTotal { get; }
    }
}
