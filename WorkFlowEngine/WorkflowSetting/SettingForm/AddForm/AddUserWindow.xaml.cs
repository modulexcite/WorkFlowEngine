﻿using System;
using System.Collections.Generic;
using System.Windows;
using WorkflowSetting.Help;
using WorkFlowService.Model;
using WorkFlowService.BLL;

namespace WorkflowSetting.SettingForm.AddForm
{
    /// <summary>
    /// AddUserWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void BtnAddUserGroupClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemoveUserGroupClick(object sender, RoutedEventArgs e)
        {
            SettingHelp.RemoveItemByCondition<UserGroupModel>(LvUserGroupName, new List<string>());
        }

        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            if (!CheckInput()) return;
            var entity = GetEntity();
            var result = DataOperationBLL.Current.Insert(entity);
            if (result > 0)
                SettingHelp.AddRelationByCondition<UserGroupModel>(LvUserGroupName, UserOperationBLL.Current.AddUserInUserGroup, entity.ID);
        }

        private bool CheckInput()
        {
            bool result = true;
            if (String.Compare(PbPassword.Password, PbConfimPassword.Password, StringComparison.Ordinal) != 0)
            {
                LblConfimPasswordError.Content = "Please input same password!";
                result = false;
            }
            return result;

        }



        private UserInfoModel GetEntity()
        {
            return new UserInfoModel
                       {
                           CreateDateTime = DateTime.Now,
                           LastUpdateDateTime = DateTime.Now,
                           UserName = TxtUserName.Text,
                           Password = PbPassword.Password,
                           UserDisplayName = TxtUserDisplayName.Text
                       };
        }

        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAddUserRoleClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemoveUserRoleClick(object sender, RoutedEventArgs e)
        {
            SettingHelp.RemoveItemByCondition<RoleInfoModel>(LvUserRole, new List<string>());
        }
    }
}
