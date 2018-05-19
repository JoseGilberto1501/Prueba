﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto.ViewModel;

namespace Proyecto.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuration : ContentPage
    {
        public Configuration()
        {
            InitializeComponent();
            BindingContext =  LoginViewModel.GetInstance();
        }
    }
}