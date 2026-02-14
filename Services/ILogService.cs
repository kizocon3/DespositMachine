using DespositMachine.Web.Models;
using System.ComponentModel;

namespace DespositMachine.Web.Services
{
    public interface ILogService
    {
        void LogContainer(ContainerType container);
        void LogVoucher(int amount);
        IReadOnlyList<string> GetLogs();
    }
}
