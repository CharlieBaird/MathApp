using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMath.Forms;
using MathApp.Util;
using Xamarin.Forms;

namespace MathApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            StackLayout.Children.Add(new MathView
            {
                LaTeX = @"a^p=1",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Beige
            });
        }

        public async Task printQueryResponse()
        {
            var response = await Query.QueryLessonsAsync();

            if (response == null) return;
            
            string s = response.classes[0].calculus[0].limits[0].question;
            
            StackLayout.Children.Add(new MathView
            {
                LaTeX = s,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Beige
            });
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await printQueryResponse();
        }
    }
}