﻿#pragma checksum "..\..\..\..\Views\InvoiceDetailsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4CEE37D5C65139D533DE9AC5266FA796452A0E76"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using InvoiceRegister.WPF.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace InvoiceRegister.WPF.Views {
    
    
    /// <summary>
    /// InvoiceDetailsWindow
    /// </summary>
    public partial class InvoiceDetailsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 195 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ErrorText;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.FontAwesome NameWarning;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.FontAwesome AmountWarning;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.FontAwesome PriceWarning;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.FontAwesome VATWarning;
        
        #line default
        #line hidden
        
        
        #line 265 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid InvoiceItemsGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InvoiceRegister.WPF;component/views/invoicedetailswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
            ((InvoiceRegister.WPF.Views.InvoiceDetailsWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.InvoiceDetailsWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 81 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeStatus_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 95 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GeneratePDF_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 104 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteInvoice_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ErrorText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.NameWarning = ((FontAwesome.WPF.FontAwesome)(target));
            return;
            case 7:
            this.AmountWarning = ((FontAwesome.WPF.FontAwesome)(target));
            return;
            case 8:
            this.PriceWarning = ((FontAwesome.WPF.FontAwesome)(target));
            return;
            case 9:
            this.VATWarning = ((FontAwesome.WPF.FontAwesome)(target));
            return;
            case 10:
            
            #line 245 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddInvoiceItem_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.InvoiceItemsGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 12:
            
            #line 270 "..\..\..\..\Views\InvoiceDetailsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteInvoiceItem_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

