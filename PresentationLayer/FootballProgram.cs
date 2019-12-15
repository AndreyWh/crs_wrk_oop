using EasyConsole;
using PresentationLayer.Pages;
using System;

namespace PresentationLayer
{
    public class FootballProgram : Program
    {
        public FootballProgram() : base("Football Application", true)
        {
            AddPage(new MainPage(this));
            AddPage(new InformationPage(this));
            AddPage(new SearchPage(this));
            AddPage(new StadiumPage(this));
            AddPage(new PlayerPage(this));
            AddPage(new GamePage(this));
            AddPage(new TeamPage(this));

            SetPage<MainPage>();
        }

        
    }
}
