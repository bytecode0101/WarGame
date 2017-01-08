﻿using WarGame.Models.Buildings;

namespace WarGame.Wrapper
{
    class BuildingWrapper
    {
        private AbstractBuilding building;


        public BuildingWrapper(AbstractBuilding building)
        {
            Building = building;
        }

        public AbstractBuilding Building
        {
            get
            {
                return building;
            }
            set
            {
                building = value;
            }
        }

        public void Upgrade()
        {
           Building = Building.Upgrade();
        }
    }
}
