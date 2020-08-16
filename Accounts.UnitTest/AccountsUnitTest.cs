using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;

namespace Accounts.UnitTest
{
    [TestClass]
    public class AccountsUnitTest
    {
        int defaultAsyncWait = 3000;


        [TestMethod]
        public void LoadingReturnsAccounts()
        {
            var service = new Services.ServiceClient(null);
            var vm = new ViewModels.AccountsViewModel(service, null);
            Thread.Sleep(defaultAsyncWait);           
            //No accounts
            Assert.IsFalse((vm.Accounts == null || vm.Accounts.Count == 0), "Service did not return any accounts");

        }


        [TestMethod]
        public void LoadingReturnsActiveAccounts()
        {
            var service = new Services.ServiceClient(null);
            var vm = new ViewModels.AccountsViewModel(service, null);
            Thread.Sleep(defaultAsyncWait);            

            if (vm.Accounts != null)
            {
                bool hasInactive = vm.Accounts.Any(w => w.IsActive == false);
                //Active accounts
                Assert.IsFalse(hasInactive, "Service retuned inactive accounts");
            }
        }

        [TestMethod]
        public void LoadingReturnsObsoleteAccounts()
        {
            var service = new Services.ServiceClient(null);
            var vm = new ViewModels.AccountsViewModel(service, null);
            Thread.Sleep(defaultAsyncWait);          

            if (vm.Accounts != null)
            {
                DateTime minAccDate = new DateTime(2016, 1, 1);
                bool hasOld = vm.Accounts.Any(w => w.Registered < minAccDate);

                //Accounts registered after 2016                 
                Assert.IsFalse(hasOld, $"Service retuned accounts registerd before {minAccDate.ToString("mm/DD/yyy")}");
            }
        }

        [TestMethod]
        public void RefresReturnsAccounts()
        {
            var service = new Services.ServiceClient(null);
            var vm = new ViewModels.AccountsViewModel(service, null);
            Thread.Sleep(defaultAsyncWait);
            vm.LoadAccountsCommand.Execute(null);
            Thread.Sleep(defaultAsyncWait);
            //No accounts
            Assert.IsFalse((vm.Accounts == null || vm.Accounts.Count == 0), "Service did not return any accounts");            

        }

        

        [TestMethod]
        public void RefresReturnsActiveAccounts()
        {
            var service = new Services.ServiceClient(null);
            var vm = new ViewModels.AccountsViewModel(service, null);
            Thread.Sleep(defaultAsyncWait);
            vm.LoadAccountsCommand.Execute(null);
            Thread.Sleep(defaultAsyncWait);       
            
            if (vm.Accounts != null)
            {
                bool hasInactive = vm.Accounts.Any(w => w.IsActive == false);
                //Active accounts
                Assert.IsFalse(hasInactive, "Service retuned inactive accounts");
            }
        }

        [TestMethod]
        public void RefresReturnsObsoleteAccounts()
        {
            var service = new Services.ServiceClient(null);
            var vm = new ViewModels.AccountsViewModel(service, null);
            Thread.Sleep(defaultAsyncWait);
            vm.LoadAccountsCommand.Execute(null);
            Thread.Sleep(defaultAsyncWait);

            if (vm.Accounts != null)
            {
                DateTime minAccDate = new DateTime(2016, 1, 1);
                bool hasOld = vm.Accounts.Any(w => w.Registered < minAccDate);                

                //Accounts registered after 2016                 
                Assert.IsFalse(hasOld, $"Service retuned accounts registerd before {minAccDate.ToString("mm/DD/yyy")}");
            }
        }
    }
}
