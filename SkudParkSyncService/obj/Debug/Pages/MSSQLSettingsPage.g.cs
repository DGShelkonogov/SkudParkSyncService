#pragma checksum "..\..\..\Pages\MSSQLSettingsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "934BB157A4BF99A51E6B2CBD084C0A16AF1E1B1AB7B9F2C993177882C299AA14"
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
    /// MSSQLSettingsPage
    /// </summary>
    public partial class MSSQLSettingsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Pages\MSSQLSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbServerType;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\MSSQLSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddress;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Pages\MSSQLSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtServerName;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Pages\MSSQLSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonWindows;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Pages\MSSQLSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonNamePassword;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Pages\MSSQLSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridUserPassword;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Pages\MSSQLSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsername;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Pages\MSSQLSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\Pages\MSSQLSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtMessageLog;
        
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
            System.Uri resourceLocater = new System.Uri("/SkudParkSyncService;component/pages/mssqlsettingspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\MSSQLSettingsPage.xaml"
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
            this.cmbServerType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\Pages\MSSQLSettingsPage.xaml"
            this.cmbServerType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CmbServerTypeSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtServerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.radioButtonWindows = ((System.Windows.Controls.RadioButton)(target));
            
            #line 89 "..\..\..\Pages\MSSQLSettingsPage.xaml"
            this.radioButtonWindows.Checked += new System.Windows.RoutedEventHandler(this.radioButtonCheckedWindows);
            
            #line default
            #line hidden
            return;
            case 5:
            this.radioButtonNamePassword = ((System.Windows.Controls.RadioButton)(target));
            
            #line 97 "..\..\..\Pages\MSSQLSettingsPage.xaml"
            this.radioButtonNamePassword.Checked += new System.Windows.RoutedEventHandler(this.RadioButtonCheckedNamePassword);
            
            #line default
            #line hidden
            return;
            case 6:
            this.gridUserPassword = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.txtUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.txtMessageLog = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            
            #line 156 "..\..\..\Pages\MSSQLSettingsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClickCheckConnection);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 162 "..\..\..\Pages\MSSQLSettingsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClickAccept);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

