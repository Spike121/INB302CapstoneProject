﻿#pragma checksum "..\..\..\..\UI\ReadTextFileUC.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "176CD7B432A85DFC87C3D64FB14E258E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RecommenderAttacksAnalytics.Converters;
using RecommenderAttacksAnalytics.UI;
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


namespace RecommenderAttacksAnalytics.UI {
    
    
    /// <summary>
    /// ReadTextFileUC
    /// </summary>
    public partial class ReadTextFileUC : RecommenderAttacksAnalytics.UI.AbstractDataUploadUC, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\UI\ReadTextFileUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\UI\ReadTextFileUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox m_fileNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\UI\ReadTextFileUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button m_openFileSelectDialogBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\UI\ReadTextFileUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button m_startLoadFromFileBtn;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\UI\ReadTextFileUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar m_completionProgressBar;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\UI\ReadTextFileUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer m_outputTextBoxScroller;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\UI\ReadTextFileUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox m_outputTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/RecommenderAttacksAnalytics;component/ui/readtextfileuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\ReadTextFileUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.m_fileNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.m_openFileSelectDialogBtn = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\UI\ReadTextFileUC.xaml"
            this.m_openFileSelectDialogBtn.Click += new System.Windows.RoutedEventHandler(this.openFileSelectDialogBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.m_startLoadFromFileBtn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\UI\ReadTextFileUC.xaml"
            this.m_startLoadFromFileBtn.Click += new System.Windows.RoutedEventHandler(this.startLoadFromFileBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.m_completionProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 6:
            this.m_outputTextBoxScroller = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 7:
            this.m_outputTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

