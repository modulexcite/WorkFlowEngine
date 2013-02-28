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
    using WorkFlowService.Model;
    using WorkFlowService.BLL;
    using CommonLibrary.Help;

    /// <summary>
    /// AddUserWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OperationUserWindow : Window
    {
        public OperationUserWindow()
        {
            InitializeComponent();
        }

        public OperationUserWindow(UserInfoModel entity)
            : this()
        {
            BtnOperator.Content = "Modify";
        }

        private void InitData(UserInfoModel entity)
        {
            TxtUserName.Text = entity.UserName;
            TxtUserDisplayName.Text = entity.UserDisplayName;
        }

        private void BtnOperatorClick(object sender, RoutedEventArgs e)
        {
            if (!TxtPassword.Password.Equals(TxtConfimPassword.Password))
                LblErrorMessage.Content = "Please input same password.";
            DataOperationBLL.Current.Insert(GetUserInfoEntity());
            LblErrorMessage.Content = "Create user sucessfully.";
        }

        private UserInfoModel GetUserInfoEntity()
        {
            return new UserInfoModel
            {
                CreateDateTime = DateTime.Now,
                LastUpdateDateTime = DateTime.Now,
                Password = TxtPassword.Password,
                UserDisplayName = TxtUserDisplayName.Text.Trim(),
                UserName = TxtUserName.Text
            };
        }

        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
