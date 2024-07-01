namespace ExamenP3v2.Views;

public partial class JokesPage : ContentPage
{
    public JokesPage()
    {
        InitializeComponent();
        BindingContext = new JokesViewModel();
    }
}
