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
using WorkFlowService.IDAL;
using WorkFlowService.Model;

namespace WorkflowSetting.SettingForm.SelectForm
{
    /// <summary>
    /// SelectActionWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelectActionWindow : Window
    {
        public SelectActionWindow(IUserOperationDAL userOperationDAL)
        {
            InitializeComponent();
            UserOperationDAL = userOperationDAL;
            InitData();
            
        }

        private void InitData()
        {
            InitLvOperationActionData();
            SelectActionList = new List<OperationActionInfoModel>();
        }

        private IUserOperationDAL UserOperationDAL { get; set; }

        private void InitLvOperationActionData()
        {
            var entityList = UserOperationDAL.DataOperationInstance.QueryAll<OperationActionInfoModel>();
            LvOperationAction.Items.Clear();
            LvOperationAction.ItemsSource = entityList;
            LvOperationAction.SelectionChanged += LvOperationActionSelectionChanged;
        }

        private void LvOperationActionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectActionList.Clear();
            foreach (OperationActionInfoModel item in LvOperationAction.SelectedItems)
            {
                SelectActionList.Add(item);
            }
        }

        public List<OperationActionInfoModel> SelectActionList;

        private void BtnSelectClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            SelectActionList = new List<OperationActionInfoModel>();
            Close();
        }
    }
}
