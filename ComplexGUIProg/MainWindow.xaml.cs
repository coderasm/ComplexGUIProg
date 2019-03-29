using System.Windows;

namespace ComplexGUIProg
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    ComplexModel complexModel = new ComplexModel();
    public MainWindow()
    {
      InitializeComponent();
      DataContext = complexModel;
    }

    private void PowerSubmit(object sender, RoutedEventArgs e)
    {
      complexModel.EvaluatePower();
    }

    private void OperationsSubmit(object sender, RoutedEventArgs e)
    {
      complexModel.EvaluateOperations();
    }
  }
}
