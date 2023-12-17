using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameFramework.UI.WPF.Tools;

public class WpfTools
{
    public static T FindAncestor<T>(DependencyObject obj)
        where T : DependencyObject
    {
        if (obj != null)
        {
            var dependObj = obj;
            do
            {
                dependObj = GetParent(dependObj);
                if (dependObj is T)
                    return dependObj as T;
            } while (dependObj != null);
        }

        return null;
    }

    public static DependencyObject GetParent(DependencyObject obj)
    {
        if (obj == null)
            return null;
        if (obj is ContentElement)
        {
            var parent = ContentOperations.GetParent(obj as ContentElement);
            if (parent != null)
                return parent;
            if (obj is FrameworkContentElement)
                return (obj as FrameworkContentElement).Parent;
            return null;
        }

        return VisualTreeHelper.GetParent(obj);
    }
    
    protected IEnumerable GetDescendants(UIElement uiElement)
    {
        var result = new ArrayList
        {
            uiElement
        };

        var children = GetLogicalChildCollection<FrameworkElement>(uiElement);
        foreach (var child in children)
        {
            _ = result.Add(child);
        }
        return result;
    }

    private static List<T> GetLogicalChildCollection<T>(DependencyObject parent) where T : DependencyObject
    {
        var logicalCollection = new List<T>();
        GetLogicalChildCollection(parent, logicalCollection);
        return logicalCollection;
    }

    private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
    {
        var children = LogicalTreeHelper.GetChildren(parent);
        foreach (var child in children)
        {
            if (child is DependencyObject depChild)
            {
                if (depChild is T dependencyObject)
                {
                    logicalCollection.Add(dependencyObject);
                }
                GetLogicalChildCollection(depChild, logicalCollection);
            }
        }
    }
    public static DependencyObject? GetLogicalParent<T>(DependencyObject child) where T : DependencyObject
    {
        return LogicalTreeHelper.GetParent(child);
    }
}