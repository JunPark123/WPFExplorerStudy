using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Support.Local.Helpers
{
    public class NavigatorService
    {
        private Stack<Memento> backStack = new Stack<Memento>();
        private Stack<Memento> forwardStack = new Stack<Memento>();
        public FileInfoBase currentLocation;

        public FileInfoBase Current => currentLocation;
        public event EventHandler<LocationChangedEventArgs> LocationChanged;

        public void ChangeLocation(FileInfoBase newLocation)
        {
            if (currentLocation != null)
            {
                SaveState();
            }
            currentLocation = newLocation;
            OnLocationChanged(new LocationChangedEventArgs(currentLocation));
        }

        public void GoBack() //뒤로가기 backstack의 요소가 하나라도 존재하면 
        {
            if (backStack.Any())
            {
                ReStoreState(backStack, forwardStack);
            }
        }
        public void GoForward()
        {
            if (forwardStack.Any())
            {
                ReStoreState(forwardStack, backStack);
            }
        }

        public void GoToParent()
        {
            DirectoryInfo? parentDir = Directory.GetParent(currentLocation.FullPath);

            if (parentDir != null)
            {
                ChangeLocation(new FileInfoBase { FullPath = parentDir.FullName });
            }
        }

        private void SaveState()
        {
            backStack.Push(new Memento(currentLocation.FullPath));
        }
        private void ReStoreState(Stack<Memento> popFrom, Stack<Memento> pushTo)
        {
            pushTo.Push(new Memento(currentLocation.FullPath));
            currentLocation.FullPath = popFrom.Pop().GetSavedFullPath();
            OnLocationChanged(new LocationChangedEventArgs(currentLocation));
        }

        protected virtual void OnLocationChanged(LocationChangedEventArgs e)
        {
            LocationChanged?.Invoke(this, e);
        }
    }
}
