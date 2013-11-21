using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading;

namespace StateHelperSL
{
    public interface INotifyPropertyChangedEx : INotifyPropertyChanged    
    {        
        bool IsNotifying { get; set; }        
        
        void NotifyOfPropertyChange(string propertyName);        
        
        void Refresh();    
    }    

    public class PropertyChangedBase : INotifyPropertyChangedEx    
    {
        public PropertyChangedBase()
        {
            IsNotifying = true;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };        
        
        public bool IsNotifying { get; set; }

        public void Refresh()
        {
            NotifyOfPropertyChange(string.Empty);
        }

        public virtual void NotifyOfPropertyChange(string propertyName)
        {
            if (IsNotifying)
                SynchronizationContext.Current.Post(o => RaisePropertyChangedEventCore(propertyName), null);
        }

        public virtual void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property)
        {
            NotifyOfPropertyChange(PropertySupport.ExtractPropertyName(property));
        }

        public virtual void RaisePropertyChangedEventImmediately(string propertyName)
        {
            if(IsNotifying)                
                RaisePropertyChangedEventCore(propertyName);
        }

        void RaisePropertyChangedEventCore(string propertyName)
        {
            var handler = PropertyChanged;            
            if (handler != null)                
                handler(this, new PropertyChangedEventArgs(propertyName));
        }    
    }
} 

