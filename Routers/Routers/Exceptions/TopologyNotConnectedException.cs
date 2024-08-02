namespace Routers.Exceptions;

/// <summary>
/// If initially not all routers were reachable by the network.
/// </summary>
public class TopologyNotConnectedException : Exception
{
    public TopologyNotConnectedException() : base() 
    { 

    }
    public TopologyNotConnectedException(string message) : base(message) 
    {
    
    }
}