namespace SQLProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(global.GlobalVars.setup == false)
            {
                global.GlobalVars.Init();
            }
        }

        public void View_Click(object sender, RoutedEventArgs e)
        {
            View view = new View();
            this.Visibility = Visibility.Hidden;
            view.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete();
            this.Visibility = Visibility.Hidden;
            delete.Show();  
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Insert insert = new Insert();
            this.Visibility = Visibility.Hidden;
            insert.Show();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Create create = new Create();
            this.Visibility = Visibility.Hidden;
            create.Show();
        }
    }
}
