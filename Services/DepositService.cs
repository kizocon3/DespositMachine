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
            //TimeSpan delay;
            //int value;
            //double canSpeed = 0.2;
            //double bottleSpeed = 0.4;
            //double popSpeed = 0.4;
            //switch (type)
            //{
            //    case ContainerType.Can:
            //        delay = TimeSpan.FromSeconds(2);
            //        value = 2;
            //        break;
            //    case ContainerType.Bottle:
            //        delay = TimeSpan.FromSeconds(1);
            //        value = 1;
            //        break;
            //    case ContainerType.Pop:
            //        delay = TimeSpan.FromSeconds(3);
            //        value = 3;
            //        break;
            //    default: throw new ArgumentException(nameof(type), $"Unsupported container type: {type}");
            //}

            var (delay, value) = type switch
            {
                ContainerType.Can => (TimeSpan.FromSeconds(2), 2),
                ContainerType.Pop => (TimeSpan.FromSeconds(1), 4),
                ContainerType.Bottle => (TimeSpan.FromSeconds(1), 3),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            await Task.Delay(delay);

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
