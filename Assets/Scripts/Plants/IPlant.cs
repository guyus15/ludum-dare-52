public interface IPlant
{
    void Harvest(); //If the plant is not in a harvestable state do nothing, otherwise invoke functions that destroys this plant and drops related items
    

    //Have global event that calls advanceStage(); every 10 seconds.
    //Increase/decrease stages required to be fully grown for each plant
}
