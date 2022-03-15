using Unity.Entities;
[GenerateAuthoringComponent]
public struct OverScreenWarp : IComponentData
{
    // Start is called before the first frame update
    public float MaxX;
    public float MaxY;
    public float MinX;
    public float MinY;
}
