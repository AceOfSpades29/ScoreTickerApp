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
            _autoScrollCancellationToken = new CancellationTokenSource();
            AutoScroll(scores.Scores.ToList());
            
        }

        public async void AutoScroll(List<Score> scores)
        {
            await Task.Delay(TimeSpan.FromSeconds(4), _autoScrollCancellationToken.Token);
            var index = scores.IndexOf(Ticker.CurrentItem as Score);
            if (index <= 0) index = 1;
            else if (index == (scores.Count() - 1)) index = 0;
            else index += 1;
            ScrollToNextItem(scores.ElementAt(index));
            AutoScroll(scores);
            
        }

        private void ScrollToNextItem(object scoreObj)
        {
            
            var score = scoreObj as Score;
            if (score == null) return;
            Ticker.ScrollTo(score);
        }
    }
}