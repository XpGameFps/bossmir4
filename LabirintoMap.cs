namespace Mir4Bot
{
    public class LabirintoMap : MapBase
    {
        // Implementação da propriedade abstrata BossCoordinates
        public override List<(int x, int y)> BossCoordinates { get; }

        // Implementação da propriedade abstrata TeleportCoordinate
        public override (int x, int y) TeleportCoordinate { get; }

        // Sobrescreve a propriedade SubMapas (opcional)
        public override Dictionary<string, SubMapa> SubMapas { get; set; }

        public LabirintoMap()
        {
            // Inicializa as propriedades
            BossCoordinates = new List<(int x, int y)>();
            TeleportCoordinate = (0, 0);

            // Inicializa os submapas
            SubMapas = new Dictionary<string, SubMapa>
            {
                {
                    "1F", new SubMapa
                    {
                        BossCoordinates = new List<(int x, int y)>
                        {
                            (1579, 498), // Boss 1
                            (1597, 574), // Boss 2
                            (1606, 650), // Boss 3
                            (1603, 726), // Boss 4
                            (1617, 785)  // Boss 5
                        },
                        TeleportCoordinate = (1548, 971),
                        SubMapaCoordinate = (129, 155) // Coordenada do submapa 1F
                    }
                },
                {
                    "2F", new SubMapa
                    {
                        BossCoordinates = new List<(int x, int y)>
                        {
                            (1579, 498), // Boss 1
                            (1597, 574), // Boss 2
                            (1606, 650), // Boss 3
                            (1603, 726), // Boss 4
                            (1617, 785)  // Boss 5
                        },
                        TeleportCoordinate = (1548, 971),
                        SubMapaCoordinate = (423, 155) // Coordenada do submapa 2F
                    }
                },
                {
                    "3F", new SubMapa
                    {
                        BossCoordinates = new List<(int x, int y)>
                        {
                            (1579, 498), // Boss 1
                            (1597, 574), // Boss 2
                            (1606, 650), // Boss 3
                            (1603, 726), // Boss 4
                            (1617, 785)  // Boss 5
                        },
                        TeleportCoordinate = (1548, 971),
                        SubMapaCoordinate = (697, 153) // Coordenada do submapa 3F
                    }
                }
            };
        }
    }
}