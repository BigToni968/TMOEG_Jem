
public class PlayerController : StateMachine
{
    public Player Player;

    public PlayerController(Player player)
    {
        Player = player;
    }

    public override void OnFixedUpdate()
    {
        Current.OnFixedUpdate();
    }

    public override void OnUpdate()
    {
        Current?.OnUpdate();
    }


    public override void Switch(State state)
    {
        Current?.OnFinish();
        Current = state;
        Current?.OnStart();
    }
}
