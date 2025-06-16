using BuildABot2025.Enums;
using BuildABot2025.Models;

namespace BuildABot2025.Services;

public class BotService
{
    private Guid _botId;

    public void SetBotId(Guid botId)
    {
        _botId = botId;
    }

    public Guid GetBotId()
    {
        return _botId;
    }

    public BotCommand ProcessState(GameState gameState)
    {
        var bot = gameState.Animals.FirstOrDefault(a => a.Id == _botId);
        var command = new BotCommand
        {
            Action = BotAction.Right // placeholder logic
        };

        if (bot != null)
        {
            Console.WriteLine($"Tick: {gameState.Tick}");
            Console.WriteLine($"Bot Position: ({bot.X}, {bot.Y})");
            Console.WriteLine($"Planned Action: {command.Action}");
        }

        return command;
    }
}
