﻿#pragma checksum "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "331B75AB3A19262FC14C20A0C8906A946B2B2C4B8FCF1593AFB222A7020B9376"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SkudParkSyncService.Pages;
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


namespace SkudParkSyncService.Pages {
    
    
    /// <summary>
    /// SkudParkSyncServiceControlPage
    /// </summary>
    public partial class SkudParkSyncServiceControlPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtServiceName;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtServiceTypeName;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtServiceStatusName;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStart;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStop;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFind;
        
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
            System.Uri resourceLocater = new System.Uri("/SkudParkSyncService;component/pages/skudparksyncservicecontrolpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
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
            this.txtServiceName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtServiceTypeName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtServiceStatusName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btnStart = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
            this.btnStart.Click += new System.Windows.RoutedEventHandler(this.ButtonClickStart);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnStop = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
            this.btnStop.Click += new System.Windows.RoutedEventHandler(this.ButtonClickStop);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnFind = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\Pages\SkudParkSyncServiceControlPage.xaml"
            this.btnFind.Click += new System.Windows.RoutedEventHandler(this.ButtonClickFindService);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

