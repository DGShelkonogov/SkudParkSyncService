﻿using SkudParkSyncService.Models;
using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SkudParkSyncService.Pages
{
    public partial class SkudParkSyncServiceControlPage : Page
    {
        private ServiceControllerInfo _service;

        public SkudParkSyncServiceControlPage()
        {
            InitializeComponent();
            InitService();
            FillFuilds();
        }


        public void InitService()
        {
            var scServices = ServiceController.GetServices();
            var serviceController = scServices.FirstOrDefault(x => x.ServiceName.ToLower().Equals("ts2"));

            if (serviceController != null)
            {
                _service = new ServiceControllerInfo(serviceController);
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = true;
                btnFind.Visibility = Visibility.Hidden;
            }
            else
            {
                btnStart.IsEnabled = false;
                btnStop.IsEnabled = false;
                btnFind.Visibility = Visibility.Visible;
            }
        }

        public void FillFuilds()
        {
            if (_service != null)
            {
                txtServiceName.Text = _service.ServiceName;
                txtServiceStatusName.Text = _service.ServiceStatusName;
                txtServiceTypeName.Text = _service.ServiceTypeName;
            }
            else
            {
                txtServiceName.Text = "Не определено";
                txtServiceStatusName.Text = "Не определено";
                txtServiceTypeName.Text = "Не определено";
            }
        }

        private async void ButtonClickStart(object sender, RoutedEventArgs e)
        {
            if (_service.EnableStart)
            {
                await Task.Run(() => {
                    _service.Controller.Start();
                    _service.Controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                });
            }
            else
                MessageBox.Show("Службу невозможно запустить");

            FillFuilds();
        }

        private async void ButtonClickStop(object sender, RoutedEventArgs e)
        {
            if (_service.EnableStop)
            {
                await Task.Run(() => {
                    _service.Controller.Stop();
                    _service.Controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                });
            }
            else
                MessageBox.Show("Службу невозможно остановить");

            FillFuilds();
        }

        private async void ButtonClickFindService(object sender, RoutedEventArgs e)
        {
            InitService();
        }
    }
}
