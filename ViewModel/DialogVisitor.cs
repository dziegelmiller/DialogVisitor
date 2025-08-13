using System;

namespace DialogVisitorView.ViewModel
{
    /// <summary>
    /// ViewModel abstract base class to prevent compile-time dependency on the 
    /// functional DialogVisitor class in the View.
    /// Note that the abstract class does NOT define any dialog-specific methods.
    /// Daniel Ziegelmiller, author
    /// </summary>
    public abstract class DialogVisitor
    {
        public abstract object DynamicVisit(Object data);
    }
}
