﻿using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace eDaycounter
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary
    
    
    public sealed partial class MainPage : Page
    {
        DateTime ArrTime;
        
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void Date_Changed(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            if (DatePicker.SelectedDate != null)
            {
                ArrTime = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            }
           string timeString= ArrTime.ToString();
            PresentTime.Text = timeString;
           CountTime(ArrTime);
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DatePicker.SelectedDate = null;
            PresentTime.Text = string.Empty;
            
        }
        private void CountTime(DateTime SetTime)
        {
            DateTime NowTime = System.DateTime.Now;
            TimeSpan diffTime = SetTime.Subtract(NowTime);
            TimeResult.Text = "相差" + diffTime.Days.ToString() + "天";
            new ToastContentBuilder()
                .AddText("距离设定日期相差" + diffTime.Days.ToString() + "天")
                .Show();
        }

    }
}
