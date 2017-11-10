namespace Gajda.NovemberTests.Client.Extensions
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Windows.Threading;

    /// <summary>
    /// This class is an Observable Collection which invokes automatically.
    /// This means that any change will be done in the right thread.
    /// </summary>
    /// <typeparam name="T">The type of the elements</typeparam>
    public class DispatchingObservableCollection<T> : ObservableCollection<T>
    {
        /// <summary>
        /// The default constructor of the ObservableCollection
        /// </summary>
        public DispatchingObservableCollection()
        {
            //Assign the current Dispatcher (owner of the collection)
            this.currentDispatcher = Dispatcher.CurrentDispatcher;
        }

        private readonly Dispatcher currentDispatcher;

        /// <summary>
        /// Executes this action in the right thread
        /// </summary>
        ///<param name="action">The action which should be executed</param>
        private void DoDispatchedAction(Action action)
        {
            if (this.currentDispatcher.CheckAccess())
            {
                action.Invoke();
            }
            else
            {
                this.currentDispatcher.Invoke(DispatcherPriority.DataBind, action);
            }
        }

        /// <summary>
        /// Clears all items
        /// </summary>
        protected override void ClearItems()
        {
            this.DoDispatchedAction(this.BaseClearItems);
        }

        private void BaseClearItems()
        {
            base.ClearItems();
        }

        /// <summary>
        /// Inserts a item at the specified index
        /// </summary>
        ///<param name="index">The index where the item should be inserted</param>
        ///<param name="item">The item which should be inserted</param>
        protected override void InsertItem(int index, T item)
        {
            this.DoDispatchedAction(() => this.BaseInsertItem(index, item));
        }

        private void BaseInsertItem(int index, T item)
        {
            base.InsertItem(index, item);
        }

        /// <summary>
        /// Moves an item from one index to another
        /// </summary>
        ///<param name="oldIndex">The index of the item which should be moved</param>
        ///<param name="newIndex">The index where the item should be moved</param>
        protected override void MoveItem(int oldIndex, int newIndex)
        {
            this.DoDispatchedAction(() => this.BaseMoveItem(oldIndex, newIndex));
        }

        private void BaseMoveItem(int oldIndex, int newIndex)
        {
            base.MoveItem(oldIndex, newIndex);
        }

        /// <summary>
        /// Removes the item at the specified index
        /// </summary>
        ///<param name="index">The index of the item which should be removed</param>
        protected override void RemoveItem(int index)
        {
            this.DoDispatchedAction(() => this.BaseRemoveItem(index));
        }

        private void BaseRemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        /// <summary>
        /// Sets the item at the specified index
        /// </summary>
        ///<param name="index">The index which should be set</param>
        ///<param name="item">The new item</param>
        protected override void SetItem(int index, T item)
        {
            this.DoDispatchedAction(() => this.BaseSetItem(index, item));
        }

        private void BaseSetItem(int index, T item)
        {
            base.SetItem(index, item);
        }

        /// <summary>
        /// Fires the CollectionChanged Event
        /// </summary>
        ///<param name="e">The additional arguments of the event</param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            this.DoDispatchedAction(() => this.BaseOnCollectionChanged(e));
        }

        private void BaseOnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
        }

        /// <summary>
        /// Fires the PropertyChanged Event
        /// </summary>
        ///<param name="e">The additional arguments of the event</param>
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            this.DoDispatchedAction(() => this.BaseOnPropertyChanged(e));
        }

        private void BaseOnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }
    }
}