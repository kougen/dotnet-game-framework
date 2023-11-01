using System;
using System.Windows;

namespace GameFramework.UI.WPF.Core._Interfaces
{
    public interface IHasProvider
    {
        IServiceProvider Services { get; }
    }
}
