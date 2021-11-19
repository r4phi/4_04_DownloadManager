using _4_04_DownloadManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_04_DownloadManager.DownloadLogic
{
    class Downloader
    {
        #region Properties
        public DownloadModel DownloadModel { get; set; } = new DownloadModel();
        public static int NumberOfActiveDownloaders { get; private set; } = 0;
        private static object LockNumberOfActiveDownloaders = new object();
        #endregion

        #region Methods
        public void RunDownload()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            lock (LockNumberOfActiveDownloaders)
            {
                NumberOfActiveDownloaders++;
            }
            //TODO: Download Source Code
            lock (LockNumberOfActiveDownloaders)
            {
                NumberOfActiveDownloaders--;
            }
            watch.Stop();
            DownloadModel.DownloadTime = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);
        }
        #endregion
    }
}
