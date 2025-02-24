namespace Mir4Bot
{
    public class MapManager
    {
        private Dictionary<string, MapBase> maps;

        public MapManager()
        {
            maps = new Dictionary<string, MapBase>
            {
                { "Labirinto", new LabirintoMap() },
                { "Outro Mapa", new AnotherMap() }
                // Adicione novos mapas aqui
            };
        }

        public MapBase GetMap(string mapName)
        {
            if (maps.ContainsKey(mapName))
            {
                return maps[mapName];
            }
            throw new KeyNotFoundException($"Mapa '{mapName}' não encontrado.");
        }

        public List<string> GetMapNames()
        {
            return new List<string>(maps.Keys);
        }
    }
}