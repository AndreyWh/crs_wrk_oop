using EasyConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Pages
{
    class MainPage : MenuPage
    {
        public MainPage(FootballProgram program) : base("Main page", program)
        {
            Menu.Add(new Option("Information page", () => program.NavigateTo<InformationPage>()));
            Menu.Add(new Option("Search page", () => program.NavigateTo<SearchPage>()));
            Menu.Add(new Option("Players page", () => program.NavigateTo<PlayerPage>()));
            Menu.Add(new Option("Teams page", () => program.NavigateTo<TeamPage>()));
            Menu.Add(new Option("Games page", () => program.NavigateTo<GamePage>()));
            Menu.Add(new Option("Stadiums page", () => program.NavigateTo<StadiumPage>()));
        }
    }
}
