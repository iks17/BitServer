using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServerBL.Models
{
    partial class BitDBContext
    {
        public User Login(string email, string pswd)
        {
            User user = this.Users
                .Include(uc => uc.Customers).ThenInclude(c => c.BusinessAccounts).Include(uc => uc.Customers).ThenInclude(cust => cust.PrivateAccounts)
                .Where(u => u.Email == email && u.Password == pswd).FirstOrDefault();

            return user;
        }

        public bool SignUp(User u)
        {
            try
            {
                if (u != null)
                {
                    this.Users.Add(u);
                    this.SaveChanges();
                    return true;
                }


                return false;
            }
            catch (Exception e)
            {
                return false;
            }


        }
        public bool CheckUniqueness(string email, string userName)
        {
            User user = this.Users.Where(u => u.Email == email || u.UserName == userName).FirstOrDefault();

            if (user == null)//the email and the user name are unique
            {
                return true;
            }
            else//one or both are not unique
            {
                return false;
            }
        }
        public double GetTotalBalance(string userName)
        {
            PrivateAccount privateAccount = this.PrivateAccounts.Where(p => p.Customer.User.UserName == userName).FirstOrDefault();
            return privateAccount.TotalBalance;
        }

        public void SendMoney(string MyNumber, int amt, string OtherNumber)
        {
            try
            { 
           PrivateAccount loggeduserAcount = this.PrivateAccounts.Where(u=>u.Customer.User.PhoneNumber==MyNumber).Include(t=>t.Customer).ThenInclude(tu=>tu.User).FirstOrDefault();
           PrivateAccount anotherUserAcount = this.PrivateAccounts.Where(u => u.Customer.User.PhoneNumber==OtherNumber).Include(t => t.Customer).ThenInclude(tu => tu.User).FirstOrDefault();
            loggeduserAcount.TotalBalance -= amt;
            anotherUserAcount.TotalBalance += amt;
            this.SaveChanges();
                TransactionLog transactionLog = new TransactionLog()
                {
                    SenderId = loggeduserAcount.CustomerId,
                ReceiverId=anotherUserAcount.CustomerId,
                SentAmt = amt,
                SenderAccount=loggeduserAcount.Customer.User.UserName,
                ReceiverAccount=anotherUserAcount.Customer.User.UserName,
                TransactionDate=DateTime.Now,
                IsConfirmed=true
            };
                this.TransactionLogs.Add(transactionLog);
                this.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArgumentNullException();
            }
        }
        public void SendMoney(string MyNumber, int amt)
        {
            try
            {
                PrivateAccount loggeduserAcount = this.PrivateAccounts.Where(u => u.Customer.User.PhoneNumber == MyNumber).Include(t => t.Customer).ThenInclude(tu => tu.User).FirstOrDefault();
                loggeduserAcount.TotalBalance += amt;
                this.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArgumentNullException();
            }
        }
        public List<TransactionLog> GetUserReceivedTransaction(int customerId)
        {
            List<TransactionLog> transactionLogs = this.TransactionLogs.Where(u=>u.ReceiverId==customerId).ToList<TransactionLog>();
            return transactionLogs;
        }
        

    }


}
