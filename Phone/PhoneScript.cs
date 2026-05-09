using GTA;
using System.Collections.Generic;

namespace iFruitAddon2
{
    internal static class PhoneScript
    {
        public static readonly uint CellphoneHandHash = StringHash.AtStringHash("cellphone_flashhand");

        private static readonly Dictionary<PedHash, string> _characterScaleformDict = new Dictionary<PedHash, string>() {
            { PedHash.Michael, "cellphone_ifruit" },
            { PedHash.Franklin, "cellphone_badger" },
            { PedHash.Trevor, "cellphone_facade" }
        };

        internal static Scaleform GetCurrentScaleform()
        {
            Scaleform currentPhoneScaleform;
            PedHash currentPlayerHash = PedHash.Michael;

            currentPlayerHash = iFruitAddon2.IsEnhanced ? Tools.Game.GetPlayerPedModelHash() : (PedHash)Game.Player.Character.Model.Hash;

            if (_characterScaleformDict.ContainsKey(currentPlayerHash))
            {
                // Remplacement du constructeur par RequestMovie
                currentPhoneScaleform = Scaleform.RequestMovie(_characterScaleformDict[currentPlayerHash]);
            }
            else
            {
                // Idem pour le fallback sur Michael
                currentPhoneScaleform = Scaleform.RequestMovie(_characterScaleformDict[PedHash.Michael]);
            }

            // Ta boucle d'attente existante est parfaite ici
            while (!currentPhoneScaleform.IsLoaded) Script.Yield();

            return currentPhoneScaleform;
        }

    }
}

