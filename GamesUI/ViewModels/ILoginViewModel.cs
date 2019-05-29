namespace GamesUI.ViewModels
{
    public interface ILoginViewModel
    {
        string Password { get; set; }
        string Username { get; set; }
        bool Visible { get; set; }
    }
}