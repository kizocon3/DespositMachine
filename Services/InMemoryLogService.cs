using DespositMachine.Web.Models;
using System.ComponentModel;

namespace DespositMachine.Web.Services
{
    public class InMemoryLogService: ILogService
    {
        private readonly List<string> _logs = new();

        // Here i use a simple string log format for simplicity => , but in a real application you might use more structured then u can use { }
        public void LogContainer(ContainerType type) => _logs.Add($"{DateTime.UtcNow}: {type} inserted");

        public void LogVoucher(int amount) => _logs.Add($"{DateTime.UtcNow}: Voucher printed: {amount} NOK");

        public IReadOnlyList<string> GetLogs() => _logs;
    }
}
