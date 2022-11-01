namespace MAUIPlayListAnimation;

public partial class MainPage : ContentPage
{
    bool expanded = false;
    double width;
    double height;
    const int animationLength = 600;
    public MainPage(MainPageViewModel mainPageViewModel)
    {
        InitializeComponent();
        this.BindingContext = mainPageViewModel;
        SizeChanged += MainPage_SizeChanged;
    }

    private void MainPage_SizeChanged(object sender, EventArgs e)
    {
        width = this.Width;
        height = this.Height;
    }
    async void BackButtonTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
    {
        new Animation
        {
            { 0, 1, new Animation (v => FourthGrid.TranslationY = v, FourthGrid.TranslationY,  60) },
            { 0, 1, new Animation (v => FourthGrid.RotationX = v, 0, 340) },

            { 0, 1, new Animation (v => ThirdGrid.TranslationY = v, -height,  10) },
            { 0, 1, new Animation (v => ThirdGrid.RotationX = v, 0, -20) },

            { 0, 1, new Animation (v => SecondGrid.TranslationY = v, -height, -40) },
            { 0, 1, new Animation (v => SecondGrid.RotationX = v, 0, -20) },

            { 0, 1, new Animation (v => FirstGrid.TranslationY = v, -height, -90) },
            { 0, 1, new Animation (v => FirstGrid.RotationX = v, 0, -20) },

            { 0, 0.5, new Animation (v => PlayListView.TranslationY = v, 0, height + 100) },
            { 0, 1, new Animation (v => ToolBarWithBackButton.TranslationY = v, 0, -100) },
            { 0.5, 1, new Animation (v => RecentPlayListView.TranslationY = v, height + height, 0) },
            { 0.5, 1, new Animation (v => ToolBar.Opacity = v, 0, 1) },

        }.Commit(this, "ResetAnimations", 16, animationLength, Easing.SinIn, repeat:() => false);
    }
    async void FourthGridTapGestureRecognizer_Tapped_Double(System.Object sender, System.EventArgs e)
    {
        if (expanded)
        {
            new Animation
            {
                { 0, 1, new Animation (v => FourthGrid.RotationX = v, -20, 0) },
                { 0, 1, new Animation (v => FourthGrid.TranslationY = v, FourthGrid.TranslationY, 0) },
                { 0, 1, new Animation (v => ThirdGrid.RotationX = v, -20, 0) },
                { 0, 1, new Animation (v => ThirdGrid.TranslationY = v, ThirdGrid.TranslationY, -20) },
                { 0, 1, new Animation (v => SecondGrid.RotationX = v, -20, 0) },
                { 0, 1, new Animation (v => SecondGrid.TranslationY = v, SecondGrid.TranslationY, -40) },
                { 0, 1, new Animation (v => FirstGrid.RotationX = v, -20, 0) },
                { 0, 1, new Animation (v => FirstGrid.TranslationY = v, FirstGrid.TranslationY, -60) },
            }.Commit(this, "BackToOriginalPosition", 16, animationLength, Easing.SinIn, repeat: () => false);
            expanded = false;
        }
    }
    async void FourthGridTapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
    {
        if(expanded)
        {
            BringUpcomingSongList();
            return;
        }
        expanded = true;
        new Animation
        {
            { 0, 1, new Animation (v => FourthGrid.RotationX = v, 0, -20) },
            { 0, 1, new Animation (v => FourthGrid.TranslationY = v, FourthGrid.TranslationY, FourthGrid.TranslationY + 60) },
            { 0, 1, new Animation (v => ThirdGrid.RotationX = v, 0, -20) },
            { 0, 1, new Animation (v => ThirdGrid.TranslationY = v, ThirdGrid.TranslationY, ThirdGrid.TranslationY + 30) },
            { 0, 1, new Animation (v => SecondGrid.RotationX = v, 0, -20) },
            { 0, 1, new Animation (v => SecondGrid.TranslationY = v, SecondGrid.TranslationY, SecondGrid.TranslationY) },
            { 0, 1, new Animation (v => FirstGrid.RotationX = v, 0, -20) },
            { 0, 1, new Animation (v => FirstGrid.TranslationY = v, FirstGrid.TranslationY, FirstGrid.TranslationY - 30) },
        }.Commit(this, "RotateAnimation", 16, animationLength, Easing.SinIn, repeat: () => false);
    }
    private void BringUpcomingSongList()
    {
        new Animation
        {
            { 0, 1, new Animation (v => FourthGrid.TranslationY = v, 0, FourthGrid.TranslationY -  200) },
            { 0, 1, new Animation (v => FourthGrid.RotationX = v, 0, -360) },
            { 0, 1, new Animation (v => ThirdGrid.TranslationY = v, 0, -height) },
            { 0, 1, new Animation (v => SecondGrid.TranslationY = v, 0, -height) },
            { 0, 1, new Animation (v => FirstGrid.TranslationY = v, 0, -height) },
            { 0, 1, new Animation (v => ToolBar.Opacity = v, 1, 0) },
            { 0, 1, new Animation (v => RecentPlayListView.TranslationY = v, 0, height + height) },

        }.Commit(this, "ChildAnimations", 16, animationLength, Easing.SinIn, (v, c) => GetPlayListView(true, false), () => false);
    }
    async private void GetPlayListView(bool v1, bool v2)
    {
        PlayListView.TranslationY = height + 100;
        PlayListView.IsVisible = true;
        await Task.WhenAll(
            PlayListView.TranslateTo(0, 0, animationLength, Easing.SinIn),
            ToolBarWithBackButton.TranslateTo(0,0, animationLength, Easing.SinIn)
       );
    }
}
