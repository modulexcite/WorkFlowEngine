﻿using System;
using System.Collections.Generic;
using System.Windows;
using WorkFlowService.BLL;
using WorkFlowService.IDAL;
using WorkFlowService.Model;
using WorkflowSetting.Help;
using WorkflowSetting.SettingForm.SelectForm;

namespace WorkflowSetting.SettingForm.OperationForm
{
    /// <summary>
    /// AddOperationActionWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OperationActionRelationWindow : Window
    {
        public OperationActionRelationWindow(IUserOperationDAL userOperationDAL)
        {
            InitializeComponent();
            UserOperationDAL = userOperationDAL;
            InitControl();
           
        }

       private IUserOperationDAL UserOperationDAL { get; set; }

        public OperationActionRelationWindow(OperationActionInfoModel entity, OperationAction operationAction,IUserOperationDAL userOperationDAL)
           : this(userOperationDAL)
        {
            UserAction = operationAction;
            InitData(entity);
            InitControl();
        }

        private void InitData(OperationActionInfoModel entity)
        {
            TxtActionDisplayName.Text = entity.ActionDisplayName;
            TxtActionName.Text = entity.ActionName;
            TxtWorkflowName.Text = entity.WorkflowName;
            TxtWorkflowDisplayName.Text = entity.WorkflowDisplayName;
            InitProperty(entity);
            ExistUserRoleList = UserOperationDAL.QueryAllRoleByActionId(entity.Id);
            LvUserRole.Items.Clear();
            LvUserRole.ItemsSource = ExistUserRoleList;
        }

        private void InitControl()
        {
            if (UserAction == OperationAction.Add)
            {
                EnableControl(true);
                BtnAdd.Content = "Add";
                Title = "AddOperationAction";
            }
            if (UserAction == OperationAction.Modify)
            {
                EnableControl(true);
                BtnAdd.Content = "Modify";
                Title = "ModifyOperationAction";
            }
            if (UserAction == OperationAction.Read)
            {
                EnableControl(false);
                BtnAdd.Content = "Modify";
                Title = "ViewOperationAction";
            }
        }

        private void EnableControl(bool isEnable)
        {
            TxtActionDisplayName.IsReadOnly = !isEnable;
            TxtActionName.IsReadOnly = !isEnable;
            BtnAddRoleName.IsEnabled = isEnable;
            BtnRemoveRoleName.IsEnabled = isEnable;
        }

        private void BtnAddRoleNameClick(object sender, RoutedEventArgs e)
        {
            var selectRoleWindow = new SelectRoleWindow(UserOperationDAL);
            if (selectRoleWindow.ShowDialog() == false)
            {
                SettingHelp.AddEntityRange(LvUserRole, selectRoleWindow.SelectRoleInfoList);
            }
        }

        private void Read()
        {
            UserAction = OperationAction.Modify;
            InitControl();
        }

        private void Add()
        {
            var entity = GetEntity();
            if (UserOperationDAL.DataOperationInstance.Insert(entity) > 0)
            {
                InitProperty(entity);
                Id = entity.Id;
                ModifyOperationActionRole();
                LblMessage.Content = "Create successful!";
                InitControl();
            }
            else
            {
                LblMessage.Content = "Create fail";
            }
        }

        private void InitProperty(OperationActionInfoModel entity)
        {
            Id = entity.Id;
            CreateDateTime = entity.CreateDateTime;
            IsDelete = IsDelete;
        }

        private List<RoleInfoModel> ExistUserRoleList { get; set; }

        private void ModifyOperationActionRole()
        {
            SettingHelp.MoidfyListByCondition(LvUserRole, UserOperationDAL.AddUserGroupRole, UserOperationDAL.DeleteUserGroupRole, ExistUserRoleList, null, Id);
        }

        private void Modify()
        {
            ModifyEntity();
        }

        private void BtnRemoveRoleNameClick(object sender, RoutedEventArgs e)
        {
            SettingHelp.RemoveItemByCondition<RoleInfoModel>(LvUserRole);
        }

        private OperationAction UserAction { get; set; }

        private DateTime? CreateDateTime { get; set; }

        private bool IsDelete { get; set; }

        private string Id { get; set; }

        private void ModifyEntity()
        {
            var entity = GetEntity();
            if (UserOperationDAL.DataOperationInstance.Modify(entity) > 0)
            {
                LblMessage.Content = "Modify successful!";
                ModifyOperationActionRole();
            }
            else
            {
                LblMessage.Content = "Modify fail!";
            }
        }

        //private void AddEntity()
        //{
        //    var entity = GetEntity();
        //    if (UserOperationDAL.DataOperationInstance.Insert(entity) > 1)
        //        LblMessage.Content = "Create successful!";
        //    else
        //    {
        //        LblMessage.Content = "Create fail!";
        //    }
        //}

        private OperationActionInfoModel GetEntity()
        {
            if (UserAction == OperationAction.Add)
                return new OperationActionInfoModel
                {
                    CreateDateTime = DateTime.Now,
                    ActionDisplayName = TxtActionName.Text,
                    ActionName = TxtActionDisplayName.Text,
                    WorkflowName = TxtWorkflowName.Text,
                    WorkflowDisplayName = TxtWorkflowDisplayName.Text,
                    LastUpdateDateTime = DateTime.Now,
                };

            return new OperationActionInfoModel
            {
                CreateDateTime = CreateDateTime,
                IsDelete = IsDelete,
                ActionDisplayName = TxtActionName.Text,
                ActionName = TxtActionDisplayName.Text,
                WorkflowName = TxtWorkflowName.Text,
                WorkflowDisplayName = TxtWorkflowDisplayName.Text,
                Id = Id,
                LastUpdateDateTime = DateTime.Now
            };
        }

        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            if (UserAction == OperationAction.Modify)
            {
                Modify();
            }
            if (UserAction == OperationAction.Add)
            {
                Add();
            }
            if (UserAction == OperationAction.Read)
                Read();
        }

        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
