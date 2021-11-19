using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _4_04_DownloadManager.Model
{
    class DownloadModel : INotifyPropertyChanged
    {
        #region Properties
        private string url = string.Empty;
        public string URL
        {
            get => url;
            set
            {
                url = value;
                RaisePropertyChanged();
            }
        }

        private string sourceCode = string.Empty;
        public string SourceCode
        {
            get => sourceCode;
            set
            {
                sourceCode = value;
                RaisePropertyChanged();
            }
        }

        private TimeSpan downloadTime;
        public TimeSpan DownloadTime
        {
            get => downloadTime;
            set
            {
                downloadTime = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
