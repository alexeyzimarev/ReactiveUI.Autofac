namespace ReactiveUI.Autofac.Tests
{
    public class ViewA : IViewFor<ViewModelA>
    {
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ViewModelA)value; }
        }

        public ViewModelA ViewModel { get; set; }
    }

    public class ViewB : IViewFor<ViewModelB>
    {
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ViewModelB)value; }
        }

        public ViewModelB ViewModel { get; set; }
    }

    [ViewContract(Contract = "Other")]
    public class ViewC : IViewFor<ViewModelC>
    {
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ViewModelC)value; }
        }

        public ViewModelC ViewModel { get; set; }
    }
}