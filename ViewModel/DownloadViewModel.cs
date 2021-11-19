using _4_04_DownloadManager.DownloadLogic;
using _4_04_DownloadManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_04_DownloadManager.ViewModel
{
    class DownloadViewModel
    {
        #region Properties
        List<DownloadModel> DownloadModels = new List<DownloadModel>();
        List<Downloader> Downloaders = new List<Downloader>();
        #endregion

        #region methods
        public DownloadViewModel()
        {
            for(int i=0; i<3; i++)
            {
                DownloadModel downloadModelTemp = new DownloadModel();
                DownloadModels.Add(downloadModelTemp);
                Downloaders.Add(new Downloader
                {
                    DownloadModel = downloadModelTemp
                });
            }
        }
        #endregion
    }
}
