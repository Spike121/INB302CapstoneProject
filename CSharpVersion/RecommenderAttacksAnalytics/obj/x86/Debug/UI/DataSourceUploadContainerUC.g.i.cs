﻿#pragma checksum "..\..\..\..\UI\DataSourceUploadContainerUC.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "881D654D83DCD2542263F9A4DCAD635C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
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
    /// DataSourceUploadContainerUC
    /// </summary>
    public partial class DataSourceUploadContainerUC : RecommenderAttacksAnalytics.UI.AbstractAppPageUC, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton m_textFileOptionRadioButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton m_databaseOptionRadioButton;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox m_areFakeProfilesFromSameSourceCheckbox;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveToDbButton;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextPageBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/RecommenderAttacksAnalytics;component/ui/datasourceuploadcontaineruc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
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
            this.m_textFileOptionRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 43 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
            this.m_textFileOptionRadioButton.Click += new System.Windows.RoutedEventHandler(this.textFileOptionRadioButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.m_databaseOptionRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 44 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
            this.m_databaseOptionRadioButton.Click += new System.Windows.RoutedEventHandler(this.databaseOptionRadioButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.m_areFakeProfilesFromSameSourceCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.saveToDbButton = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
            this.saveToDbButton.Click += new System.Windows.RoutedEventHandler(this.saveToDbButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.nextPageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\UI\DataSourceUploadContainerUC.xaml"
            this.nextPageBtn.Click += new System.Windows.RoutedEventHandler(this.nextPageBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

