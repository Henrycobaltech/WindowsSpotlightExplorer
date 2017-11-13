using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WindowsSpotlightExplorer.Services;

namespace WindowsSpotlightExplorer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ImageItemViewModel> Images { get; set; }

        public ICommand SaveAsCommand { get; set; }

        public MainWindowViewModel()
        {

            this.Images = new ObservableCollection<ImageItemViewModel>(
                PictureService.GetImageSources().Select((p) => new ImageItemViewModel(p.src, p.file)));
            SaveAsCommand = new RelayCommand<ImageItemViewModel>(item =>
            {
                var dlg = new SaveFileDialog();
                dlg.Filter = "PNG Images (*.png)|*.png";
                var result = dlg.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    SaveImage(item.Source, dlg.FileName);
                }
            });
        }

        private static void SaveImage(ImageSource source, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(source as BitmapSource));
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                encoder.Save(fs);
            }
        }
    }
}
