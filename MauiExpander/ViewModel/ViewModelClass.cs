using MauiExpander;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiExpander
{
    public class ViewModelClass
    {
        #region Fields

        private ObservableCollection<InboxInfo> inboxInfo;

        #endregion

        #region Constructor

        public ViewModelClass()
        {
            ReadCommand = new Command<object>(OnReadClicked);
            DeleteCommand = new Command<object>(OnDeleteClicked);
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<InboxInfo> InboxInfo
        {
            get { return inboxInfo; }
            set { this.inboxInfo = value; }
        }

        public Command<object> ReadCommand { get; set; }
        public Command<object> DeleteCommand { get; set; }
        #endregion

        #region Methods

        private void GenerateSource()
        {
            InboxInfoRepository inboxinfo = new InboxInfoRepository();
            inboxInfo = inboxinfo.GetInboxInfo();
        }


        private void OnDeleteClicked(object obj)
        {
            var expanderItem = obj as InboxInfo;
            this.InboxInfo.Remove(expanderItem);
        }

        private void OnReadClicked(object obj)
        {
            var expanderItem = obj as InboxInfo;
            expanderItem.FontStyle = FontAttributes.None;
            expanderItem.IsExpanded = false;
        }
        #endregion
    }

}
