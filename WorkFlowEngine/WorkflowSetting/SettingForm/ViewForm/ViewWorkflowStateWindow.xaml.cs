﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkFlowService.BLL;
using WorkFlowService.Model;
using WorkflowSetting.Help;
using WorkflowSetting.SettingForm.OperationForm;

namespace WorkflowSetting.SettingForm.ViewForm
{
    /// <summary>
    /// ViewWorkflowStateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ViewWorkflowStateWindow : Window
    {
        public ViewWorkflowStateWindow()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            DgWorkflowState.Items.Clear();
            DgWorkflowState.ItemsSource = UserOperationBLL.Current.DataOperationInstance.QueryAll<WorkflowStateInfoModel>();
            DgWorkflowState.SelectionChanged += DgWorkflowStateSelectionChanged;
        }

        private void DgWorkflowStateSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (WorkflowStateInfoModel item in DgWorkflowState.SelectedItems)
            {
                DgWorkflowStateSelectEntity = item;
                break;
            }
        }

        private WorkflowStateInfoModel DgWorkflowStateSelectEntity { get; set; }

        private void RowEditClick(object sender, RoutedEventArgs e)
        {
            //if (DgWorkflowStateSelectEntity == null) return;
            //var editUserGroupWindow = new UserGroupRelationWindow(DgWorkflowStateSelectEntity, OperationAction.Modify);
            //editUserGroupWindow.ShowDialog();
        }

        private void RowDeleteClick(object sender, RoutedEventArgs e)
        {
            if (DgWorkflowStateSelectEntity == null) return;
            //UserOperationBLL.Current.DataOperationInstance.Remove<RoleInfoModel>(DgUserSelectEntity.Id);
        }

        private void RowAddNewClick(object sender, RoutedEventArgs e)
        {
            //var addUserGroupWindow = new UserGroupRelationWindow();
            //addUserGroupWindow.Show();
        }
    }
}
