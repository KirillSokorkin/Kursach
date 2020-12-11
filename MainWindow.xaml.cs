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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            if (KeyText.Text==""|| KeyText.Text == null)
            {
                Error.Text = "Ошибка Ключ не задан";
            }
            else
            {
                string otvet = EvilProg.EvilEncode(UpText.Text, KeyText.Text);
                if (otvet == "Ключ")
                {
                    Error.Text = "Ошибка в задании ключа шифрования";
                }
                else
                {
                    Error.Text = "";
                    LowerText.Text = otvet;
                }
            }
            
            
        }
        private void AntiEncode_Click(object sender, RoutedEventArgs e)
        {
            string otvet = EvilProg.EvilAntiEncode(UpText.Text, KeyText.Text);
            if (otvet == "Ключ")
            {
                Error.Text = "Ошибка в задании ключа шифрования";
            }
            else
            {
                Error.Text = "";
                LowerText.Text = otvet;
            }
        }
        private void EncodeFile_Click(object sender, RoutedEventArgs e)
        {
            string start = EvilProg.EvilDownLoadText(StartPath.Text);
            if (start == "Расширение")
            {
                Error.Text = "Ошибка! Данное Расширение Файла не поддерживается";
            }
            else if (start == "Наличие")
            {
                Error.Text = "Ошибка! Данного Файла не существует";
            }
            else
            {
                Error.Text = "";
                string otvet = EvilProg.EvilEncode(start, KeyText.Text);
                if (otvet == "Ключ")
                {
                    Error.Text = "Ошибка в задании ключа шифрования";
                }
                else
                {
                    UpText.Text = start;
                    Error.Text = "";
                    LowerText.Text = otvet;
                }

            }
        }
        private void AntiEncodeFile_Click(object sender, RoutedEventArgs e)
        {
            string start = EvilProg.EvilDownLoadText(StartPath.Text);
            if (start == "Расширение")
            {
                Error.Text = "Ошибка! Данное Расширение Файла не поддерживается";
            }
            else if (start == "Наличие")
            {
                Error.Text = "Ошибка! Данного Файла не существует";
            }
            else
            {
                Error.Text = "";
                string otvet = EvilProg.EvilAntiEncode(start, KeyText.Text);
                if (otvet == "Ключ")
                {
                    Error.Text = "Ошибка в задании ключа шифрования";
                }
                else
                {
                    UpText.Text = start;
                    Error.Text = "";
                    LowerText.Text = otvet;
                }
            }
            
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Error.Text = "";
            string otvet = EvilProg.EvilUpLoadText(FinishPath.Text, LowerText.Text);
            if (otvet=="Расширение")
            {
                Error.Text = "Ошибка! Данный файл не может быть создан";
            }
        }
    }
}
