using System;
using System.Collections.Generic;
using LipSyncTimeLineControl.Models;

namespace LipSyncTimeLineControl.Events
{
    public class SelectionChangedEventArgs : EventArgs
    {
        public IEnumerable<TimelineTrackBase> Selected { get; }
        public IEnumerable<TimelineTrackBase> Deselected { get; }
        public SelectionChangedEventArgs(IEnumerable<TimelineTrackBase> selected, IEnumerable<TimelineTrackBase> deselected)
        {
            Selected = selected;
            Deselected = deselected;
        }
        public new static SelectionChangedEventArgs Empty => new SelectionChangedEventArgs(null, null);
    }
}