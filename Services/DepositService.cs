using DespositMachine.Web.Models;

namespace DespositMachine.Web.Services
{
    public class DepositService: IDepositService
    {
        private readonly ILogService _logService;
        private int _currentTotal = 0;
        public int CurrentTotal => _currentTotal;
        public DepositService(ILogService logService)
        {
            _logService = logService;
        }
        public async Task InsertAsync(ContainerType type)
        {
            double canSpeed = 0.2;
            double bottleSpeed = 0.4;
            var delay = type == ContainerType.Can ? TimeSpan.FromSeconds(2 * canSpeed) : TimeSpan.FromSeconds(1 * bottleSpeed);
            await Task.Delay(delay);        

            var value = type == ContainerType.Can ? 2 : 3;    

            _currentTotal += value;
            _logService.LogContainer(type);
        }

        public Voucher PrintVoucher()
        {
            var voucher = new Voucher(_currentTotal);
            _logService.LogVoucher(voucher.TotalAmount);
            _currentTotal = 0;
            return voucher;
        }

    }
}
