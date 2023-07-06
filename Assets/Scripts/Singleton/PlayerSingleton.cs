using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Singleton
{
    public class PlayerSingleton
    {
        private static PlayerSingleton instance;

        // Private constructor to prevent instantiation from outside
        private PlayerSingleton()
        {
            // Initialization code
           
        }

        public static PlayerSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerSingleton();
                }
                return instance;
            }
        }

        public PlayerEntity PlayerData { get; set; } 
    }
}
