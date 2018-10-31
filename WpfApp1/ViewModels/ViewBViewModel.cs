using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Mvvm;

    using WpfApp1.Models;

    public class ViewBViewModel : BindableBase
    {
        private string x;

        private string y;

        private string answer;

        private ICalc calc;

        private string title = "ViewB";

        public ViewBViewModel(ICalc calc)
        {
            this.calc = calc;

            this.AddCommand = new DelegateCommand(this.Add, this.CanAdd)
                .ObservesProperty(() => this.X).ObservesProperty(() => this.Y);
        }

        public string X
        {
            get => this.x;
            set => this.SetProperty(ref this.x, value);
        }

        public string Y
        {
            get => this.y;
            set => this.SetProperty(ref this.y, value);
        }

        public string Answer
        {
            get => this.answer;
            set => this.SetProperty(ref this.answer, value);
        }

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        public ICommand AddCommand { get; private set; }

        private bool CanAdd() => !string.IsNullOrWhiteSpace(this.X) && !string.IsNullOrWhiteSpace(this.y);

        private void Add()
        {
            this.Answer = this.calc.Add(this.X, this.Y);
        }

    }
}
