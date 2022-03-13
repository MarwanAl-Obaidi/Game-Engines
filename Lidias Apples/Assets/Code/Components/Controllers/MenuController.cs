public class MenuController : Controller
{
    public Menu m_menu = null;

    public override void Start()
    {
        base.Start();
    }

    public override void StartScene()
    {
        Game.OnDownRelease += Game_OnDownRelease;
        Game.OnUpRelease += Game_OnUpRelease;
        Game.OnAccept += Game_OnAccept;
    }

    public override void StopScene()
    {
        Game.OnDownRelease -= Game_OnDownRelease;
        Game.OnUpRelease -= Game_OnUpRelease;
        Game.OnAccept -= Game_OnAccept;
    }

    private void Game_OnAccept()
    {
        m_menu.AcceptSelection();
    }

    private void Game_OnUpRelease()
    {
        m_menu.PreviousSelection();
    }

    private void Game_OnDownRelease()
    {
        m_menu.NextSelection();
    }
}
