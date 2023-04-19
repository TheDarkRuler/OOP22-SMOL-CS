namespace PlantsCreation;
using GameHitBox;

///<summary>
///Create the plats on a logical map in few different locations.
///</summary>
public class PlantsCreation
{
    //Imitation of the constants used in the java version
    const int numPlants = 4;
    const double plantHeight = 160;
    const double plantWidth = 160;
    const double borderWidth = 100;
    const double mapWidth = 1500;
    const double borderHeight = 112.5;
    const double mapHeight = 787.5;
    private bool _validPosition;
    //imitation of the list of entities.
    private List<Point2D> _entities;
    private readonly Random _rand;

    ///<summary>
    ///Constructor that initialize the entites list, random and start the creation of the plants.
    ///</summary>
    public PlantsCreation()
    {
        _entities = new List<Point2D>();
        _rand = new Random();
        CreatePlants();
    }

    public List<Point2D> Entities => _entities;

    public double PlantWidth => plantWidth;
    public double PlantHeight => plantHeight;
    public double NumPlants => numPlants;

    private void CreatePlants()
    {
        for (int i = 0; i < numPlants; i++)
        {
            Point2D? plantPosition;
            do
            {
                _validPosition = true;
                plantPosition = FindPosition(i);
                if (plantPosition == null)
                {
                    _validPosition = false;
                } else 
                {
                    IHitBox temp = new RectangleHB(plantPosition, plantWidth, plantHeight);
                    foreach (var entity in _entities)
                    {
                        if (temp.IsColliding(new RectangleHB(entity, plantWidth, plantHeight)))
                        {
                            _validPosition = false;
                        }
                    }

                }
            } while (!_validPosition);
            if (plantPosition != null)
            {
                _entities.Add(plantPosition);
            }
        }
    }

    private Point2D? FindPosition(int i)
    {
        switch (i)
        {
            case 0: 
                return new Point2D(PlantRandX(1 + borderWidth, mapWidth),
                    PlantRandY(1 + borderHeight, mapHeight));
            case 1: 
                return new Point2D(PlantRandX(1 + borderWidth + mapWidth / 2, mapWidth),
                    PlantRandY(1 + borderHeight, borderHeight + mapHeight / 2));
            case 2: 
                return new Point2D(PlantRandX(1 + borderWidth, borderWidth + mapWidth / 2),
                    PlantRandY(1 + borderHeight + mapHeight / 2, mapHeight));
            case 3: 
                return new Point2D(PlantRandX(1 + borderWidth + mapWidth / 3, borderWidth + mapWidth * 2 / 3),
                    PlantRandY(1 + borderHeight + mapHeight / 3, borderHeight + mapHeight * 2 / 3));
            default:
                return null;
        }
    }

    private double PlantRandX(double origin, double bound) =>
        origin + plantWidth / 2 + (_rand.NextDouble() * (origin + plantWidth / 2 - bound - plantWidth / 2));

    private double PlantRandY(double origin, double bound) =>
        origin + plantHeight / 2 + (_rand.NextDouble() * (origin + plantHeight / 2 - bound - plantHeight / 2));
}