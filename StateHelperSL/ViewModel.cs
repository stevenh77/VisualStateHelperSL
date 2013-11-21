namespace StateHelperSL
{
    public class ViewModel : PropertyChangedBase
    {
        private string state;

        public ViewModel()
        {
            State = "Normal";
        }

        public string State
        {
            get { return this.state; }
            set
            {
                if (state == value) return;
                this.state = value;
                NotifyOfPropertyChange("State");
            }
        }
    }
}