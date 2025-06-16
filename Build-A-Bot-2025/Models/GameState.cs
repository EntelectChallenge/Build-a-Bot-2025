namespace BuildABot2025.Models;

public class GameState
{
    public List<Cell> Cells { get; set; }
    public List<Animal> Animals { get; set; }
    public List<Zookeeper> Zookeepers { get; set; }
    public int Tick { get; set; }
}
