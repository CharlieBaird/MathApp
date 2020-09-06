using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMath.Forms;
using Xamarin.Forms;

namespace MathApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            for (var i = 0; i < 20; i++)
            {
                StackLayout.Children.Add(new MathView
                {
                    LaTeX = @"a^p=1",
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Beige
                });
            }
        }
    }
}