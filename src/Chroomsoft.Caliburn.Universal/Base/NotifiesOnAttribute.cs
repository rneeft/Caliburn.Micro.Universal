using System;

namespace Chroomsoft.Caliburn.Universal
{
    /// <summary>
    /// All credits goes to: http://www.codecadwallader.com/2013/04/08/inotifypropertychanged-3-of-3-without-the-reversed-notifications/
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class NotifiesOnAttribute : Attribute
    {
        public NotifiesOnAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; }
    }
}