﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Kanji.Database.Entities;
using Kanji.Interface.Models;

namespace Kanji.Interface.ViewModels
{
    class VocabFilterViewModel : ViewModel
    {
        #region Fields

        private VocabFilter _filter;

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets or sets the reading filter applied to the vocab list.
        /// </summary>
        public string ReadingFilter
        {
            get { return _filter.ReadingString; }
            set
            {
                if (_filter.ReadingString != value)
                {
                    _filter.ReadingString = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the meaning filter applied to the vocab list.
        /// </summary>
        public string MeaningFilter
        {
            get { return _filter.MeaningString; }
            set
            {
                if (_filter.MeaningString != value)
                {
                    _filter.MeaningString = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the category filter applied to the vocab list.
        /// </summary>
        public VocabCategory CategoryFilter
        {
            get { return _filter.Category; }
            set
            {
                if (_filter.Category != value)
                {
                    _filter.Category = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the JLPT level filter applied to the vocab list.
        /// </summary>
        public int JlptLevel
        {
            get { return _filter.JlptLevel; }
            set
            {
                if (_filter.JlptLevel != value)
                {
                    _filter.JlptLevel = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the WaniKani level filter applied to the vocab list.
        /// </summary>
        public int WkLevel
        {
            get { return _filter.WkLevel; }
            set
            {
                if (_filter.WkLevel != value)
                {
                    _filter.WkLevel = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the value defining if common vocab should be
        /// displayed before the less common results.
        /// </summary>
        public bool IsCommonFirst
        {
            get { return _filter.IsCommonFirst; }
            set
            {
                if (_filter.IsCommonFirst != value)
                {
                    _filter.IsCommonFirst = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the value defining if vocab should be sorted
        /// by ascending or descending writing length.
        /// </summary>
        public bool IsShortReadingFirst
        {
            get { return _filter.IsShortReadingFirst; }
            set
            {
                if (_filter.IsShortReadingFirst != value)
                {
                    _filter.IsShortReadingFirst = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Command used to validate the reading filter.
        /// </summary>
        public RelayCommand SendReadingFilterCommand { get; set; }

        /// <summary>
        /// Command used to validate the JLPT & WK level filters.
        /// </summary>
        /// <remarks>
        /// This is a shared command named like this because the control shared with
        /// the SRS tab wants the command to have this name.
        /// </remarks>
        public RelayCommand FilterChangedCommand { get; set; }

        /// <summary>
        /// Command used to validate the meaning filter.
        /// </summary>
        public RelayCommand SendMeaningFilterCommand { get; set; }

        /// <summary>
        /// Command used to validate the category filter.
        /// </summary>
        public RelayCommand SendCategoryFilterCommand { get; set; }
        
        /// <summary>
        /// Command used to clear the category filter.
        /// </summary>
        public RelayCommand ClearCategoryFilterCommand { get; set; }
        
        /// <summary>
        /// Command used to switch the "common first" order.
        /// </summary>
        public RelayCommand SwitchCommonOrderCommand { get; set; }

        /// <summary>
        /// Command used to switch the "writing length" order.
        /// </summary>
        public RelayCommand SwitchWritingLengthOrderCommand { get; set; }

        #endregion

        #region Events

        public delegate void FilterChangedEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Event triggered when the filter is changed.
        /// </summary>
        public event FilterChangedEventHandler FilterChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// Builds a filter view model with the given filter.
        /// </summary>
        /// <param name="filter">Filter to use.</param>
        public VocabFilterViewModel(VocabFilter filter)
        {
	        _filter = filter;
            
	        FilterChangedCommand = new RelayCommand(IssueFilterChangedEvent);
	        SendReadingFilterCommand = new RelayCommand(OnSendReadingFilter);
            SendMeaningFilterCommand = new RelayCommand(OnSendMeaningFilter);
            SendCategoryFilterCommand = new RelayCommand(OnSendCategoryFilter);
            ClearCategoryFilterCommand = new RelayCommand(OnClearCategoryFilter);
            SwitchCommonOrderCommand = new RelayCommand(OnSwitchCommonOrder);
            SwitchWritingLengthOrderCommand = new RelayCommand(OnSwitchWritingLengthOrder);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Issues a filter changed event if the event is not null.
        /// </summary>
        private void IssueFilterChangedEvent()
        {
            if (FilterChanged != null)
            {
                FilterChanged(this, new EventArgs());
            }
        }

        #region Command callbacks

        /// <summary>
        /// Command callback.
        /// Issues a filter changed event.
        /// </summary>
        private void OnSendReadingFilter()
        {
            IssueFilterChangedEvent();
        }

        /// <summary>
        /// Command callback.
        /// Issues a filter changed event.
        /// </summary>
        private void OnSendMeaningFilter()
        {
            IssueFilterChangedEvent();
        }

        /// <summary>
        /// Command callback.
        /// Issues a filter changed event.
        /// </summary>
        private void OnSendCategoryFilter()
        {
            IssueFilterChangedEvent();
        }
        
        private void OnClearCategoryFilter()
        {
            CategoryFilter = null;
            IssueFilterChangedEvent();
        }

        /// <summary>
        /// Command callback.
        /// Switches the "common first" order.
        /// </summary>
        private void OnSwitchCommonOrder()
        {
            IsCommonFirst = !IsCommonFirst;
            IssueFilterChangedEvent();
        }

        /// <summary>
        /// Command callback.
        /// Switches the "writing length" order.
        /// </summary>
        private void OnSwitchWritingLengthOrder()
        {
            IsShortReadingFirst = !IsShortReadingFirst;
            IssueFilterChangedEvent();
        }
        
        #endregion

        #endregion
    }
}
