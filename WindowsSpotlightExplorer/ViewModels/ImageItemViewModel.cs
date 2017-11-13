using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WindowsSpotlightExplorer.ViewModels
{
    public class ImageItemViewModel : ViewModelBase
    {
        private ImageSource _source;

        public ImageSource Source
        {
            get { return _source; }
            set { Set(ref _source, value); }
        }

        private int _width;

        public int Width
        {
            get { return _width; }
            set { Set(ref _width, value); }
        }

        private int _height;

        public int Height
        {
            get { return _height; }
            set { Set(ref _height, value); }
        }

        private double _sizeInKb;

        public double SizeInKb
        {
            get { return _sizeInKb; }
            set { Set(ref _sizeInKb, value); }
        }


        public ImageItemViewModel(ImageSource source, FileInfo file)
        {
            Source = source;
            Width = (int)source.Width;
            Height = (int)source.Height;
            SizeInKb = Math.Round((double)file.Length / (1 << 10), 1);

        }
    }
}