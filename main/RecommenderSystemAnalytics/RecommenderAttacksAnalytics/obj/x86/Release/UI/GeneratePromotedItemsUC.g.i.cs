﻿#pragma checksum "..\..\..\..\UI\GeneratePromotedItemsUC.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "938BB01400C9648DEE7B4F2094315719"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RecommenderAttacksAnalytics.Converters;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
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
    /// GeneratePromotedItemsUC
    /// </summary>
    public partial class GeneratePromotedItemsUC : RecommenderAttacksAnalytics.UI.AbstractAppPageUC, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox m_itemSelectionListBox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox m_selectRandomItemsTextBox;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button m_selectRandomItemsBtn;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox m_fakeProfilesCountInput;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton m_randomizedFillingBtn;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton m_targetedFillingBtn;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox m_saveFilenameTextBox;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button m_generateBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/RecommenderAttacksAnalytics;component/ui/generatepromoteditemsuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
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
            this.m_itemSelectionListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.m_selectRandomItemsTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.m_selectRandomItemsBtn = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
            this.m_selectRandomItemsBtn.Click += new System.Windows.RoutedEventHandler(this.selectRandomItemsBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.m_fakeProfilesCountInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.m_randomizedFillingBtn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.m_targetedFillingBtn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.m_saveFilenameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.m_generateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 154 "..\..\..\..\UI\GeneratePromotedItemsUC.xaml"
            this.m_generateBtn.Click += new System.Windows.RoutedEventHandler(this.generateBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

