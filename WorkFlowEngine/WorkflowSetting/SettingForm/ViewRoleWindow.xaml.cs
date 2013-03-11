﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorkflowSetting.SettingForm
{
    using WorkFlowService.BLL;
    using WorkFlowService.Model;

    /// <summary>
    /// ViewRoleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ViewRoleWindow : Window
    {
        public ViewRoleWindow()
        {
            InitializeComponent();
        }

        private void InitRoleInfo()
        {
            DgRoleList.Items.Clear();
            DgRoleList.ItemsSource = DataOperationBLL.Current.QueryAll<RoleInfoModel>();
        }
    }
}