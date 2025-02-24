using System.Collections.Generic;

namespace Mir4Bot
{
    public abstract class MapBase
    {
        // Propriedade virtual (pode ser sobrescrita pelas classes derivadas)
        public virtual Dictionary<string, SubMapa> SubMapas { get; set; }

        // Propriedades abstratas (devem ser implementadas pelas classes derivadas)
        public abstract List<(int x, int y)> BossCoordinates { get; }
        public abstract (int x, int y) TeleportCoordinate { get; }

        public MapBase()
        {
            SubMapas = new Dictionary<string, SubMapa>();
        }
    }
}