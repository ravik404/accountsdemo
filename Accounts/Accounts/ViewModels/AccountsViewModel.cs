using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Accounts.Core;
using Accounts.Models;
using Accounts.Services;
using Accounts.Views;
using Xamarin.Forms;
using System.Linq;
using System.Windows.Input;
using ReactiveUI;
using Accounts.Core.Interfaces;
using DynamicData;

namespace Accounts.ViewModels
{
    /// <summary>
    /// TODO: Notes about the class
    /// </summary>
    public class AccountsViewModel : ViewModelBase
    {
        #region Properties and fields
        public ICommand LoadAccountsCommand { get; set; }

        public ICommand ShowDetailsCommand { get; set; }

        public ObservableCollection<Account> Accounts { get; set; }

        private DateTime MinAccountDate = new DateTime(2016, 1, 1);
        private string MaleEnumKey = "male";
        private string FemaleEnumKey = "female";

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { this.RaiseAndSetIfChanged(ref _isLoading, value); }
        }


        private bool _isGrouped = true;
        public bool IsGrouped
        {
            get { return _isGrouped; }
            set { this.RaiseAndSetIfChanged(ref _isGrouped, value); }
        }
        

        private string _pageTitle = "Account Holders";
        public string PageTitle => _pageTitle;

        private IServiceClient _serviceClient;
        private ILogging _loggingService;
        #endregion

        #region Constructor
        public AccountsViewModel(IServiceClient serviceClient, ILogging loggingService)
        {
            _serviceClient = serviceClient;
            _loggingService = loggingService;
            Accounts = new ObservableCollection<Account>();           
            IsLoading = true;
            var loadTask = GetListOfAccounts();
            loadTask.ContinueWith((acs) =>
            {
                try
                {
                    if (acs.IsFaulted)
                        throw acs.Exception;

                    if (acs.Result != null)
                    {
                        if (IsGrouped)
                            CopyAccountResultsToGroupObservable(acs.Result);
                        else
                            CopyAccountResultsToObservable(acs.Result);
                    }
                }
                catch(Exception ex)
                {
                    _loggingService?.Error(ex); //TODO:
                }
                finally
                {
                    IsLoading = false;
                }
                
            });
            LoadAccountsCommand = ReactiveUI.ReactiveCommand.CreateFromTask(ExecuteLoadAccountsCommand);
            ShowDetailsCommand = ReactiveUI.ReactiveCommand.CreateFromTask(ExecuteShowDetailsCommand);

        }
        #endregion

        #region Public Methods
        public Task<IEnumerable<Account>> GetListOfAccounts()
        {
            if (_serviceClient == null)
                new Exception("IServiceClient has no value");

            return _serviceClient.GetListOfAccountsAsync();
        }



        #endregion

        #region Helper Methods

        private async Task ExecuteShowDetailsCommand()
        {            

        }
        private async Task ExecuteLoadAccountsCommand()
        {
            IsLoading = true;          

            try
            {            
                var accounts = await GetListOfAccounts();
                if (IsGrouped)
                    CopyAccountResultsToGroupObservable(accounts);
                else
                    CopyAccountResultsToObservable(accounts);             


            }
            catch (Exception ex)
            {
                _loggingService?.Error(ex); //TODO: 
            }
            finally
            {
                IsLoading = false;
            }

        }   

        private void CopyAccountResultsToObservable(IEnumerable<Account> accounts)
        {
            Accounts.Clear();   
            //TODO:
        }

        private void CopyAccountResultsToGroupObservable(IEnumerable<Account> accounts)
        {
            Accounts.Clear();
            var maleHolderHeader = new Account() { GroupName = "Male Holders", IsActive=true, Registered = DateTime.Today };
            var femaleHolderHeader = new Account() { GroupName = "Female Holders", IsActive = true, Registered = DateTime.Today };

            var maleList = accounts.Where(w => w.Gender == MaleEnumKey && w.IsActive && w.Registered >= MinAccountDate).OrderByDescending(a => a.Age).ThenBy(b => b.AccountBalance);
            if (maleList.Count() > 0)
            {
                Accounts.Add(maleHolderHeader);
                Accounts.AddRange(maleList);
            }

            var femaleList = accounts.Where(w => w.Gender == FemaleEnumKey && w.IsActive && w.Registered >= MinAccountDate).OrderByDescending(a => a.Age).ThenBy(b => b.AccountBalance);
            if (femaleList.Count() > 0)
            {
                Accounts.Add(femaleHolderHeader);
                Accounts.AddRange(femaleList);
            }          
            
        }

        #endregion

    }
}
