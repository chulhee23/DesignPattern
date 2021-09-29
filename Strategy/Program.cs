using System;

namespace Strategy
{

    // Strategy Algorithm 인터페이스
    interface IPayment 
    {
        void Pay(int amount);
    }

    // Algorithm 해당 클래스
    class CardPayment : IPayment 
    {
        private string cardNo, mmyy;
        public CardPayment(string cardNo, string mmyy){
            this.cardNo = cardNo;
            this.mmyy = mmyy;
        }
        public void Pay(int amount){
            Console.WriteLine($"Charged {amount} to {cardNo}");
        }
    }
    class BitcoinPayment : IPayment 
    {
        private string address;
        public BitcoinPayment(string address){
            this.address = address;
        }

        public void Pay(int amount){
            decimal btc = (decimal)(amount / 1000000.0);
            Console.WriteLine($"Charged {btc} to {address}");
        }
    }

    // Context 클래스
    class Checkout{
        // 알고리즘 선택
        public IPayment Payment {get; set;}
        public Checkout(IPayment payment){
            this.Payment = payment;
        }

        // 선택 알고리즘 사용
        public void Charge(int total){
            Console.WriteLine($"Charging {total}");
            this.Payment.Pay(total);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var card = new CardPayment("1234123412341234", "12/25");
            var checkout = new Checkout(card);
            checkout.Charge(20000);

            var btc = new BitcoinPayment("fw9h328fhzsdfkajsh38fiuah");
            checkout.Payment = btc;
            checkout.Charge(30000);
        }
    }
}
