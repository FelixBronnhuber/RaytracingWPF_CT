using System;
using System.Windows.Input;
using RaytracingWPF_CT.Render;
using RaytracingWPF_CT.ViewModel;

namespace RaytracingWPF_CT.Commands
{
    public class SafeImageCommand : ICommand
    {
        private readonly MainViewModel _mainViewModel;

        public SafeImageCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BitmapManager.SaveToPng(_mainViewModel.BitmapSource);
        }

        public event EventHandler CanExecuteChanged;
    }
}