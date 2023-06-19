namespace ThingyDexer.ViewModel.Cult
{
    public class CultMembersViewModel : ViewModelBase, IDisposable
    {

        public CultMembersViewModel()
        {
            // Members.CollectionChanged += Members_CollectionChanged;
        }

        public Func<int> GetBudget { get; internal set; }
        public Action<int> SetBudget { get; internal set; }

        private void Members_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            //{
            //    CultRitualViewModel[] newItems = (e.NewItems?.Cast<CultRitualViewModel>() ?? new List<CultRitualViewModel>()).ToArray();
            //    RitualsCount += newItems.Length;
            //}
            //if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            //{
            //    CultRitualViewModel[] removedItems = (e.OldItems?.Cast<CultRitualViewModel>() ?? new List<CultRitualViewModel>()).ToArray();
            //    RitualsCount -= removedItems.Length;
            //}
        }

        //public ObservableCollection<CultRitualViewModel> Rituals { get; } = new();

        #region Disposable
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    // if (Members is not null)
                    // {
                    //     Members.CollectionChanged -= Members_CollectionChanged;
                    // }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CultRitualsViewModel()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Disposable
    }
}
