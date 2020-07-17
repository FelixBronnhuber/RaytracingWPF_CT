using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using RaytracingWPF_CT.Annotations;
using RaytracingWPF_CT.Commands;
using RaytracingWPF_CT.Render;

namespace RaytracingWPF_CT.ViewModel
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {
        private BitmapSource _bitmapSource;
        private string _textBoxInput;

        public MainViewModel()
        {
            BitmapSource = BitmapManager.SaveToBmp(10, 10, new byte[400]);
            RenderCommand = new RenderCommand(this);
            SafeImageCommand = new SafeImageCommand(this);
            TextBoxInput =
                //Test Input String (Cube of 3x3 Spheres)  
                @"1440, 1440
S([400;-600;600], 300, [255;0;0])
S([400;0;600], 300, [255;0;0])
S([400;600;600], 300, [255;0;0])
S([400;-600;0], 300, [255;0;0])
S([400;0;0], 300, [255;0;0])
S([400;600;0], 300, [255;0;0])
S([400;-600;-600], 300, [255;0;0])
S([400;0;-600], 300, [255;0;0])
S([400;600;-600], 300, [255;0;0])
S([800;-600;600], 300, [255;0;0])
S([800;0;600], 300, [255;0;0])
S([800;600;600], 300, [255;0;0])
S([800;-600;0], 300, [255;0;0])
S([800;0;0], 300, [255;0;0])
S([800;600;0], 300, [255;0;0])
S([800;-600;-600], 300, [255;0;0])
S([800;0;-600], 300, [255;0;0])
S([800;600;-600], 300, [255;0;0])
S([1200;-600;600], 300, [255;0;0])
S([1200;0;600], 300, [255;0;0])
S([1200;600;600], 300, [255;0;0])
S([1200;-600;0], 300, [255;0;0])
S([1200;0;0], 300, [255;0;0])
S([1200;600;0], 300, [255;0;0])
S([1200;-600;-600], 300, [255;0;0])
S([1200;0;-600], 300, [255;0;0])
S([1200;600;-600], 300, [255;0;0])";
        }

        public BitmapSource BitmapSource
        {
            get => _bitmapSource;
            set
            {
                if (Equals(value, _bitmapSource)) return;
                _bitmapSource = value;
                OnPropertyChanged();
            }
        }

        public RenderCommand RenderCommand { get; set; }
        public SafeImageCommand SafeImageCommand { get; set; }
        public RenderMain RenderMain { get; set; }

        public string TextBoxInput
        {
            get => _textBoxInput;
            set
            {
                if (value == _textBoxInput) return;
                _textBoxInput = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}