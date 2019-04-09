using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            this.bankAccount = new BankAccount("MyAccount", 100);
        }

        [Test]
        public void Constructor_ShouldSetValuesCorrectly()
        {
            Assert.AreEqual("MyAccount", bankAccount.Name);
            Assert.AreEqual(100, bankAccount.Balance);
        }

        [Test]
        [TestCase("")]
        [TestCase("my")]
        [TestCase("MyBankAccountWithVeryVeryVeryLongName")]
        public void Constructor_ShouldThrowExceptionWithInvalidName(string name)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, 100));
        }

        [Test]
        public void Constructor_ShouldThrowExceptionWithNegativeAmount()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount("myAccount", -100));
        }

        [Test]
        public void Deposit_ShouldReturnCorrectBalanceAfterDepositing()
        {
            this.bankAccount.Deposit(100);
            Assert.AreEqual(200, this.bankAccount.Balance);
        }

        [Test]
        public void Deposit_ShouldThrowExceptionWhenDepositingNegativeAmount()
        {
            Assert.Throws<InvalidOperationException>(() => this.bankAccount.Deposit(-100));
        }

        [Test]
        public void Withdraw_ShouldReturnCorrecBalanceAfterWithdrawing()
        {
            this.bankAccount.Withdraw(10);
            Assert.AreEqual(90, this.bankAccount.Balance);
        }

        [Test]
        [TestCase(-100)] //negative
        [TestCase(200)] //insufficient balance
        public void Withdraw_ShouldThrowExceptionWhenWithdrawingNegativeAmount(decimal amount)
        {
            Assert.Throws<InvalidOperationException>(() => this.bankAccount.Withdraw(amount));
        }

        [Test]
        public void Withdraw_ShouldReturnCorrectWithdrawnAmount()
        {
            var withdrawnAmount = this.bankAccount.Withdraw(10);
            Assert.AreEqual(10, withdrawnAmount);
        }
    }
}