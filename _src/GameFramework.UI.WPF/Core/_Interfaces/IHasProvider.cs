using System;
using System.Windows;

namespace GameFramework.UI.WPF.Core
{
    public interface IHasProvider
    {
        IServiceProvider Services { get; }
    }
}
