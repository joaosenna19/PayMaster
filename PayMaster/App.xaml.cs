using PayMaster.Data;

namespace PayMaster;

public partial class App : Application

{
    public static HourlyEmployeeRepository Repo { get; private set; }
    public App(HourlyEmployeeRepository repo)
    {
        InitializeComponent();

        MainPage = new MainPage();
        //initializes the repository, being accessible through the whole app 
        Repo = repo;
    }
}