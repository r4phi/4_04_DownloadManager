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
        #region Attributes
        private string url = string.Empty;
        private string sourceCode = string.Empty;
        private TimeSpan downloadTime;
        #endregion

        #region Properties
        public string Url
        {
            get => url;
            set
            {
                url = value;
                RaisePropertyChanged();
            }
        }

        public string SourceCode
        {
            get => sourceCode;
            set
            {
                sourceCode = value;
                RaisePropertyChanged();
            }
        }

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
