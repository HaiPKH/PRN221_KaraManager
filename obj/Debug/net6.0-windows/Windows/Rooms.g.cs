﻿#pragma checksum "..\..\..\..\Windows\Rooms.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0D93777760A2045A9F7BF96BE504975653108F48"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KaraManager;
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


namespace KaraManager {
    
    
    /// <summary>
    /// Rooms
    /// </summary>
    public partial class Rooms : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Windows\Rooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spRoom;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Windows\Rooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomNum;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Windows\Rooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPricePerHour;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\Rooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInsert;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Windows\Rooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Windows\Rooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Windows\Rooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Windows\Rooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvRooms;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Windows\Rooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReserveRoom;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KaraManager;component/windows/rooms.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Rooms.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.spRoom = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.txtRoomNum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtPricePerHour = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnInsert = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Windows\Rooms.xaml"
            this.btnInsert.Click += new System.Windows.RoutedEventHandler(this.btnInsert_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Windows\Rooms.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Windows\Rooms.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Windows\Rooms.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lvRooms = ((System.Windows.Controls.ListView)(target));
            
            #line 29 "..\..\..\..\Windows\Rooms.xaml"
            this.lvRooms.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvRooms_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnReserveRoom = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Windows\Rooms.xaml"
            this.btnReserveRoom.Click += new System.Windows.RoutedEventHandler(this.btnReserveRoom_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

