using System;
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

            var lessonsData = LessonsData.FromJson(response);
            
            StackLayout.Children.Add(new MathView
            {
                LaTeX = lessonsData.Lessons[0].Questions[0].Text,
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