using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WindowsSpotlightExplorer.Services
{
    public class PictureService
    {
        public static IEnumerable<(ImageSource src, FileInfo file)> GetImageSources()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets");

            var dir = new DirectoryInfo(path);
            foreach (var file in dir.GetFiles())
            {
                if (file.Length < 100 * (2 << 10))
                {
                    continue;
                }
                BitmapImage image = null;
                try
                {
                    image = null;
                    image = new BitmapImage(new Uri(file.FullName));
                }
                catch (Exception)
                {
                }
                if (image != null)
                    yield return (image, file);
            }
        }
    }
}
