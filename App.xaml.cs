using MAUIPlayListAnimation.Features;

namespace MAUIPlayListAnimation;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		//MainPage = new StudentCardFilePage();
	}
}
