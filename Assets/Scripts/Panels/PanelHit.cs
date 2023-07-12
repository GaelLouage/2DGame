using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace Assets.Scripts.Panels
{
    public class PanelHit : PanelBase , IPanelEntity
    {

        public string PanelText { get; set; }

        protected override void DoLogic()
        {
            PanelText = @"Bienvenue à la Maison du Test de Chance !

                        Règles du jeu :
                        
                        Vous avez une chance sur dix pour arriver en haut.
                        Si vous échouez, vous retournerez au point de départ.

                        Souvenez-vous, la fortune sourit aux audacieux. Bonne chance !";
            panelText.GetComponent<TextMeshProUGUI>().text = PanelText;

        }
    }
}
