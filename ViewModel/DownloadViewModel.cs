using _4_04_DownloadManager.DownloadLogic;
using _4_04_DownloadManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _4_04_DownloadManager.ViewModel
{
    class DownloadViewModel
    {
        #region Constants
        private const int AMOUNT_OF_LIST_ITEMS = 3;
        #endregion

        #region Properties
        public List<DownloadModel> DownloadModels { get; } = new List<DownloadModel>();
        private List<Downloader> Downloaders = new List<Downloader>();
        private List<Thread> Threads = new List<Thread>();
        #endregion

        #region Methods
        public DownloadViewModel()
        {
            InitializeProperties();

            ExitCommand = new RelayCommand(e =>
            {
                foreach(Thread thread in Threads)
                {
                    if(thread != null)
                    {
                        if (thread.IsAlive)
                            thread.Abort();
                    }
                }
                System.Environment.Exit(0);
            }, c => true);

            StartCommand = new RelayCommand(e =>
            {
                for(int i = 0; i<AMOUNT_OF_LIST_ITEMS; i++)
                {
                    if (DownloadModels[i].Url == string.Empty)
                        continue;
                    else
                    {
                        Threads[i] = new Thread(new ThreadStart(Downloaders[i].RunDownload));
                        Threads[i].Start();
                    }
                }
            }, c => Downloader.NumberOfActiveDownloaders == 0);
        }

        private void InitializeProperties()
        {
            for (int i = 0; i < AMOUNT_OF_LIST_ITEMS; i++)
            {
                DownloadModel downloadModelTemp = new DownloadModel();
                DownloadModels.Add(downloadModelTemp);
                Downloaders.Add(new Downloader
                {
                    DownloadModel = downloadModelTemp
                });
                Thread threadTemp = null;
                Threads.Add(threadTemp);
            }
        }
        #endregion

        #region Commands
        public ICommand ExitCommand { get; private set; }
        public ICommand StartCommand { get; private set; }
        #endregion
    }
}
