using BankAccountNS;

namespace BankTests
{
    [TestFixture]
    public class Tests
    {
        BankAccount account;

        [Test]
        public void DebitTest_ValidAmount()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            account = new BankAccount("Mr. Juan Nova", beginningBalance);

            account.Debit(debitAmount);

            Assert.That(account.Balance, Is.EqualTo(expected));
        }

        [Test]

        public void DebitTest_AmountGreaterThanBalance() 
        {
            double beginningBalance = 11.99;
            double debitAmount = 100.55;
            account = new BankAccount("Mr. Juan Nova", beginningBalance);

            //Assert.Throws<ArgumentOutOfRangeException>(()=> account.Debit(debitAmount)); First Assert

            try
            {
                account.Debit(debitAmount);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, ex.Message);
            }
        }

        [Test]

        public void DebitTest_AmountLessThanZero()
        {
            double beginningBalance = 11.99;
            double debitAmount = -10;
            account = new BankAccount("Mr. Juan Nova", beginningBalance);

            //Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount)); First Assert

            try
            {
                account.Debit(debitAmount);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(BankAccount.DebitAmountLessThanZeroMessage, ex.Message);
            }
        }
    }
}