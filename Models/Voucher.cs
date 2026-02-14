namespace DespositMachine.Web.Models
{
    public class Voucher
    {
        public int TotalAmount { get; }

        public Voucher(int totalAmount)
        {
            TotalAmount = totalAmount;
        }

        public override string ToString()
        {
            return $"Voucher value: {TotalAmount} NOK";
        }
    }
}
