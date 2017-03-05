using System;
using System.Collections.Generic;
using ExploreKu.DataClasses;
using ExploreKu.UnityComponents.DataProcessing;

public class ExploreKuRemoteDataTool : DataProcessTool
{
    public override Building[] GetAllBuildings()
    {
        throw new NotImplementedException();
    }

    public override Location[] GetAllLocations()
    {
        throw new NotImplementedException();
    }

    public override T[] GetAllLocationsOfType<T>(LocatableType a)
    {
        throw new NotImplementedException();
    }

    public override Building GetBuilding(int id)
    {
        throw new NotImplementedException();
    }

    public override Location GetLocation(int id)
    {
        throw new NotImplementedException();
    }

    public override T GetLocationOfType<T>(int id, LocatableType a)
    {
        throw new NotImplementedException();
    }
}