﻿using KaraManager.Model;
using Microsoft.EntityFrameworkCore;
using System;
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

namespace KaraManager.Windows
{
    /// <summary>
    /// Interaction logic for CreateAdmin.xaml
    /// </summary>
    public partial class CreateAdmin : Window
    {
        
        public CreateAdmin()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KaraManagerContext context = new KaraManagerContext();
                Account account = new Account();
                account.Username = txtAdminName.Text;
                account.Password = pwdAdmin.Password;
                account.Role = "admin";
                if(context.Accounts.Where(a => a.Username == account.Username).Any())
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show(
                        "Account already existed, would you like to update the password of the existing account?", "Warning",
                        MessageBoxButton.YesNo);
                    if(messageBoxResult == MessageBoxResult.Yes)
                    {
                        context.Entry<Account>(account).State = EntityState.Modified;
                        context.SaveChanges();
                        MessageBox.Show("Successfully updated", "Success");
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();
                    MessageBox.Show("Successfully added", "Success");
                }
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred", "Warning");
            }
            
        }
    }
}
