using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ScoreTickerApp.Annotations;
using ScoreTickerApp.Models;
using Xamarin.Forms;

namespace ScoreTickerApp.ViewModels
{
    public class ScoreTickerViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand StopScrollCommand { get; set; }
        public ObservableCollection<Score> Scores { get; set; }

        public ScoreTickerViewModel()
        {
                Scores  = new ObservableCollection<Score>(new List<Score>()
                {
                    new Score()
                    {
                        TeamA = "A",
                        TeamAScore = 4.0M,
                        TeamB = "B",
                        TeamBScore = 3.0M
                    },
                    new Score()
                    {
                        TeamA = "C",
                        TeamAScore = 2.0M,
                        TeamB = "D",
                        TeamBScore = 1.0M
                    },
                    new Score()
                    {
                    TeamA = "F",
                    TeamAScore = 0.0M,
                    TeamB = "N/A",
                    TeamBScore = -1.0M
                }
                });

                StopScrollCommand = new Command(Send, ()=>true);
        }

        private void Send()
        {
            MessagingCenter.Send(this, "Stop Scroll");
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
