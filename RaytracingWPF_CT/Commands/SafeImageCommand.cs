using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
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
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Image files (*.png)|*.png;*.jpeg|All files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog() != true) return;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(_mainViewModel.BitmapSource));
            FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create);
            encoder.Save(stream);
            stream.Close();
        }

        public event EventHandler CanExecuteChanged;
    }
}