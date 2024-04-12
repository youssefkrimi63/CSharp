interface IFuel
{
    string FuelType {get;set;}
    int FuelTotal {get;set;}
    void GiveFuel(int Amount);
}