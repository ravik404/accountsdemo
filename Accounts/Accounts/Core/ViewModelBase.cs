using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Accounts.Models;
using Accounts.Services;
using ReactiveUI;

namespace Accounts.Core
{
    public class ViewModelBase : ReactiveObject
    {  
        protected virtual void Initialize() { }
        
        
    }
}
