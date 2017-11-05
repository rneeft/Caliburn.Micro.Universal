﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Chroomsoft.Caliburn.Universal.Base
{
    /// <remarks>
    /// All credits for the PropertyBackingDictionary goes to: http://www.codecadwallader.com/2013/04/06/inotifypropertychanged-2-of-3-without-the-backing-fields/
    /// </remarks>
    public class PropertyHelper
    {
        private readonly Dictionary<string, object> propertyBackingDictionary = new Dictionary<string, object>();
        private readonly Action<string> notifyOfPropertyChange;
        private readonly Type type;

        public PropertyHelper(Action<string> notifyOfPropertyChange, Type type)
        {
            this.notifyOfPropertyChange = notifyOfPropertyChange;
            this.type = type;
        }

        public T GetPropertyValue<T>([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException("propertyName");

            if (propertyBackingDictionary.TryGetValue(propertyName, out object value))
                return (T)value;

            return default(T);
        }

        public bool SetPropertyValue<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            var set = SetPropertyValueSilent(newValue, propertyName);
            if (set)
                RaisePropertyChanged(propertyName);

            return set;
        }

        public bool SetPropertyValueSilent<T>(T newValue, string propertyName)
        {
            if (propertyName == null) throw new ArgumentNullException("propertyName");

            if (EqualityComparer<T>.Default.Equals(newValue, GetPropertyValue<T>(propertyName))) return false;

            propertyBackingDictionary[propertyName] = newValue;
            return true;
        }

        private ILookup<string, string> _dependentLookup;

        private ILookup<string, string> DependentLookup
        {
            get
            {
                return _dependentLookup ?? (_dependentLookup = (from p in type.GetProperties()
                                                                let attrs = p.GetCustomAttributes(typeof(NotifiesOnAttribute), false)
                                                                from NotifiesOnAttribute a in attrs
                                                                select new { Independent = a.Name, Dependent = p.Name }).ToLookup(i => i.Independent, d => d.Dependent));
            }
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException("propertyName");

            if (notifyOfPropertyChange != null)
            {
                notifyOfPropertyChange(propertyName);
                foreach (var dependentPropertyName in DependentLookup[propertyName])
                    RaisePropertyChanged(dependentPropertyName);
            }
        }
    }
}