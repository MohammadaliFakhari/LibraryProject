﻿#pragma checksum "..\..\..\..\Resources\Windows\Employee.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A862933F088622B99E5A220F8C7DCBA1D015CE4FEA094810B8290E57C6C5C5F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Library_Project.Resources.Windows;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Library_Project.Resources.Windows {
    
    
    /// <summary>
    /// Employee
    /// </summary>
    public partial class Employee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border HomePan;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BookPan;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem HomePn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem BooksPn;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem MyBookPn;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem WalletPn;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem AccountPn;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMin;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Resources\Windows\Employee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSeting;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Library_Project;component/resources/windows/employee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Resources\Windows\Employee.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.HomePan = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.BookPan = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.HomePn = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 35 "..\..\..\..\Resources\Windows\Employee.xaml"
            this.HomePn.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.HomePn_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BooksPn = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 41 "..\..\..\..\Resources\Windows\Employee.xaml"
            this.BooksPn.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.BooksPn_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MyBookPn = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 6:
            this.WalletPn = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 7:
            this.AccountPn = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 8:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\Resources\Windows\Employee.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnMin = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\Resources\Windows\Employee.xaml"
            this.btnMin.Click += new System.Windows.RoutedEventHandler(this.btnMin_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnSeting = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

