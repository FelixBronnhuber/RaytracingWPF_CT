using System;
using System.Windows.Input;
using RaytracingWPF_CT.Render;
using RaytracingWPF_CT.ViewModel;

namespace RaytracingWPF_CT.Commands
{
    public class RenderCommand : ICommand
    {
        private readonly MainViewModel _mainViewModel;

        public RenderCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainViewModel.RenderMain = new RenderMain(_mainViewModel, _mainViewModel.TextBoxInput);
        }

        public event EventHandler CanExecuteChanged;
    }
}