﻿#pragma checksum "..\..\AddElimination.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C53C52304C7AEAEA5A11A6C9D21545F5BE43DFE8133CA644632298FEA1050CF7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

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
using ZamianaUnitermu;


namespace ZamianaUnitermu {
    
    
    /// <summary>
    /// AddElimination
    /// </summary>
    public partial class AddElimination : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\AddElimination.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox euiA;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddElimination.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox euiB;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddElimination.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox euiCondition;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AddElimination.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox euiOperation;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AddElimination.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button euiBtnAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/ZamianaUnitermu;component/addelimination.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddElimination.xaml"
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
            this.euiA = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.euiB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.euiCondition = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.euiOperation = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.euiBtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\AddElimination.xaml"
            this.euiBtnAdd.Click += new System.Windows.RoutedEventHandler(this.cuiBtinAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

