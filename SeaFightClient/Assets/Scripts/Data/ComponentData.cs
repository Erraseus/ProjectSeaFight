using System.Collections.Generic;
using UnityEngine;

public class ComponentData : MonoBehaviour
{
    public List<ShipSO> ships = new List<ShipSO>();
    public List<CannonSO> cannons = new List<CannonSO>();
    public List<SailSO> sails = new List<SailSO>();
    public List<CrewSO> crewMembers = new List<CrewSO>();
    public List<CannonballSO> cannonballs = new List<CannonballSO>();
}