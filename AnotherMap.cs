namespace Mir4Bot
{
    public class AnotherMap : MapBase
    {
        // Implementação das propriedades abstratas
        public override Dictionary<string, SubMapa> SubMapas { get; set; }
        public override List<(int x, int y)> BossCoordinates { get; }
        public override (int x, int y) TeleportCoordinate { get; }

        public AnotherMap()
        {
            // Inicializa os submapas de outro mapa (exemplo)
            SubMapas = new Dictionary<string, SubMapa>
            {
                {
                    "Area1", new SubMapa
                    {
                        BossCoordinates = new List<(int x, int y)>
                        {
                            (100, 200), // Boss 1
                            (150, 250)  // Boss 2
                        },
                        TeleportCoordinate = (300, 300),
                        SubMapaCoordinate = (400, 400) // Coordenada da área 1
                    }
                }
            };

            // Inicializa as propriedades abstratas
            BossCoordinates = new List<(int x, int y)>();
            TeleportCoordinate = (0, 0);
        }
    }
}