using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ScoreTickerApp.Models;
using ScoreTickerApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScoreTickerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreTickerView : ContentPage
    {
        private CancellationTokenSource _autoScrollCancellationToken;
        public ScoreTickerView()
        {
            InitializeComponent();
            var scores = BindingContext as ScoreTickerViewModel;
            MessagingCenter.Subscribe<ScoreTickerViewModel>(this, "Stop Scroll", IsScrolling);
            _autoScrollCancellationToken = new CancellationTokenSource();
            AutoScroll(scores.Scores.ToList(), 0);
            
        }

        public async void AutoScroll(List<Score> scores, int count)
        {
            await Task.Delay(TimeSpan.FromSeconds(4), _autoScrollCancellationToken.Token);
            if (count == scores.Count()) count = 0;
            count = ScrollToNextItem(scores.ElementAt(count), count);
            AutoScroll(scores, count);
            
        }

        private int ScrollToNextItem(object scoreObj, int index)
        {
            
            var score = scoreObj as Score;
            if (score == null) return 0;
            ticker.ScrollTo(score);
            return index + 1;
        }

        public void IsScrolling(ScoreTickerViewModel scoreTickerViewModel)
        {
            Debug.WriteLine("tap event called");
            _autoScrollCancellationToken.Cancel();
        }
    }
}