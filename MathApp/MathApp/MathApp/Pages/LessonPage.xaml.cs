using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MathApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonPage : ContentPage
    {
        public LessonPage()
        {
            InitializeComponent();

            BindingContext = new LessonPageViewModel();
        }
    }
}