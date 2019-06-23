using System.Collections.Generic;
using Game;

namespace Application
{
    public static class ApplicationConstants
    {
        public static readonly Dictionary<TypesPrefabs, string> TypesPrefabsNames = new Dictionary<TypesPrefabs, string>
        {
            {TypesPrefabs.Food, "Food"},
            {TypesPrefabs.Gems, "Gems"},
            {TypesPrefabs.Liquids, "Liquids"},
            {TypesPrefabs.Metals, "Metals"},
            {TypesPrefabs.Plants, "Plants"},
            {TypesPrefabs.ChemicalElements, "Chemical elements"}
        };
    }
}