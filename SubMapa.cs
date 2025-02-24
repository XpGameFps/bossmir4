namespace Mir4Bot
{
    public class SubMapa
    {
        public List<(int x, int y)> BossCoordinates { get; set; }
        public (int x, int y) TeleportCoordinate { get; set; }
        public (int x, int y) SubMapaCoordinate { get; set; } // Coordenada do submapa
    }
}