using Assets.Scripts;
using Assets.Scripts.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("Art stuff")]
    [SerializeField] private Material material;
    [SerializeField] private Material greenColor;
    [SerializeField] private GameObject influenceTile;
    [SerializeField] private GameObject resourceTile;
    [SerializeField] private GameObject cityTile;
    [SerializeField] private GameObject templeTile;
    [SerializeField] private GameObject marketTile;
    [SerializeField] private GameObject armyFigure;
    [SerializeField] private GameObject towerFigure;
    [SerializeField] private GameObject fleetFigure;

    private Camera currentCamera;
    private GameObject hoveredMapTile;

    private List<Region> Regions = new List<Region>();
    void Start()
    {
        //Land
        GenerateNumidia();
        GenerateCarthago();
        GenerateWestMavritania();
        GenerateLivia();
        GenerateEastMavritania();
        GenerateNorthKirenaika();
        GenerateSouthKirenaika();
        GenerateLowerEgypt();
        GenerateUpperEgypt();
        GenerateSynay();
        GenerateIudea();
        GenerateAravia();
        GenerateBabilon();
        GenerateSiria();
        GenerateMesopotamia();
        GenerateSkifia();
        GenerateKilikia();
        GenerateVifinia();
        GenerateAsia();
        GenerateCyprus();
        GenerateFrakia();
        GenerateMakedonia();
        GenerateRhodos();
        GenerateDakia();
        GenerateNorik();
        GenerateLombardia();
        GenerateDalmacia();
        GenerateItalia();
        GenerateApulea();
        GenerateSicilia();
        GenerateGreece();
        GenerateSardinia();
        GenerateCrit();

        //Sea
        GenerateCentralMeditarianSea();
        GenerateWestMeditarianSea();
        GenerateTirreneyenSea();
        GenerateIonicSea();
        GenerateEastMeditarianSea();
        GenerateRedSea();
        GenerateCyprysSea();
        GenerateAdriaticSea();
        GenerateAegeanSea();
        GenerateBlackSea();

        PlaceCenter();
    }

    private void PlaceCenter()
    {
        foreach (Region region in Regions)
        {
            var influence = Instantiate(influenceTile, region.Area.transform.localPosition + region.InternalPositions.InfluenceTilePosition, Quaternion.Euler(90, 0, 0));
            influence.GetComponent<MeshRenderer>().material = greenColor;

            foreach(var resources in region.InternalPositions.ResourcesPositions)
            {
                var resource = Instantiate(resourceTile, region.Area.transform.localPosition + resources.Key, Quaternion.identity);
            }

            foreach (var cities in region.InternalPositions.CitiesPositions)
            {
                var city = Instantiate(cityTile, region.Area.transform.localPosition + cities, Quaternion.identity);
            }

            if (region.InternalPositions.MarketPosition != Vector3.zero)
            {
                var market = Instantiate(marketTile, region.Area.transform.localPosition + region.InternalPositions.MarketPosition, Quaternion.identity);
            }

            if (region.InternalPositions.TemplePosition != Vector3.zero)
            {
                var temple = Instantiate(templeTile, region.Area.transform.localPosition + region.InternalPositions.TemplePosition, Quaternion.identity);
            }

            if (region.InternalPositions.ArmyPosition != Vector3.zero)
            {
                var warrior = Instantiate(armyFigure, region.Area.transform.localPosition + region.InternalPositions.ArmyPosition, Quaternion.Euler(0, -60, 0));
            }

            if (region.InternalPositions.TowerPosition != Vector3.zero)
            {
                var tower = Instantiate(towerFigure, region.Area.transform.localPosition + region.InternalPositions.TowerPosition, Quaternion.identity);
            }

            if (region.InternalPositions.FleetPosition != Vector3.zero)
            {
                var fleet = Instantiate(fleetFigure, region.Area.transform.localPosition + region.InternalPositions.FleetPosition, Quaternion.Euler(0, 0, 45));

                foreach (Transform child in fleet.transform)
                {
                    child.GetComponent<MeshRenderer>().material = greenColor;
                }
            }
        }
    }


    private void GenerateNumidia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;
        int y = 0;

        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-2, 3, y);
        positions.TowerPosition = new Vector3(-1.5f, 14, 1f);
        positions.ArmyPosition = new Vector3(-1f, 12, y);
        positions.AddResource(new Vector3(-1.7f, 5, y), Resource.Gold);
        positions.AddResource(new Vector3(-1.7f, 8.7f, y), Resource.Slaves);
        positions.MarketPosition = new Vector3(-1.5f, 1.5f, y);

        Vector3[] vertices = new Vector3[11];
        vertices[0] = new Vector3(0, y, 0);
        vertices[1] = new Vector3(0, y, 16);
        vertices[2] = new Vector3(0.5f, y, 16.2f);
        vertices[3] = new Vector3(1f, y, 16);
        vertices[4] = new Vector3(2.2f, y, 16.1f);
        vertices[5] = new Vector3(2.3f, y, 15);
        vertices[6] = new Vector3(2f, y, 13.1f);
        vertices[7] = new Vector3(2.8f, y, 9);
        vertices[8] = new Vector3(3.4f, y, 7);
        vertices[9] = new Vector3(3.4f, y, 3.4f);
        vertices[10] = new Vector3(2.8f, y, 0);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,6,7,  0,7,8,  0,8,9,  0,9,10};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Numidia";

        Regions.Add(new Region(tile, positions));
    }

    private void GenerateCarthago()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-6, 9, y);
        positions.TowerPosition = new Vector3(-6.5f, 14, 1);
        positions.ArmyPosition = new Vector3(-4f, 14, y);
        positions.AddResource(new Vector3(-5f, 11.5f, y), Resource.Incence);
        positions.AddResource(new Vector3(-7.7f, 8.7f, y), Resource.Fruits);
        positions.MarketPosition = new Vector3(-4.5f, 9, y);
        positions.AddCity(new Vector3(-6, 16, y));
        positions.TemplePosition = new Vector3(-9, 7, y); ;

        Vector3[] vertices = new Vector3[33];
        vertices[0] = new Vector3(2.2f, y, 16.2f);
        vertices[1] = new Vector3(2.3f, y, 15f);
        vertices[2] = new Vector3(3.5f, y, 6.5f);
        vertices[3] = new Vector3(5.5f, y, 6.5f);
        vertices[4] = new Vector3(6.5f, y, 6f);
        vertices[5] = new Vector3(9.5f, y, 5.5f);
        vertices[6] = new Vector3(10.7f, y, 9.1f);
        vertices[7] = new Vector3(9.5f, y, 9.6f);
        vertices[8] = new Vector3(8.7f, y, 9.6f);
        vertices[9] = new Vector3(8.2f, y, 10.2f);
        vertices[10] = new Vector3(7.3f, y, 10.2f);
        vertices[11] = new Vector3(6.8f, y, 10.8f);
        vertices[12] = new Vector3(6.9f, y, 11.5f);
        vertices[13] = new Vector3(7.2f, y, 11.5f);
        vertices[14] = new Vector3(7.7f, y, 12.1f);
        vertices[15] = new Vector3(8f, y, 12.1f);
        vertices[16] = new Vector3(8.3f, y, 12.5f);
        vertices[17] = new Vector3(8.3f, y, 13.1f);
        vertices[18] = new Vector3(7.8f, y, 14f);
        vertices[19] = new Vector3(7.2f, y, 15f);
        vertices[20] = new Vector3(8f, y, 16.1f);
        vertices[21] = new Vector3(7f, y, 16.1f);
        vertices[22] = new Vector3(7.9f, y, 16.6f);
        vertices[23] = new Vector3(7.5f, y, 16.6f);
        vertices[24] = new Vector3(6.5f, y, 16.7f);
        vertices[25] = new Vector3(6f, y, 17f);
        vertices[26] = new Vector3(5.5f, y, 17f);
        vertices[27] = new Vector3(4.7f, y, 16.8f);
        vertices[28] = new Vector3(4f, y, 16.7f);
        vertices[29] = new Vector3(3.4f, y, 16.3f);
        vertices[30] = new Vector3(2f, y, 13.1f);
        vertices[31] = new Vector3(2.8f, y, 9f);
        vertices[32] = new Vector3(3.43f, y, 7f);

        int[] tris = new int[] { 3,1,0, 3,2,1, 6,4,3, 6,5,4, 7,6,3, 8,7,3, 9,8,3, 10,9,3, 11,10,3, 11,3,0, 11,0,12, 12,0,13, 13,0,14, 14,0,15, 15,0,16, 16,0,17, 17,0,18, 18,0,19, 19,21,20, 21,22,20, 21,23,22, 19,25,24, 19,24,21, 19,26,25, 19,27,26, 19,28,27, 19,29,28, 19,0,29, 1,31,30, 1,32,31};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Carthago";

        Regions.Add(new Region(tile, positions));
    }

    private void GenerateWestMavritania()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-6, 4, y);
        positions.TowerPosition = new Vector3(-7f, 2, 1);
        positions.ArmyPosition = new Vector3(-12f, 2, y);
        positions.AddResource(new Vector3(-9f, 3f, y), Resource.Slaves);
        positions.MarketPosition = new Vector3(-5f, 1, y);

        Vector3[] vertices = new Vector3[10];
        vertices[0] = new Vector3(14.5f, y, 0f);
        vertices[1] = new Vector3(2.9f, y, 0);
        vertices[2] = new Vector3(3.5f, y, 2);
        vertices[3] = new Vector3(3.7f, y, 3.5f);
        vertices[4] = new Vector3(3.5f, y, 5.5f);
        vertices[5] = new Vector3(3.5f, y, 6.5f);
        vertices[6] = new Vector3(5.5f, y, 6.5f);
        vertices[7] = new Vector3(7.7f, y, 5.5f);
        vertices[8] = new Vector3(10.8f, y, 5f);
        vertices[9] = new Vector3(14.7f, y, 4f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  0,8,9 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "West Mavritania";

        Regions.Add(new Region(tile, positions));
    }

    private void GenerateLivia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-11, 6, y);
        positions.TowerPosition = new Vector3(-13f, 9, 1);
        positions.ArmyPosition = new Vector3(-20f, 7, 1);
        positions.AddResource(new Vector3(-15f, 6f, y), Resource.Fish);
        positions.AddResource(new Vector3(-18f, 5.6f, y), Resource.Fruits);
        positions.MarketPosition = new Vector3(-13.5f, 5.5f, y);

        Vector3[] vertices = new Vector3[11];
        vertices[0] = new Vector3(9.5f, y, 5.5f);
        vertices[1] = new Vector3(10.8f, y, 9.2f);
        vertices[2] = new Vector3(15.5f, y, 8.5f);
        vertices[3] = new Vector3(16f, y, 7.3f);
        vertices[4] = new Vector3(19.8f, y, 7f);
        vertices[5] = new Vector3(20f, y, 6.7f);
        vertices[6] = new Vector3(22f, y, 6f);
        vertices[7] = new Vector3(22.2f, y, 5.7f);
        vertices[8] = new Vector3(22.2f, y, 2.5f);
        vertices[9] = new Vector3(17f, y, 4f);
        vertices[10] = new Vector3(15f, y, 4f);

        int[] tris = new int[] { 0,1,2,  0,2,10,  10,2,3,  10,3,9,  9,3,4,  9,4,5,  9,5,6,  9,6,7,  9,7,8};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Livia";

        Regions.Add(new Region(tile, positions));
    }

    private void GenerateEastMavritania()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-21, 2, y);
        positions.TowerPosition = new Vector3(-16f, 2, 1);
        positions.ArmyPosition = new Vector3(-18f, 1.5f, y);
        positions.AddResource(new Vector3(-25.5f, 2f, y), Resource.Jems);
        positions.MarketPosition = new Vector3(-28, 1.7f, y);

        Vector3[] vertices = new Vector3[12];
        vertices[0] = new Vector3(14.8f, y, 2f);
        vertices[1] = new Vector3(14.6f, y, 4f);
        vertices[2] = new Vector3(17f, y, 4f);
        vertices[3] = new Vector3(22.5f, y, 2.6f);
        vertices[4] = new Vector3(14.5f, y, 0f);
        vertices[5] = new Vector3(31.4f, y, 0f);
        vertices[6] = new Vector3(31.1f, y, 2f);
        vertices[7] = new Vector3(29.6f, y, 3f);
        vertices[8] = new Vector3(29.5f, y, 4f);
        vertices[9] = new Vector3(29.1f, y, 4.8f);
        vertices[10] = new Vector3(23.5f, y, 2.8f);
        vertices[11] = new Vector3(26f, y, 4.2f);

        int[] tris = new int[] {0,1,2,  0,2,3,  4,0,3,  4,3,5,  3,6,5,  3,7,6,  3,8,7,  10,9,8,  10,11,9};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "East Mawritania";

        Regions.Add(new Region(tile, positions));
    }
    private void GenerateNorthKirenaika()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-26, 5, y);
        positions.TowerPosition = new Vector3(-35f, 10, 1); 
        positions.ArmyPosition = new Vector3(-24f, 8, y);
        positions.AddResource(new Vector3(-30f, 8f, y), Resource.Papirus);
        positions.MarketPosition = new Vector3(-28f, 9, y);
        positions.AddCity(new Vector3(-26f, 11f, y));
        positions.TemplePosition = new Vector3(-33f, 8, y);

        Vector3[] vertices = new Vector3[28];
        vertices[0] = new Vector3(22f, y, 2.7f);
        vertices[1] = new Vector3(22.3f, y, 4.4f);
        vertices[2] = new Vector3(22.2f, y, 5.9f);
        vertices[3] = new Vector3(23f, y, 6.2f);
        vertices[4] = new Vector3(23.6f, y, 7.2f);
        vertices[5] = new Vector3(23.5f, y, 10f);
        vertices[6] = new Vector3(24.7f, y, 11.4f);
        vertices[7] = new Vector3(26.2f, y, 11.8f);
        vertices[8] = new Vector3(27.5f, y, 11.7f);
        vertices[9] = new Vector3(27.6f, y, 11.5f);
        vertices[10] = new Vector3(28.8f, y, 11.1f);
        vertices[11] = new Vector3(30.5f, y, 11.4f);       
        vertices[12] = new Vector3(32f, y, 11f);
        vertices[13] = new Vector3(33.2f, y, 11.4f);
        vertices[14] = new Vector3(33.3f, y, 11.3f);
        vertices[15] = new Vector3(34.2f, y, 11.6f);
        vertices[16] = new Vector3(35.3f, y, 11.5f);
        vertices[17] = new Vector3(35.9f, y, 11.6f);
        vertices[18] = new Vector3(36.3f, y, 11f);
        vertices[19] = new Vector3(36.6f, y, 9.2f);
        vertices[20] = new Vector3(36.3f, y, 8.2f);
        vertices[21] = new Vector3(36.8f, y, 6.8f);
        vertices[22] = new Vector3(35.8f, y, 6.4f);
        vertices[23] = new Vector3(33.2f, y, 6.3f);
        vertices[24] = new Vector3(30.7f, y, 5.8f);
        vertices[25] = new Vector3(29.2f, y, 4.9f);
        vertices[26] = new Vector3(26f, y, 4.4f);
        vertices[27] = new Vector3(23f, y, 2.5f);



        int[] tris = new int[] {0,1,27,  1,2,27,  2,3,27,  3,4,27, 27,4,26,  4,5,26, 5,6,26,  6,7,26,  7,8,26, 8,9,26,  9,10,26, 25,26,10,  10,11,25,  24,25,11,  11,12,24,  23,24,12,  12,13,23,  13,14,23,  14,15,23,  22,23,15, 15,16,22,  16,17,22,  17,18,22, 18,19,22,  21,22,20};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "North Kirenaika";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateSouthKirenaika()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-32, 5, y);
        positions.TowerPosition = new Vector3(-36f, 6, 1);
        positions.ArmyPosition = new Vector3(-32f, 1.5f, y);
        positions.AddResource(new Vector3(-35f, 2.5f, y), Resource.Slaves);
        positions.MarketPosition = new Vector3(-38f, 2, y);

        Vector3[] vertices = new Vector3[17];
        vertices[0] = new Vector3(31.4f, y, 0f);
        vertices[1] = new Vector3(31.2f, y, 2f);
        vertices[2] = new Vector3(30.6f, y, 2.5f);
        vertices[3] = new Vector3(29.7f, y, 3f);
        vertices[4] = new Vector3(29.5f, y, 4f);
        vertices[5] = new Vector3(29.3f, y, 4.8f);
        vertices[6] = new Vector3(29.7f, y, 5f);
        vertices[7] = new Vector3(30.7f, y, 5.6f);
        vertices[8] = new Vector3(33.4f, y, 6.3f);
        vertices[9] = new Vector3(35.7f, y, 6.3f);
        vertices[10] = new Vector3(36.7f, y, 6.8f);
        vertices[11] = new Vector3(38.7f, y, 5.4f);
        vertices[12] = new Vector3(40.3f, y, 5.3f);
        vertices[13] = new Vector3(39.3f, y, 3.8f);
        vertices[14] = new Vector3(39.1f, y, 2.7f);
        vertices[15] = new Vector3(39.4f, y, 2f);
        vertices[16] = new Vector3(38.5f, y, 0f);

        int[] tris = new int[] {0,1,16,  1,15,16,  1,14,15,  1,2,14,  2,13,14,  2,3,13,  3,4,13,  4,5,13,  5,6,13,  6,7,13,  7,8,13,  8,9,13, 9,10,13,  10,11,13,  11,12,13};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "South Kirenaika";
        Regions.Add(new Region(tile, positions));
    }
    private void GenerateLowerEgypt()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-45, 7, y);
        positions.TowerPosition = new Vector3(-43f, 11, 1);
        positions.ArmyPosition = new Vector3(-36f, 11, y);
        positions.AddResource(new Vector3(-39.5f, 7f, y), Resource.Papirus);
        positions.MarketPosition = new Vector3(-42f, 8.5f, y);
        positions.AddCity(new Vector3(-39.5f, 12f, y));
        positions.AddCity(new Vector3(-40f, 10f, y));
        positions.TemplePosition = new Vector3(-42f, 6.5f, y);

        Vector3[] vertices = new Vector3[21];
        vertices[0] = new Vector3(40.3f, y, 5.3f);
        vertices[1] = new Vector3(38.7f, y, 5.4f);
        vertices[2] = new Vector3(36.8f, y, 6.8f);
        vertices[3] = new Vector3(36.3f, y, 8.2f);
        vertices[4] = new Vector3(36.6f, y, 9.2f);
        vertices[5] = new Vector3(36.3f, y, 11f);
        vertices[6] = new Vector3(35.9f, y, 11.6f);
        vertices[7] = new Vector3(37.9f, y, 11.4f);
        vertices[8] = new Vector3(38.2f, y, 11.5f);
        vertices[9] = new Vector3(40f, y, 13.3f);
        vertices[10] = new Vector3(40.5f, y, 13.5f);
        vertices[11] = new Vector3(41f, y, 13.9f);
        vertices[12] = new Vector3(43.1f, y, 14.2f);
        vertices[13] = new Vector3(43.3f, y, 12.2f);
        vertices[14] = new Vector3(44f, y, 11.5f);
        vertices[15] = new Vector3(44.8f, y, 10.2f);
        vertices[16] = new Vector3(44.8f, y, 10f);
        vertices[17] = new Vector3(46f, y, 9.5f);
        vertices[18] = new Vector3(46.8f, y, 8.8f);
        vertices[19] = new Vector3(47.1f, y, 8f);
        vertices[20] = new Vector3(48.5f, y, 6.4f);

        int[] tris = new int[] {0,1,2,  0,2,3,  0,3,4,  0,4,5,   5,6,7,  5,7,0,  7,8,0,  8,9,0,  9,10,0,  10,11,0,  11,12,0,  12,13,0,  13,14,0, 14,15,0,  15,16,0,  16,17,0,  17,18,0,  18,19,0,  19,20,0};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Lower Egypt";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateUpperEgypt()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-47, 5, y);
        positions.TowerPosition = new Vector3(-51f, 2.5f, 1);
        positions.ArmyPosition = new Vector3(-40f, 3.5f, y);
        positions.AddResource(new Vector3(-44f, 2f, y), Resource.Corn);
        positions.MarketPosition = new Vector3(-44.5f, 4f, y);
        positions.AddCity(new Vector3(-48f, 2f, y));
        positions.TemplePosition = new Vector3(-46f, 1.5f, y);

        Vector3[] vertices = new Vector3[12];
        vertices[0] = new Vector3(57f, y, 0f);
        vertices[1] = new Vector3(38.5f, y, 0f);
        vertices[2] = new Vector3(39.4f, y, 2f);
        vertices[3] = new Vector3(39.1f, y, 2.7f);
        vertices[4] = new Vector3(39.3f, y, 3.8f);
        vertices[5] = new Vector3(40.3f, y, 5.3f);
        vertices[6] = new Vector3(41.5f, y, 5.3f);
        vertices[7] = new Vector3(48.5f, y, 6.4f);
        vertices[8] = new Vector3(52.8f, y, 3.8f);
        vertices[9] = new Vector3(53f, y, 3.1f);
        vertices[10] = new Vector3(54f, y, 2.2f);
        vertices[11] = new Vector3(55.5f, y, 1.2f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  5,6,0,  0,6,11,  6,7,8,  6,8,9,  6,9,10,  6,10,11};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Upper Egypt";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateSynay()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0; 
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-47, 10.5f, y);
        positions.TowerPosition = new Vector3(-47f, 13, 1);
        positions.ArmyPosition = new Vector3(-43f, 13.5f, y);
        positions.AddResource(new Vector3(-45.5f, 12.7f, y), Resource.Livestock);
        positions.MarketPosition = new Vector3(-45.5f, 11, y);

        Vector3[] vertices = new Vector3[14];
        vertices[0] = new Vector3(43.1f, y, 14.2f);
        vertices[1] = new Vector3(43.7f, y, 14.6f);
        vertices[2] = new Vector3(43.3f, y, 13.2f);
        vertices[3] = new Vector3(44.2f, y, 14.6f);
        vertices[4] = new Vector3(43.3f, y, 12.3f);
        vertices[5] = new Vector3(44.8f, y, 15.2f);
        vertices[6] = new Vector3(47f, y, 13.5f);
        vertices[7] = new Vector3(47.5f, y, 12f);
        vertices[8] = new Vector3(44.5f, y, 11.5f);
        vertices[9] = new Vector3(44.7f, y, 10.8f);
        vertices[10] = new Vector3(45.9f, y, 10.3f);
        vertices[11] = new Vector3(46f, y, 10f);
        vertices[12] = new Vector3(47.8f, y, 10f);
        vertices[13] = new Vector3(47.5f, y, 9f);

        int[] tris = new int[] { 0,1,2,  2,1,3,  4,2,3, 4,3,5,  4,5,6,  4,6,7,  8,4,7,  9,8,7,  10,9,7,  11,10,7,  12,11,7,  13,11,12 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Synay";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateIudea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-48f, 17f, y);
        positions.TowerPosition = new Vector3(-46f, 20, 1);
        positions.ArmyPosition = new Vector3(-46f, 19f, y);
        positions.AddCity(new Vector3(-46f, 17f, y));
        positions.TemplePosition = new Vector3(-46.5f, 15, y);

        Vector3[] vertices = new Vector3[10];
        vertices[0] = new Vector3(44.7f, y, 15.2f);
        vertices[1] = new Vector3(44.5f, y, 20.5f);
        vertices[2] = new Vector3(46.1f, y, 21f);
        vertices[3] = new Vector3(47.9f, y, 21f);
        vertices[4] = new Vector3(48f, y, 19f);
        vertices[5] = new Vector3(48.2f, y, 18f);
        vertices[6] = new Vector3(48.5f, y, 17f);
        vertices[7] = new Vector3(49.2f, y, 16f);
        vertices[8] = new Vector3(50f, y, 15f);
        vertices[9] = new Vector3(47.2f, y, 13.8f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  0,8,9 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Iudea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateAravia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-56.5f, 10.5f, y);
        positions.TowerPosition = new Vector3(-48.5f, 13, 1);
        positions.ArmyPosition = new Vector3(-50f, 13f, y);
        positions.AddResource(new Vector3(-54.5f, 11.5f, y), Resource.Slaves);
        positions.MarketPosition = new Vector3(-52.5f, 14, y);

        Vector3[] vertices = new Vector3[9];
        vertices[0] = new Vector3(47.2f, y, 13.8f);
        vertices[1] = new Vector3(51f, y, 15.3f);
        vertices[2] = new Vector3(52.5f, y, 15.3f);
        vertices[3] = new Vector3(53.5f, y, 15f);
        vertices[4] = new Vector3(55.5f, y, 14.7f);
        vertices[5] = new Vector3(57.7f, y, 13.9f);
        vertices[6] = new Vector3(57.7f, y, 6f);
        vertices[7] = new Vector3(49f, y, 10.2f);
        vertices[8] = new Vector3(48f, y, 10.2f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Aravia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateBabilon()
    {

        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-57f, 17.7f, y);
        positions.TowerPosition = new Vector3(-53f, 20, 1);
        positions.ArmyPosition = new Vector3(-48.6f, 19.5f, y);
        positions.AddResource(new Vector3(-54f, 17f, y), Resource.Incence);
        positions.AddResource(new Vector3(-51f, 18.5f, y), Resource.Corn);
        positions.MarketPosition = new Vector3(-52.5f, 16, y);
        positions.AddCity(new Vector3(-56f, 16.5f, y));
        positions.TemplePosition = new Vector3(-51f, 16.5f, y);

        Vector3[] vertices = new Vector3[18];
        vertices[0] = new Vector3(57.7f, y, 18.9f);
        vertices[1] = new Vector3(57.7f, y, 14f);
        vertices[2] = new Vector3(55.1f, y, 14.8f);
        vertices[3] = new Vector3(52.3f, y, 15.3f);
        vertices[4] = new Vector3(51f, y, 15.3f);
        vertices[5] = new Vector3(50f, y, 15f);
        vertices[6] = new Vector3(48.6f, y, 17f);
        vertices[7] = new Vector3(56.5f, y, 19.8f);
        vertices[8] = new Vector3(55.2f, y, 20.7f);
        vertices[9] = new Vector3(54.2f, y, 21f);
        vertices[10] = new Vector3(53.4f, y, 21.9f);
        vertices[11] = new Vector3(52.4f, y, 21.2f);
        vertices[12] = new Vector3(51.3f, y, 21f);
        vertices[13] = new Vector3(50.3f, y, 21.2f);
        vertices[14] = new Vector3(48.2f, y, 18f);
        vertices[15] = new Vector3(48f, y, 19f);
        vertices[16] = new Vector3(47.9f, y, 21f);
        vertices[17] = new Vector3(49.5f, y, 21.5f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  6,7,0,  6,8,7,  6,9,8,  6,10,9,  6,11,10,  6,12,11,  6,13,12, 13,6,14,  13,14,15,  13,15,16,  13,16,17};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Babylon";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateSiria()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-46.2f, 28.7f, y);
        positions.TowerPosition = new Vector3(-47f, 23f, 1);
        positions.ArmyPosition = new Vector3(-48.6f, 24.5f, y);
        positions.AddResource(new Vector3(-48.5f, 25, y), Resource.Wine);
        positions.MarketPosition = new Vector3(-46.5f, 24, y);
        positions.AddCity(new Vector3(-44.5f, 24.5f, y));
        positions.TemplePosition = new Vector3(-47f, 26.5f, y);

        Vector3[] vertices = new Vector3[22];
        vertices[0] = new Vector3(51.7f, y, 23.5f);
        vertices[1] = new Vector3(53.2f, y, 21.9f);
        vertices[2] = new Vector3(51.7f, y, 21.1f);
        vertices[3] = new Vector3(50.8f, y, 21.1f);
        vertices[4] = new Vector3(49.6f, y, 21.6f);
        vertices[5] = new Vector3(47.7f, y, 21f);
        vertices[6] = new Vector3(45.7f, y, 21f);
        vertices[7] = new Vector3(44.4f, y, 20.5f);
        vertices[8] = new Vector3(44.3f, y, 21f);
        vertices[9] = new Vector3(44.5f, y, 21.5f);
        vertices[10] = new Vector3(44.5f, y, 22f);
        vertices[11] = new Vector3(44.7f, y, 22.5f);
        vertices[12] = new Vector3(44f, y, 23.3f);
        vertices[13] = new Vector3(44.2f, y, 23.7f);
        vertices[14] = new Vector3(43.8f, y, 25.4f);
        vertices[15] = new Vector3(43.5f, y, 25.9f);
        vertices[16] = new Vector3(44.2f, y, 27.2f);
        vertices[17] = new Vector3(44.2f, y, 30f);
        vertices[18] = new Vector3(51.3f, y, 25.3f);
        vertices[19] = new Vector3(48f, y, 31.8f);
        vertices[20] = new Vector3(44.5f, y, 30.6f);
        vertices[21] = new Vector3(46.5f, y, 31.1f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  0,8,9,  0,9,10,  0,10,11,  0,11,12,  0,12,13,  0,13,14, 0,14,15,  0,15,16,  0,16,17,  17,18,0,  17,19,18,  17,20,21 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Siria"; 
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateMesopotamia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-52.2f, 28.7f, y);
        positions.TowerPosition = new Vector3(-54f, 33f, 1);
        positions.ArmyPosition = new Vector3(-50f, 31f, y);
        positions.AddResource(new Vector3(-55.5f, 26, y), Resource.Livestock);
        positions.AddResource(new Vector3(-55.5f, 30, y), Resource.Slaves);
        positions.MarketPosition = new Vector3(-53f, 24, y);

        Vector3[] vertices = new Vector3[14];
        vertices[0] = new Vector3(56.7f, y, 34.8f);
        vertices[1] = new Vector3(57.7f, y, 35.4f);
        vertices[2] = new Vector3(57.7f, y, 18.9f);
        vertices[3] = new Vector3(56.7f, y, 19.6f);
        vertices[4] = new Vector3(55.7f, y, 20.5f);
        vertices[5] = new Vector3(54.7f, y, 21f);
        vertices[6] = new Vector3(54.4f, y, 21f);
        vertices[7] = new Vector3(52f, y, 23.4f);
        vertices[8] = new Vector3(51.4f, y, 25.3f);
        vertices[9] = new Vector3(55.2f, y, 34.7f);
        vertices[10] = new Vector3(53.5f, y, 34.4f);
        vertices[11] = new Vector3(50.5f, y, 32.9f);
        vertices[12] = new Vector3(49.5f, y, 32.7f);
        vertices[13] = new Vector3(48f, y, 32f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  8,9,0,  8,10,9,  8,11,10,  8,12,11,  8,13,12 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Mesopotamia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateSkifia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-52.2f, 40.7f, y);
        positions.TowerPosition = new Vector3(-51f, 35f, 1);
        positions.ArmyPosition = new Vector3(-48f, 34f, y);
        positions.AddResource(new Vector3(-51f, 37.5f, y), Resource.Gold);
        positions.MarketPosition = new Vector3(-53f, 36f, y);

        Vector3[] vertices = new Vector3[45];
        vertices[0] = new Vector3(53.4f, y, 34.5f);
        vertices[1] = new Vector3(57.5f, y, 42.5f);
        vertices[2] = new Vector3(57.5f, y, 35.5f);
        vertices[3] = new Vector3(56.8f, y, 35f);
        vertices[4] = new Vector3(55f, y, 35f);
        vertices[5] = new Vector3(51f, y, 33.2f);
        vertices[6] = new Vector3(49f, y, 32.6f); 
        vertices[7] = new Vector3(46.7f, y, 37.7f);
        vertices[8] = new Vector3(46.7f, y, 42.5f);
        vertices[9] = new Vector3(46.2f, y, 38.7f);
        vertices[10] = new Vector3(45f, y, 39.3f);
        vertices[11] = new Vector3(44f, y, 39.3f);
        vertices[12] = new Vector3(43.6f, y, 39.7f);
        vertices[13] = new Vector3(42.8f, y, 39.7f);
        vertices[14] = new Vector3(42.6f, y, 39.9f);
        vertices[15] = new Vector3(42.6f, y, 42.5f);
        vertices[16] = new Vector3(42f, y, 39.7f);
        vertices[17] = new Vector3(41.5f, y, 40.2f);
        vertices[18] = new Vector3(40.8f, y, 40f);
        vertices[19] = new Vector3(40.6f, y, 40.3f);
        vertices[20] = new Vector3(40.6f, y, 42.5f);
        vertices[21] = new Vector3(39.8f, y, 39.9f);
        vertices[22] = new Vector3(39.5f, y, 40.1f);
        vertices[23] = new Vector3(39.1f, y, 40f);
        vertices[24] = new Vector3(39f, y, 40.7f);
        vertices[25] = new Vector3(38.6f, y, 40.7f);
        vertices[26] = new Vector3(38.6f, y, 41f);
        vertices[27] = new Vector3(39f, y, 41.3f);
        vertices[28] = new Vector3(38.9f, y, 41.6f);
        vertices[29] = new Vector3(39.2f, y, 41.8f);
        vertices[30] = new Vector3(39.2f, y, 42.5f);
        vertices[31] = new Vector3(46.4f, y, 37.2f);
        vertices[32] = new Vector3(46.4f, y, 36.6f);
        vertices[33] = new Vector3(45.8f, y, 36f);
        vertices[34] = new Vector3(44.7f, y, 35.5f);
        vertices[35] = new Vector3(43.7f, y, 34.5f);
        vertices[36] = new Vector3(48f, y, 32f);
        vertices[37] = new Vector3(46f, y, 31.1f);
        vertices[38] = new Vector3(44.5f, y, 30.7f);
        vertices[39] = new Vector3(43.1f, y, 34.4f);
        vertices[40] = new Vector3(42.7f, y, 34.4f);
        vertices[41] = new Vector3(42.3f, y, 34f);
        vertices[42] = new Vector3(42f, y, 34f);
        vertices[43] = new Vector3(41.7f, y, 32f);
        vertices[44] = new Vector3(42.2f, y, 29.5f);

        int[] tris = new int[] { 0,1,2, 2,3,0,  0,5,1, 5,6,1,  6,7,1,  7,8,1,  7,9,8,  9,10,8,  10,11,8,  11,12,8,  12,13,8,  13,14,8,  14,15,8, 15,14,16,  15,16,17,  15,17,18,  15,18,19,  15,19,20,  20,19,21,  20,21,22,  20,22,23,  20,23,24,  20,24,25, 20,25,26,  20,26,27,  20,27,28,  20,28,29,  20,29,30,  7,6,31,  6,32,31,  6,33,32,  6,34,33,  6,35,34,  35,6,36, 35,36,37,  35,37,38,  35,38,39,  38,40,39,  38,41,40,  38,42,41,  38,43,42,  38,44,43};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Skifia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateKilikia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-42.2f, 28.7f, y);
        positions.TowerPosition = new Vector3(-42.5f, 27f, 1);
        positions.ArmyPosition = new Vector3(-38.5f, 26f, y);
        positions.AddResource(new Vector3(-41f, 26.5f, y), Resource.Fish);
        positions.MarketPosition = new Vector3(-38.5f, 24f, y);

        Vector3[] vertices = new Vector3[21];
        vertices[0] = new Vector3(42.2f, y, 29.5f);
        vertices[1] = new Vector3(44.2f, y, 30.4f);
        vertices[2] = new Vector3(44f, y, 30f);
        vertices[3] = new Vector3(44f, y, 27f);
        vertices[4] = new Vector3(43.2f, y, 25.4f);
        vertices[5] = new Vector3(42.6f, y, 24.7f);
        vertices[6] = new Vector3(42.2f, y, 24.7f);
        vertices[7] = new Vector3(41.9f, y, 24.3f);
        vertices[8] = new Vector3(41.6f, y, 24.5f);
        vertices[9] = new Vector3(41f, y, 23.1f);
        vertices[10] = new Vector3(40.5f, y, 22.8f);
        vertices[11] = new Vector3(40.5f, y, 28.6f);
        vertices[12] = new Vector3(39.7f, y, 27.8f);
        vertices[13] = new Vector3(40.2f, y, 22.4f);
        vertices[14] = new Vector3(39.2f, y, 22.1f);
        vertices[15] = new Vector3(38.7f, y, 22.5f);
        vertices[16] = new Vector3(38.3f, y, 22.4f);
        vertices[17] = new Vector3(37.6f, y, 22.7f);
        vertices[18] = new Vector3(37.8f, y, 24.7f);
        vertices[19] = new Vector3(38f, y, 26.4f);
        vertices[20] = new Vector3(38.7f, y, 27.35f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  0,8,9,  0,9,10,  0,10,11,  10,12,11,  10,13,12,  12,13,14, 12,14,15,  12,15,16,  12,16,17,  12,17,18,  12,18,19,  12,19,20};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Kilikia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateVifinia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-41f, 32.5f, y);
        positions.TowerPosition = new Vector3(-37.5f, 32.3f, 1);
        positions.ArmyPosition = new Vector3(-38f, 29f, y);
        positions.AddResource(new Vector3(-39f, 30.7f, y), Resource.Fish);
        positions.MarketPosition = new Vector3(-35.5f, 30f, y);

        Vector3[] vertices = new Vector3[26];
        vertices[0] = new Vector3(41.6f, y, 32f);
        vertices[1] = new Vector3(42f, y, 29.5f);
        vertices[2] = new Vector3(40.5f, y, 28.7f);
        vertices[3] = new Vector3(39f, y, 27.5f);
        vertices[4] = new Vector3(38f, y, 27.5f);
        vertices[5] = new Vector3(34f, y, 29.1f);
        vertices[6] = new Vector3(32.2f, y, 29.3f);
        vertices[7] = new Vector3(41.9f, y, 34.1f);
        vertices[8] = new Vector3(31.8f, y, 29.1f);
        vertices[9] = new Vector3(31.6f, y, 29.4f);
        vertices[10] = new Vector3(33.6f, y, 30.6f);
        vertices[11] = new Vector3(31.8f, y, 29.9f);
        vertices[12] = new Vector3(34f, y, 31.2f);
        vertices[13] = new Vector3(34.3f, y, 31.5f);
        vertices[14] = new Vector3(34.6f, y, 31.9f);
        vertices[15] = new Vector3(41.5f, y, 34.2f);
        vertices[16] = new Vector3(40.7f, y, 34f);
        vertices[17] = new Vector3(40f, y, 34.2f);
        vertices[18] = new Vector3(39f, y, 33.8f);
        vertices[19] = new Vector3(34.9f, y, 32.1f);
        vertices[20] = new Vector3(35.3f, y, 32.7f);
        vertices[21] = new Vector3(36f, y, 33.2f);
        vertices[22] = new Vector3(36.3f, y, 33.3f);
        vertices[23] = new Vector3(36.5f, y, 33.6f);
        vertices[24] = new Vector3(37f, y, 33.7f);
        vertices[25] = new Vector3(38.3f, y, 34.4f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  7,6,8,  7,8,9,  7,9,10,  9,11,10,  10,12,7,  7,12,13,  7,13,14,  7,14,15, 14,16,15,  14,17,16,  14,18,17,  18,14,19,  18,19,20,  18,20,21,  18,21,22,  18,22,23,  18,23,24,  18,24,25};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Vifinia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateAsia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-36f, 27f, y);
        positions.TowerPosition = new Vector3(-33.5f, 23f, 1);
        positions.ArmyPosition = new Vector3(-32f, 27f, y);
        positions.AddResource(new Vector3(-34f, 25f, y), Resource.Oil);
        positions.MarketPosition = new Vector3(-35.5f, 23f, y);
        positions.AddCity(new Vector3(-30f, 25f, y));
        positions.TemplePosition = new Vector3(-31.5f, 23.5f, y);

        Vector3[] vertices = new Vector3[59];
        vertices[0] = new Vector3(37.7f, y, 25.3f);
        vertices[1] = new Vector3(37.5f, y, 22.7f);
        vertices[2] = new Vector3(36.5f, y, 22.7f);
        vertices[3] = new Vector3(36.2f, y, 22.4f);
        vertices[4] = new Vector3(36.4f, y, 21.7f);
        vertices[5] = new Vector3(35.9f, y, 21.1f);
        vertices[6] = new Vector3(35.5f, y, 21f);
        vertices[7] = new Vector3(35.2f, y, 20.7f);
        vertices[8] = new Vector3(35f, y, 20.9f);
        vertices[9] = new Vector3(34.6f, y, 20.9f);
        vertices[10] = new Vector3(34.2f, y, 21.3f);
        vertices[11] = new Vector3(33.9f, y, 21.3f);
        vertices[12] = new Vector3(33.6f, y, 21.5f);
        vertices[13] = new Vector3(33.4f, y, 21.5f);
        vertices[14] = new Vector3(32.9f, y, 21.1f);
        vertices[15] = new Vector3(32.6f, y, 21.3f);
        vertices[16] = new Vector3(32.6f, y, 21.6f);
        vertices[17] = new Vector3(32.4f, y, 21.4f);
        vertices[18] = new Vector3(32.1f, y, 21.3f);
        vertices[19] = new Vector3(32.1f, y, 21.3f);
        vertices[20] = new Vector3(32.1f, y, 20.9f);
        vertices[21] = new Vector3(31.7f, y, 21f);
        vertices[22] = new Vector3(31.4f, y, 21f);
        vertices[23] = new Vector3(31.3f, y, 21.2f);
        vertices[24] = new Vector3(31.4f, y, 21.4f);
        vertices[25] = new Vector3(31.2f, y, 21.7f);
        vertices[26] = new Vector3(31.2f, y, 21.7f);
        vertices[27] = new Vector3(30.9f, y, 21.6f);
        vertices[28] = new Vector3(30.4f, y, 22f);
        vertices[29] = new Vector3(30.6f, y, 22.2f);
        vertices[30] = new Vector3(30.6f, y, 22.6f);
        vertices[31] = new Vector3(30.5f, y, 22.8f);
        vertices[32] = new Vector3(30f, y, 22.5f);
        vertices[33] = new Vector3(29.4f, y, 23.5f);
        vertices[34] = new Vector3(30.1f, y, 23.4f);
        vertices[35] = new Vector3(30.2f, y, 23.7f);
        vertices[36] = new Vector3(30.1f, y, 23.7f);
        vertices[37] = new Vector3(29.6f, y, 23.8f);
        vertices[38] = new Vector3(29.5f, y, 24.3f);
        vertices[39] = new Vector3(29.1f, y, 24.8f);
        vertices[40] = new Vector3(29f, y, 25.4f);
        vertices[41] = new Vector3(28.9f, y, 25.3f);
        vertices[42] = new Vector3(28.2f, y, 25f);
        vertices[43] = new Vector3(28.1f, y, 26.1f);
        vertices[44] = new Vector3(28.9f, y, 27.1f);
        vertices[45] = new Vector3(29.4f, y, 27.2f);
        vertices[46] = new Vector3(30.4f, y, 27.8f);
        vertices[47] = new Vector3(30.8f, y, 27.7f);
        vertices[48] = new Vector3(31.3f, y, 28f);
        vertices[49] = new Vector3(31.5f, y, 28.1f);
        vertices[50] = new Vector3(31.3f, y, 28.6f);
        vertices[51] = new Vector3(31.6f, y, 28.6f);
        vertices[52] = new Vector3(31.9f, y, 29f);
        vertices[53] = new Vector3(32.2f, y, 29f);
        vertices[54] = new Vector3(32.5f, y, 29.2f);
        vertices[55] = new Vector3(34f, y, 29f);
        vertices[56] = new Vector3(38.1f, y, 27.3f);
        vertices[57] = new Vector3(38.5f, y, 27.3f);
        vertices[58] = new Vector3(38f, y, 26.6f);

        int[] tris = new int[] { 0,1,2, 3,4,5,  3,5,6,  3,6,7,  3,7,8,  3,8,9,  3,9,10,  3,10,11,  3,11,12,  13,14,15,  13,15,16,  16,17,18, 19,20,21,  19,21,22,  19,22,23,  19,23,24, 24,16,18,  25,16,24,  26,27,28, 26,28,29, 26,29,30,  30,16,25,  30,13,16, 31,32,33,  31,33,34,  31,34,35,  35,30,31, 35,13,30,  36,37,38,  38,39,40, 40,36,38, 40,35,36, 40,13,35, 40,12,13, 40,3,12, 40,2,3, 40,0,2,  41,42,43, 41,43,44, 41,44,45, 41,45,40, 45,46,40, 46,47,40, 47,48,40, 48,0,40, 49,50,51, 51,52,53, 49,51,53, 49,53,54, 49,54,55, 48,49,0, 49,55,56, 56,57,58, 49,56,58,  49,58,0};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Asia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateCyprus()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-41.5f, 21f, y);
        positions.TowerPosition = new Vector3(-40f, 20f, 1);
        positions.ArmyPosition = new Vector3(-40f, 20f, y);
        positions.AddResource(new Vector3(-40f, 20f, y), Resource.Iron);
        positions.MarketPosition= new Vector3(-41f, 20.5f, y);

        Vector3[] vertices = new Vector3[17];
        vertices[0] = new Vector3(39.2f, y, 19.2f);
        vertices[1] = new Vector3(39.3f, y, 19.8f);
        vertices[2] = new Vector3(41.2f, y, 21f);
        vertices[3] = new Vector3(42f, y, 21f);
        vertices[4] = new Vector3(42.1f, y, 20.7f);
        vertices[5] = new Vector3(39.3f, y, 19f);
        vertices[6] = new Vector3(39.8f, y, 18.9f);
        vertices[7] = new Vector3(41.8f, y, 20.4f);
        vertices[8] = new Vector3(42.2f, y, 20.4f);
        vertices[9] = new Vector3(42.2f, y, 19.8f);
        vertices[10] = new Vector3(41.7f, y, 19.8f);
        vertices[11] = new Vector3(41.5f, y, 19.3f);
        vertices[12] = new Vector3(41.2f, y, 19.2f);
        vertices[13] = new Vector3(41.2f, y, 18.8f);
        vertices[14] = new Vector3(40.4f, y, 18.6f);
        vertices[15] = new Vector3(42f, y, 22f);
        vertices[16] = new Vector3(42.4f, y, 22f);

        int[] tris = new int[] { 0,1,2, 0,2,3,  0,3,4, 0,4,5,  5,4,6, 6,4,7,  6,7,10,  7,8,9,  7,9,10, 6,10,11, 6,11,12,  6,12,13,  6,13,14, 2,15,3, 15,16,3};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Cyprus";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateFrakia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-28f, 35f, y);
        positions.TowerPosition = new Vector3(-28.5f, 33f, 1);
        positions.ArmyPosition = new Vector3(-25f, 33f, y);
        positions.AddResource(new Vector3(-27f, 31f, y), Resource.Fish);
        positions.MarketPosition = new Vector3(-25f, 31f, y);
        positions.AddCity(new Vector3(-30f, 30f, y));
        positions.TemplePosition = new Vector3(-28.5f, 28.5f, y);

        Vector3[] vertices = new Vector3[28];
        vertices[0] = new Vector3(28f, y, 26.9f);
        vertices[1] = new Vector3(27.6f, y, 27.2f);
        vertices[2] = new Vector3(28f, y, 27.7f);
        vertices[3] = new Vector3(28.3f, y, 27.3f);
        vertices[4] = new Vector3(29.2f, y, 28f);
        vertices[5] = new Vector3(29.3f, y, 28.7f);
        vertices[6] = new Vector3(30f, y, 29f);
        vertices[7] = new Vector3(30.4f, y, 30.2f);
        vertices[8] = new Vector3(29.2f, y, 31.2f);
        vertices[9] = new Vector3(29f, y, 31.8f);
        vertices[10] = new Vector3(28.6f, y, 31.6f);
        vertices[11] = new Vector3(28.6f, y, 32f);
        vertices[12] = new Vector3(28.7f, y, 33f);
        vertices[13] = new Vector3(29f, y, 32.2f);
        vertices[14] = new Vector3(28.7f, y, 33.5f);
        vertices[15] = new Vector3(28.7f, y, 35f);
        vertices[16] = new Vector3(29.2f, y, 33.5f);
        vertices[17] = new Vector3(28.6f, y, 35.2f);
        vertices[18] = new Vector3(27.8f, y, 35.7f);
        vertices[19] = new Vector3(28.7f, y, 35.6f);
        vertices[20] = new Vector3(26f, y, 35.2f);
        vertices[21] = new Vector3(24.6f, y, 34.2f);
        vertices[22] = new Vector3(23.8f, y, 33f);
        vertices[23] = new Vector3(22.1f, y, 31f);
        vertices[24] = new Vector3(24.5f, y, 29.4f);
        vertices[25] = new Vector3(27.1f, y, 27.4f);
        vertices[26] = new Vector3(26.7f, y, 27.6f);
        vertices[27] = new Vector3(26.3f, y, 27.5f);

        int[] tris = new int[] { 0,1,2, 2,3,0, 2,4,3, 2,5,4,  5,7,6, 5,8,7, 5,9,8, 5,10,9, 2,10,5, 11,12,13, 14,15,16, 17,18,19, 17,15,18, 18,15,14, 18,14,12, 18,12,11, 20,18,11, 21,20,11, 22,21,11, 23,22,11, 23,11,10, 23,10,24, 25,10,2, 26,10,25, 27,10,26, 27,24,10 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Frakia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateMakedonia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0; 
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-22f, 26f, y);
        positions.TowerPosition = new Vector3(-25f, 28f, 1);
        positions.ArmyPosition = new Vector3(-21f, 30f, y);
        positions.AddResource(new Vector3(-23f, 28f, y), Resource.Corn);
        positions.AddResource(new Vector3(-20f, 27f, y), Resource.Wine);
        positions.MarketPosition = new Vector3(-20f, 25.5f, y);

        Vector3[] vertices = new Vector3[37];
        vertices[0] = new Vector3(25.7f, y, 26.2f);
        vertices[1] = new Vector3(26.1f, y, 25.6f);
        vertices[2] = new Vector3(26f, y, 25.3f);
        vertices[3] = new Vector3(25.8f, y, 25.6f);
        vertices[4] = new Vector3(25.65f, y, 25.45f);
        vertices[5] = new Vector3(25.8f, y, 25.3f);
        vertices[6] = new Vector3(25.5f, y, 25f);
        vertices[7] = new Vector3(25.2f, y, 25.4f);
        vertices[8] = new Vector3(24.9f, y, 25.3f);
        vertices[9] = new Vector3(25.2f, y, 25f);
        vertices[10] = new Vector3(25f, y, 24.8f);
        vertices[11] = new Vector3(24.4f, y, 25.3f);
        vertices[12] = new Vector3(24.55f, y, 25.6f);
        vertices[13] = new Vector3(25.5f, y, 26.2f);
        vertices[14] = new Vector3(25.1f, y, 26.7f);
        vertices[15] = new Vector3(24.45f, y, 25.8f);
        vertices[16] = new Vector3(24f, y, 25.7f);
        vertices[17] = new Vector3(23f, y, 25.7f);
        vertices[18] = new Vector3(25.5f, y, 26.8f);
        vertices[19] = new Vector3(25.6f, y, 27.1f);
        vertices[20] = new Vector3(26.1f, y, 27.1f);
        vertices[21] = new Vector3(26.4f, y, 27.35f);
        vertices[22] = new Vector3(24.5f, y, 29.4f);
        vertices[23] = new Vector3(22.1f, y, 30.9f);
        vertices[24] = new Vector3(19.85f, y, 31.4f);
        vertices[25] = new Vector3(19.9f, y, 31f);
        vertices[26] = new Vector3(19.5f, y, 30f);
        vertices[27] = new Vector3(18.3f, y, 28.5f);
        vertices[28] = new Vector3(17.9f, y, 27.3f);
        vertices[29] = new Vector3(18.2f, y, 26.8f);
        vertices[30] = new Vector3(18.3f, y, 26.2f);
        vertices[31] = new Vector3(18.5f, y, 25.7f);
        vertices[32] = new Vector3(18.65f, y, 24.8f);
        vertices[33] = new Vector3(22.2f, y, 25.2f);
        vertices[34] = new Vector3(21.5f, y, 24.5f);
        vertices[35] = new Vector3(19.1f, y, 24.2f);
        vertices[36] = new Vector3(20f, y, 23.7f);

        int[] tris = new int[] { 0,1,2, 0,2,3, 0,3,4, 4,5,6, 4,6,7, 0,4,7, 0,7,8, 8,9,10, 8,10,11, 11,12,8, 12,0,8, 12,13,0, 12,14,13, 12,15,14, 15,16,14, 17,14,16, 14,19,18, 19,21,20, 22,21,19, 22,19,14, 22,14,17, 22,17,23,  23,25,24, 23,26,25, 23,27,26, 23,28,27, 23,29,28, 23,30,29, 23,31,30, 23,17,31, 17,32,31, 17,33,32, 32,33,34, 32,34,35, 35,34,36};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Makedonia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateRhodos()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-32.5f, 20f, y);
        positions.TowerPosition = new Vector3(-33f, 20f, 1);
        positions.ArmyPosition = new Vector3(-33f, 20f, y);
        positions.AddCity(new Vector3(-33f, 20f, y));
        positions.TemplePosition = new Vector3(-34f, 19.5f, y);

        Vector3[] vertices = new Vector3[5];
        vertices[0] = new Vector3(32.8f, y, 19f);
        vertices[1] = new Vector3(32.3f, y, 20.4f);
        vertices[2] = new Vector3(33.4f, y, 21f);
        vertices[3] = new Vector3(33.1f, y, 18.9f);
        vertices[4] = new Vector3(34f, y, 20.5f);

        int[] tris = new int[] { 0,1,2, 0,2,3, 2,4,3 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Rhodos";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateDakia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-28f, 40f, y);
        positions.TowerPosition = new Vector3(-25f, 38f, 1);
        positions.ArmyPosition = new Vector3(-18f, 34f, y);
        positions.AddResource(new Vector3(-22f, 36f, y), Resource.Corn);
        positions.MarketPosition = new Vector3(-20f, 37f, y);

        Vector3[] vertices = new Vector3[68];
        vertices[0] = new Vector3(34.6f, y, 38.4f);
        vertices[1] = new Vector3(34.8f, y, 37.7f);
        vertices[2] = new Vector3(34.5f, y, 37.9f);
        vertices[3] = new Vector3(34.9f, y, 37.5f);
        vertices[4] = new Vector3(35.2f, y, 37.6f);
        vertices[5] = new Vector3(35.4f, y, 38.1f);
        vertices[6] = new Vector3(35.4f, y, 38.6f);
        vertices[7] = new Vector3(35.8f, y, 39f);
        vertices[8] = new Vector3(36f, y, 39.5f); 
        vertices[9] = new Vector3(33.9f, y, 38.8f);
        vertices[10] = new Vector3(33.2f, y, 39.7f); 
        vertices[11] = new Vector3(32.9f, y, 39.3f); 
        vertices[12] = new Vector3(32.9f, y, 38.9f);
        vertices[13] = new Vector3(33.4f, y, 38.7f);
        vertices[14] = new Vector3(33.1f, y, 38.5f);
        vertices[15] = new Vector3(32.7f, y, 38.6f);
        vertices[16] = new Vector3(35.8f, y, 40.2f); 
        vertices[17] = new Vector3(36.4f, y, 40.5f);
        vertices[18] = new Vector3(36.7f, y, 40.5f);
        vertices[19] = new Vector3(36.9f, y, 40.1f);
        vertices[20] = new Vector3(37.3f, y, 40.1f);
        vertices[21] = new Vector3(37.6f, y, 40.7f);
        vertices[22] = new Vector3(37.1f, y, 40.7f);
        vertices[23] = new Vector3(35.4f, y, 40.6f);
        vertices[24] = new Vector3(34.4f, y, 40.6f); 
        vertices[25] = new Vector3(33f, y, 40.4f); 
        vertices[26] = new Vector3(34.3f, y, 40.9f); 
        vertices[27] = new Vector3(31.5f, y, 40.7f); 
        vertices[28] = new Vector3(31.4f, y, 40.2f);
        vertices[29] = new Vector3(31.1f, y, 40.1f);
        vertices[30] = new Vector3(31.2f, y, 39.8f);
        vertices[31] = new Vector3(34.8f, y, 41.2f);
        vertices[32] = new Vector3(35.1f, y, 41.5f); 
        vertices[33] = new Vector3(35.1f, y, 40.8f);
        vertices[34] = new Vector3(35.5f, y, 41.1f);
        vertices[35] = new Vector3(35.2f, y, 41.7f);
        vertices[36] = new Vector3(36.5f, y, 42.5f);
        vertices[37] = new Vector3(31.5f, y, 42.5f);
        vertices[38] = new Vector3(31.3f, y, 40.9f);
        vertices[39] = new Vector3(30.1f, y, 40.2f);
        vertices[40] = new Vector3(28f, y, 42.5f);
        vertices[41] = new Vector3(30.1f, y, 39.5f);
        vertices[42] = new Vector3(29.6f, y, 39.3f);
        vertices[43] = new Vector3(29.7f, y, 38.7f);
        vertices[44] = new Vector3(29.3f, y, 38.1f);
        vertices[45] = new Vector3(28.9f, y, 36.2f);
        vertices[46] = new Vector3(29.24f, y, 37.9f);
        vertices[47] = new Vector3(29.5f, y, 37.6f);
        vertices[48] = new Vector3(29.4f, y, 36.6f);
        vertices[49] = new Vector3(29f, y, 36.26f);
        vertices[50] = new Vector3(29.3f, y, 36.54f);
        vertices[51] = new Vector3(29.2f, y, 35.9f);
        vertices[52] = new Vector3(28.7f, y, 35.7f);
        vertices[53] = new Vector3(27.7f, y, 35.8f);
        vertices[54] = new Vector3(26f, y, 35.2f);
        vertices[55] = new Vector3(25f, y, 42.5f);
        vertices[56] = new Vector3(24.5f, y, 34.2f);
        vertices[57] = new Vector3(23.8f, y, 33f);
        vertices[58] = new Vector3(22f, y, 31f);
        vertices[59] = new Vector3(20f, y, 31.4f);
        vertices[60] = new Vector3(17.5f, y, 32.4f);
        vertices[61] = new Vector3(15.3f, y, 33.7f);
        vertices[62] = new Vector3(16.8f, y, 35.3f);
        vertices[63] = new Vector3(17.2f, y, 36f);
        vertices[64] = new Vector3(17.6f, y, 37.5f);
        vertices[65] = new Vector3(19.1f, y, 39.2f);
        vertices[66] = new Vector3(19.3f, y, 41.4f);
        vertices[67] = new Vector3(18.9f, y, 42.5f);

        int[] tris = new int[] { 0,1,2, 0,3,1, 0,4,3, 0,5,4, 0,6,5, 0,7,6, 0,8,7, 0,9,8, 9,10,8, 9,11,10, 9,12,11, 9,13,12, 13,14,12, 14,15,12, 8,10,16, 16,17,8, 17,18,8, 8,18,19, 19,18,20, 20,18,21, 18,22,21, 10,23,16, 10,24,23, 10,25,24, 25,26,24, 25,27,26, 25,28,27, 25,29,28, 25,30,29, 27,31,26, 27,32,31, 31,32,33, 32,34,33, 27,35,32, 27,36,35, 27,37,36, 27,38,37, 38,39,37, 39,40,37, 40,39,41, 40,41,42, 40,42,43, 40,43,44, 40,44,45, 46,47,48, 46,48,45, 49,50,51, 40,45,52, 40,52,53, 40,53,54, 40,54,55, 55,54,56, 55,56,57, 55,57,58, 55,58,59, 55,59,60, 60,61,62, 60,62,63, 60,63,64, 60,64,65, 60,65,55, 65,66,55, 66,67,55 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Dakia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateNorik()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-16f, 40f, y);
        positions.TowerPosition = new Vector3(-10f, 38f, 1);
        positions.ArmyPosition = new Vector3(-6f, 38f, y);
        positions.AddResource(new Vector3(-13f, 39f, y), Resource.Jems);
        positions.MarketPosition = new Vector3(-15f, 37f, y);

        Vector3[] vertices = new Vector3[17];
        vertices[0] = new Vector3(2.1f, y, 42.5f);
        vertices[1] = new Vector3(10, y, 42.5f);
        vertices[2] = new Vector3(2.5f, y, 41.5f);
        vertices[3] = new Vector3(3.2f, y, 38f);
        vertices[4] = new Vector3(3.3f, y, 37.2f);
        vertices[5] = new Vector3(4.3f, y, 37f);
        vertices[6] = new Vector3(6f, y, 36.3f);
        vertices[7] = new Vector3(8.6f, y, 35.9f);
        vertices[8] = new Vector3(10f, y, 35f);
        vertices[9] = new Vector3(11.5f, y, 34.5f);
        vertices[10] = new Vector3(15.2f, y, 33.7f);
        vertices[11] = new Vector3(16.8f, y, 35.3f);
        vertices[12] = new Vector3(17.2f, y, 36.1f);
        vertices[13] = new Vector3(17.6f, y, 37.6f);
        vertices[14] = new Vector3(19.1f, y, 39.2f);
        vertices[15] = new Vector3(19.2f, y, 41.4f);
        vertices[16] = new Vector3(18.9f, y, 42.5f);

        int[] tris = new int[] { 0,1,2, 1,3,2, 1,4,3, 1,5,4, 1,6,5, 1,7,6, 1,8,7, 1,9,8, 1,10,9, 1,11,10, 1,12,11, 1,13,12, 1,14,13, 1,15,14, 1,16,15 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Norik";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateLombardia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0; 
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-3f, 31f, y);
        positions.TowerPosition = new Vector3(-2f, 36f, 1);
        positions.ArmyPosition = new Vector3(-4f, 35f, y);
        positions.AddResource(new Vector3(-7f, 34f, y), Resource.Corn);
        positions.AddResource(new Vector3(-3.5f, 33f, y), Resource.Livestock);
        positions.MarketPosition = new Vector3(-6f, 32f, y);

        Vector3[] vertices = new Vector3[38];
        vertices[0] = new Vector3(0, y, 42.5f);
        vertices[1] = new Vector3(2.1f, y, 42.5f);
        vertices[2] = new Vector3(2.5f, y, 41.5f);
        vertices[3] = new Vector3(3.2f, y, 38f);
        vertices[4] = new Vector3(3.3f, y, 37.2f);
        vertices[5] = new Vector3(0f, y, 35.2f);
        vertices[6] = new Vector3(4.3f, y, 37f);
        vertices[7] = new Vector3(6f, y, 36.3f);
        vertices[8] = new Vector3(8.6f, y, 35.9f);
        vertices[9] = new Vector3(10f, y, 35f);
        vertices[10] = new Vector3(11.5f, y, 34.5f);
        vertices[11] = new Vector3(11.6f, y, 34.3f);
        vertices[12] = new Vector3(11.3f, y, 34f);
        vertices[13] = new Vector3(10.8f, y, 33.7f);
        vertices[14] = new Vector3(8.9f, y, 33.3f); 
        vertices[15] = new Vector3(10.5f, y, 33.3f);
        vertices[16] = new Vector3(9.5f, y, 32.5f);
        vertices[17] = new Vector3(10.3f, y, 32.5f);
        vertices[18] = new Vector3(9.25f, y, 32.3f);
        vertices[19] = new Vector3(9.45f, y, 32f);
        vertices[20] = new Vector3(9.75f, y, 31.4f);
        vertices[21] = new Vector3(10.3f, y, 32f);
        vertices[22] = new Vector3(10.2f, y, 31.4f);
        vertices[23] = new Vector3(8.3f, y, 32.9f);
        vertices[24] = new Vector3(7.7f, y, 32.8f);
        vertices[25] = new Vector3(7.6f, y, 32.7f);
        vertices[26] = new Vector3(7.8f, y, 32f);
        vertices[27] = new Vector3(8f, y, 31.5f);
        vertices[28] = new Vector3(7.9f, y, 30.9f);
        vertices[29] = new Vector3(6.7f, y, 31.1f);
        vertices[30] = new Vector3(5.6f, y, 30.9f);
        vertices[31] = new Vector3(4f, y, 29.9f);
        vertices[32] = new Vector3(2.8f, y, 29.4f);
        vertices[33] = new Vector3(2.5f, y, 29.5f);
        vertices[34] = new Vector3(2f, y, 28.9f);
        vertices[35] = new Vector3(1.3f, y, 28.8f);
        vertices[36] = new Vector3(0.6f, y, 28.1f);
        vertices[37] = new Vector3(0f, y, 28f);

        int[] tris = new int[] { 0,1,2, 0,2,3, 0,3,4, 0,4,5, 5,4,6, 5,6,7, 5,7,8, 5,8,9, 5,9,10, 5,10,11, 5,11,12, 5,12,13, 5,13,14, 14,13,15, 14,15,16, 16,15,17, 16,17,18, 18,17,19, 19,17,20, 20,17,21, 20,21,22, 5,14,23, 5,23,24, 5,24,25, 5,25,26, 5,26,27, 5,27,28, 5,28,29, 5,29,30, 5,30,31, 5,31,32, 5,32,33, 5,33,34, 5,34,35, 5,35,36, 5,36,37};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Lombardia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateDalmacia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-17f, 29f, y);
        positions.TowerPosition = new Vector3(-18f, 31f, 1);
        positions.ArmyPosition = new Vector3(-13.5f, 33f, y);
        positions.AddResource(new Vector3(-15f, 31f, y), Resource.Fish);
        positions.MarketPosition = new Vector3(-13f, 31f, y);

        Vector3[] vertices = new Vector3[30];
        vertices[0] = new Vector3(11.9f, y, 30.2f);
        vertices[1] = new Vector3(11.2f, y, 31.5f);
        vertices[2] = new Vector3(12.8f, y, 29.8f); 
        vertices[3] = new Vector3(10.9f, y, 31.1f);
        vertices[4] = new Vector3(10.6f, y, 31.5f);
        vertices[5] = new Vector3(10.7f, y, 32.1f);
        vertices[6] = new Vector3(11.7f, y, 34.3f);
        vertices[7] = new Vector3(11.2f, y, 33.9f);
        vertices[8] = new Vector3(10.8f, y, 33.6f);
        vertices[9] = new Vector3(10.5f, y, 33.2f);
        vertices[10] = new Vector3(10.4f, y, 32.5f);
        vertices[11] = new Vector3(15.3f, y, 33.6f);
        vertices[12] = new Vector3(12.8f, y, 29.3f);
        vertices[13] = new Vector3(13.2f, y, 29.1f);
        vertices[14] = new Vector3(13.7f, y, 29.3f);
        vertices[15] = new Vector3(14.6f, y, 29.1f);
        vertices[16] = new Vector3(14.3f, y, 28.8f);
        vertices[17] = new Vector3(14.6f, y, 28.5f);
        vertices[18] = new Vector3(14.8f, y, 28.5f);
        vertices[19] = new Vector3(15.1f, y, 28.2f);
        vertices[20] = new Vector3(15.9f, y, 28.5f);
        vertices[21] = new Vector3(16.2f, y, 28f);
        vertices[22] = new Vector3(16.7f, y, 28f);
        vertices[23] = new Vector3(16.8f, y, 28.3f);
        vertices[24] = new Vector3(17.3f, y, 32.4f); 
        vertices[25] = new Vector3(17.8f, y, 27.2f);
        vertices[26] = new Vector3(18.2f, y, 28.5f);
        vertices[27] = new Vector3(19.4f, y, 30f);
        vertices[28] = new Vector3(19.9f, y, 31f);
        vertices[29] = new Vector3(19.8f, y, 31.4f);

        int[] tris = new int[] { 0,1,2, 1,3,4, 1,4,5, 1,5,6, 5,7,6, 5,8,7, 5,9,8, 5,10,9, 1,6,11, 1,11,2, 2,12,13, 2,13,14, 2,11,14, 14,11,15, 15,17,16, 15,18,17, 15,11,18, 11,19,18, 11,20,19, 11,21,20, 11,22,21, 11,23,22, 11,24,23, 24,25,23, 24,26,25, 24,27,26, 24,28,27, 24,29,28};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Dalmacia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateItalia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-6f, 28f, y);
        positions.TowerPosition = new Vector3(-8f, 31f, 1);
        positions.ArmyPosition = new Vector3(-9f, 28.5f, y);
        positions.AddResource(new Vector3(-7f, 29f, y), Resource.Iron);
        positions.AddResource(new Vector3(-10f, 26.5f, y), Resource.Wine);
        positions.MarketPosition = new Vector3(-5.5f, 29.5f, y);
        positions.AddCity(new Vector3(-7.5f, 27f, y));
        positions.TemplePosition = new Vector3(-10.5f, 25f, y);

        Vector3[] vertices = new Vector3[25];
        vertices[0] = new Vector3(4f, y, 29.8f);
        vertices[1] = new Vector3(5f, y, 29f);
        vertices[2] = new Vector3(3.6f, y, 29.7f);
        vertices[3] = new Vector3(5.7f, y, 30.9f);
        vertices[4] = new Vector3(5.3f, y, 29f);
        vertices[5] = new Vector3(6.8f, y, 31f);
        vertices[6] = new Vector3(7.9f, y, 30.8f);
        vertices[7] = new Vector3(8.2f, y, 30.1f);
        vertices[8] = new Vector3(5.6f, y, 28.7f); 
        vertices[9] = new Vector3(8.6f, y, 29.7f);
        vertices[10] = new Vector3(5.6f, y, 27.7f);
        vertices[11] = new Vector3(7.6f, y, 25.7f);
        vertices[12] = new Vector3(8.9f, y, 29.7f);
        vertices[13] = new Vector3(9.1f, y, 29.2f);
        vertices[14] = new Vector3(10.5f, y, 28f);
        vertices[15] = new Vector3(10.5f, y, 27.8f);
        vertices[16] = new Vector3(11f, y, 27.3f);
        vertices[17] = new Vector3(9.3f, y, 25f); 
        vertices[18] = new Vector3(11.5f, y, 27.1f);
        vertices[19] = new Vector3(12f, y, 26.5f);
        vertices[20] = new Vector3(11.5f, y, 25.7f);
        vertices[21] = new Vector3(9.6f, y, 24.7f);
        vertices[22] = new Vector3(10.3f, y, 24.7f);
        vertices[23] = new Vector3(11.2f, y, 24f);
        vertices[24] = new Vector3(11.5f, y, 24.7f);

        int[] tris = new int[] { 0,1,2, 0,3,1, 3,4,1, 3,5,4, 5,6,4, 6,7,4, 7,8,4, 7,9,8, 9,10,8, 9,11,10, 9,12,11, 12,13,11, 13,14,11, 14,15,11, 15,16,11, 11,16,17, 16,18,17, 18,19,17, 19,20,17, 17,20,21, 21,20,22, 22,20,23, 23,20,24 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Italia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateApulea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-13.5f, 26f, y);
        positions.TowerPosition = new Vector3(-16f, 25f, 1);
        positions.ArmyPosition = new Vector3(-14f, 21f, y);
        positions.AddResource(new Vector3(-13f, 24.5f, y), Resource.Fruits);
        positions.AddResource(new Vector3(-15f, 23f, y), Resource.Oil);
        positions.MarketPosition = new Vector3(-13.5f, 23f, y);

        Vector3[] vertices = new Vector3[37];
        vertices[0] = new Vector3(11.5f, y, 25.7f);
        vertices[1] = new Vector3(12f, y, 26.5f);
        vertices[2] = new Vector3(11.5f, y, 24.7f);
        vertices[3] = new Vector3(12.6f, y, 26.5f);
        vertices[4] = new Vector3(12.9f, y, 26.2f);
        vertices[5] = new Vector3(13.5f, y, 26.5f);
        vertices[6] = new Vector3(14.1f, y, 26f);
        vertices[7] = new Vector3(14.1f, y, 25.7f);
        vertices[8] = new Vector3(14.7f, y, 25.3f);
        vertices[9] = new Vector3(11.2f, y, 24f);
        vertices[10] = new Vector3(11.7f, y, 23.7f);
        vertices[11] = new Vector3(12f, y, 23.3f);
        vertices[12] = new Vector3(12.6f, y, 23.2f);
        vertices[13] = new Vector3(13f, y, 22.5f);
        vertices[14] = new Vector3(13.7f, y, 22.2f);
        vertices[15] = new Vector3(15.5f, y, 23.2f);
        vertices[16] = new Vector3(15f, y, 25.3f);
        vertices[17] = new Vector3(15.1f, y, 25.2f);
        vertices[18] = new Vector3(15.7f, y, 24.8f);
        vertices[19] = new Vector3(15.8f, y, 23.5f);
        vertices[20] = new Vector3(16.8f, y, 23.5f);
        vertices[21] = new Vector3(16.8f, y, 24.8f);
        vertices[22] = new Vector3(17.3f, y, 23.1f);
        vertices[23] = new Vector3(17.8f, y, 23.5f);
        vertices[24] = new Vector3(15.3f, y, 22.2f);
        vertices[25] = new Vector3(14f, y, 21.5f);
        vertices[26] = new Vector3(15.8f, y, 22f);
        vertices[27] = new Vector3(15.9f, y, 21.5f);
        vertices[28] = new Vector3(14.4f, y, 21.2f);
        vertices[29] = new Vector3(15.4f, y, 21f);
        vertices[30] = new Vector3(15.1f, y, 20f);
        vertices[31] = new Vector3(14.4f, y, 20.9f);
        vertices[32] = new Vector3(14.2f, y, 20.5f);
        vertices[33] = new Vector3(14.3f, y, 19.7f);
        vertices[34] = new Vector3(15.1f, y, 19.4f);
        vertices[35] = new Vector3(15.15f, y, 19f);
        vertices[36] = new Vector3(14.7f, y, 18.8f);

        int[] tris = new int[] { 0,1,2, 1,3,2, 3,4,2, 4,5,2, 5,6,2, 6,7,2, 7,8,2, 2,8,9, 9,8,10, 10,8,11, 11,8,12, 12,8,13, 13,8,14, 14,8,15, 8,16,15, 16,17,15, 17,18,15, 18,19,15, 19,18,20, 20,18,21, 20,21,22, 22,21,23, 14,15,24, 14,24,25, 25,24,26, 25,26,27, 25,27,28, 28,27,29, 28,29,30, 28,30,31, 31,30,32, 32,30,33, 33,30,34, 33,34,35, 33,35,36};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Apulea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateSicilia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-13f, 17f, y);
        positions.TowerPosition = new Vector3(-10.5f, 19.5f, 1);
        positions.ArmyPosition = new Vector3(-11f, 18.5f, y);
        positions.AddCity(new Vector3(-13f, 18f, y));
        positions.TemplePosition = new Vector3(-13f, 19.5f, y);

        Vector3[] vertices = new Vector3[25];
        vertices[0] = new Vector3(13.6f, y, 19.8f);
        vertices[1] = new Vector3(13.8f, y, 19.3f);
        vertices[2] = new Vector3(13.3f, y, 18.5f);
        vertices[3] = new Vector3(13.2f, y, 19.5f);
        vertices[4] = new Vector3(12.8f, y, 19.5f);
        vertices[5] = new Vector3(12f, y, 19f);
        vertices[6] = new Vector3(13.6f, y, 17f);
        vertices[7] = new Vector3(13.2f, y, 16.5f);
        vertices[8] = new Vector3(13.1f, y, 16.1f);
        vertices[9] = new Vector3(12.7f, y, 16f);
        vertices[10] = new Vector3(12.6f, y, 16.3f);
        vertices[11] = new Vector3(12.2f, y, 16.3f);
        vertices[12] = new Vector3(11.8f, y, 17f);
        vertices[13] = new Vector3(11.3f, y, 17f);
        vertices[14] = new Vector3(10.9f, y, 17.4f);
        vertices[15] = new Vector3(11.7f, y, 19.2f);
        vertices[16] = new Vector3(11.4f, y, 19f);
        vertices[17] = new Vector3(10.4f, y, 17.3f);
        vertices[18] = new Vector3(10.4f, y, 17.8f);
        vertices[19] = new Vector3(9.4f, y, 18.2f);
        vertices[20] = new Vector3(10.6f, y, 19.5f);
        vertices[21] = new Vector3(10.4f, y, 19.3f);
        vertices[22] = new Vector3(10.1f, y, 19.3f);
        vertices[23] = new Vector3(9.9f, y, 19.6f);
        vertices[24] = new Vector3(9.2f, y, 18.9f);

        int[] tris = new int[] { 0,1,2, 3,0,2, 4,3,2, 5,4,2, 2,6,5, 5,6,7, 5,7,8, 5,8,9, 5,9,10, 5,10,11, 5,11,12, 5,12,13, 5,13,14, 5,14,15, 15,14,16, 14,17,16, 17,18,16, 18,19,16, 16,19,20, 19,21,20, 19,22,21, 19,23,22, 19,24,23 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Sicilia";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateGreece()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-23.3f, 25f, y);
        positions.TowerPosition = new Vector3(-23.5f, 21.5f, 1);
        positions.ArmyPosition = new Vector3(-21.5f, 21.5f, y);
        positions.AddResource(new Vector3(-23f, 23.5f, y), Resource.Oil);
        positions.MarketPosition = new Vector3(-24.5f, 23.5f, y);
        positions.AddCity(new Vector3(-23.5f, 19.5f, y));
        positions.AddCity(new Vector3(-25f, 21.5f, y));
        positions.TemplePosition = new Vector3(-21.5f, 23.5f, y);

        Vector3[] vertices = new Vector3[60];
        vertices[0] = new Vector3(23f, y, 25.7f);
        vertices[1] = new Vector3(21.5f, y, 24.5f);
        vertices[2] = new Vector3(22.2f, y, 25.2f);
        vertices[3] = new Vector3(24f, y, 25.7f);
        vertices[4] = new Vector3(23.7f, y, 25f);
        vertices[5] = new Vector3(24.3f, y, 24.2f);
        vertices[6] = new Vector3(25f, y, 23.8f);
        vertices[7] = new Vector3(24.6f, y, 23.6f);
        vertices[8] = new Vector3(24.9f, y, 23.4f);
        vertices[9] = new Vector3(24.4f, y, 23.4f);
        vertices[10] = new Vector3(24.6f, y, 23f);
        vertices[11] = new Vector3(24.5f, y, 22.8f); 
        vertices[12] = new Vector3(21.8f, y, 22.5f); 
        vertices[13] = new Vector3(21f, y, 22.4f);
        vertices[14] = new Vector3(20.7f, y, 22.9f);
        vertices[15] = new Vector3(20.5f, y, 23f);
        vertices[16] = new Vector3(20.4f, y, 23.2f);
        vertices[17] = new Vector3(20f, y, 23.7f);
        vertices[18] = new Vector3(21.8f, y, 22.3f);
        vertices[19] = new Vector3(21.3f, y, 22.1f);
        vertices[20] = new Vector3(21.5f, y, 21.8f);
        vertices[21] = new Vector3(21.9f, y, 21.6f);
        vertices[22] = new Vector3(22.4f, y, 21.5f);
        vertices[23] = new Vector3(23.2f, y, 21.7f);
        vertices[24] = new Vector3(24.4f, y, 21.8f);
        vertices[25] = new Vector3(24.7f, y, 22.5f);
        vertices[26] = new Vector3(25.3f, y, 22.5f);
        vertices[27] = new Vector3(25.7f, y, 22.2f);
        vertices[28] = new Vector3(26f, y, 21.6f);
        vertices[29] = new Vector3(25.4f, y, 20.7f);
        vertices[30] = new Vector3(24.3f, y, 21.4f);
        vertices[31] = new Vector3(25.5f, y, 20.4f);
        vertices[32] = new Vector3(24.8f, y, 20.4f);
        vertices[33] = new Vector3(25.2f, y, 20f);
        vertices[34] = new Vector3(23.9f, y, 21.6f);
        vertices[35] = new Vector3(23f, y, 21.5f);
        vertices[36] = new Vector3(22.5f, y, 21.1f);
        vertices[37] = new Vector3(22.2f, y, 21.1f);
        vertices[38] = new Vector3(21.8f, y, 20.5f);
        vertices[39] = new Vector3(22f, y, 20.1f);
        vertices[40] = new Vector3(22.3f, y, 20.1f);
        vertices[41] = new Vector3(22.7f, y, 19.6f);
        vertices[42] = new Vector3(22.5f, y, 19.4f);
        vertices[43] = new Vector3(22.6f, y, 19f);
        vertices[44] = new Vector3(22.9f, y, 18.8f);
        vertices[45] = new Vector3(23.1f, y, 18.4f);
        vertices[46] = new Vector3(23.4f, y, 18.4f);
        vertices[47] = new Vector3(23.8f, y, 18.4f);
        vertices[48] = new Vector3(23.6f, y, 18.2f);
        vertices[49] = new Vector3(24f, y, 18.8f);
        vertices[50] = new Vector3(24.4f, y, 18.1f);
        vertices[51] = new Vector3(24.7f, y, 18.4f);
        vertices[52] = new Vector3(24.4f, y, 19f);
        vertices[53] = new Vector3(24.8f, y, 18.6f);
        vertices[54] = new Vector3(25.2f, y, 18.6f);
        vertices[55] = new Vector3(25.4f, y, 18.4f);
        vertices[56] = new Vector3(25.6f, y, 18.6f);
        vertices[57] = new Vector3(25.2f, y, 19f);
        vertices[58] = new Vector3(25.2f, y, 19.6f);
        vertices[59] = new Vector3(24.9f, y, 20f);

        int[] tris = new int[] { 0,1,2, 0,3,1, 3,4,1, 4,5,1, 5,6,1, 6,7,1, 6,8,7, 7,9,1, 9,10,1, 10,11,1, 1,11,12, 1,12,13, 1,13,14, 1,14,15, 1,15,16, 1,16,17, 12,11,18, 11,19,18, 11,20,19, 11,21,20, 11,22,21, 11,23,22, 11,24,23, 11,25,24, 25,26,24, 26,27,24, 27,28,24, 28,29,24, 24,29,30, 30,29,31, 30,31,32, 31,33,32, 30,32,34, 32,35,34, 32,36,35, 39,38,37, 40,39,37, 40,37,36, 41,40,36, 44,43,42, 41,44,42, 32,44,41, 32,41,36, 46,45,44, 47,48,46, 47,46,49, 49,46,44, 49,51,50, 49,52,51, 52,54,53, 54,56,55, 54,57,56, 52,58,57, 52,57,54, 32,59,44, 59,58,52, 59,49,44, 59,52,49};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Greece";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateSardinia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-4f, 24.5f, y);
        positions.TowerPosition = new Vector3(-3.5f, 25f, 1);
        positions.ArmyPosition = new Vector3(-3.5f, 27.5f, y);
        positions.AddResource(new Vector3(-3.7f, 23f, y), Resource.Iron);
        positions.MarketPosition = new Vector3(-3.7f, 21.5f, y);

        Vector3[] vertices = new Vector3[37];
        vertices[0] = new Vector3(3.1f, y, 27.5f);
        vertices[1] = new Vector3(4.2f, y, 27.5f);
        vertices[2] = new Vector3(3.1f, y, 26.6f);
        vertices[3] = new Vector3(3.4f, y, 25.7f);
        vertices[4] = new Vector3(4.3f, y, 27f);
        vertices[5] = new Vector3(4.2f, y, 26.3f);
        vertices[6] = new Vector3(4f, y, 26f);
        vertices[7] = new Vector3(3.9f, y, 25.5f);
        vertices[8] = new Vector3(3.5f, y, 27.8f);
        vertices[9] = new Vector3(4f, y, 28f);
        vertices[10] = new Vector3(3.6f, y, 28.3f);
        vertices[11] = new Vector3(3.9f, y, 28.5f);
        vertices[12] = new Vector3(3.6f, y, 28.8f);
        vertices[13] = new Vector3(3.4f, y, 28.5f);
        vertices[14] = new Vector3(4.1f, y, 25.4f);
        vertices[15] = new Vector3(4.2f, y, 25f);
        vertices[16] = new Vector3(3.8f, y, 25.3f);
        vertices[17] = new Vector3(3.8f, y, 25f);
        vertices[18] = new Vector3(3.1f, y, 24.3f);
        vertices[19] = new Vector3(4.6f, y, 24.4f);
        vertices[20] = new Vector3(4.6f, y, 24f);
        vertices[21] = new Vector3(4.8f, y, 23.7f);
        vertices[22] = new Vector3(4.7f, y, 23f);
        vertices[23] = new Vector3(2.8f, y, 24.6f);
        vertices[24] = new Vector3(2.5f, y, 24.3f);
        vertices[25] = new Vector3(2.6f, y, 23.6f);
        vertices[26] = new Vector3(2.6f, y, 22.8f);
        vertices[27] = new Vector3(3.1f, y, 22.6f);
        vertices[28] = new Vector3(4.8f, y, 22.2f);
        vertices[29] = new Vector3(3.2f, y, 22.3f);
        vertices[30] = new Vector3(4.7f, y, 21.6f);
        vertices[31] = new Vector3(4.8f, y, 21.3f);
        vertices[32] = new Vector3(4.7f, y, 20.9f);
        vertices[33] = new Vector3(4.2f, y, 20.9f);
        vertices[34] = new Vector3(3.9f, y, 20.6f);
        vertices[35] = new Vector3(3.4f, y, 20.6f);
        vertices[36] = new Vector3(2.9f, y, 21.3f);

        int[] tris = new int[] { 0,1,2, 2,1,3, 1,4,3, 4,5,3, 5,6,3, 6,7,3, 0,8,1, 8,9,1, 8,10,9, 10,11,9, 10,12,11, 10,13,12, 14,15,16, 16,15,17, 17,15,18, 18,15,19, 18,19,20, 18,20,21, 18,21,22, 18,24,23, 18,25,24, 18,22,25, 25,22,26, 26,22,27, 27,22,28, 27,28,29, 29,28,30, 29,30,31, 29,31,32, 29,32,33, 29,33,34, 29,34,35, 29,35,36};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Sardinia and Korsika";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateCrit()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.InfluenceTilePosition = new Vector3(-29f, 17.5f, y);
        positions.TowerPosition = new Vector3(-28f, 18f, 1);
        positions.ArmyPosition = new Vector3(-28f, 17.5f, y);
        positions.AddCity(new Vector3(-30f, 17.5f, y));
        positions.TemplePosition = new Vector3(-30.7f, 18f, y);

        Vector3[] vertices = new Vector3[25];
        vertices[0] = new Vector3(31.5f, y, 17.8f);
        vertices[1] = new Vector3(31.3f, y, 17.6f);
        vertices[2] = new Vector3(31.3f, y, 17.8f);
        vertices[3] = new Vector3(31.5f, y, 17.5f);
        vertices[4] = new Vector3(31.2f, y, 17f);
        vertices[5] = new Vector3(30.9f, y, 17.1f);
        vertices[6] = new Vector3(30.9f, y, 17.4f);
        vertices[7] = new Vector3(29.9f, y, 16.6f);
        vertices[8] = new Vector3(30.1f, y, 18f);
        vertices[9] = new Vector3(29.4f, y, 17.8f);
        vertices[10] = new Vector3(29.5f, y, 16.6f);
        vertices[11] = new Vector3(29.3f, y, 16.5f);
        vertices[12] = new Vector3(29f, y, 16.7f);
        vertices[13] = new Vector3(28.8f, y, 17.7f);
        vertices[14] = new Vector3(28.4f, y, 16.7f);
        vertices[15] = new Vector3(28.3f, y, 17.5f);
        vertices[16] = new Vector3(28f, y, 16.5f);
        vertices[17] = new Vector3(27.8f, y, 16.8f);
        vertices[18] = new Vector3(27.3f, y, 16.8f);
        vertices[19] = new Vector3(27.3f, y, 17.1f);
        vertices[20] = new Vector3(27.1f, y, 17.3f);
        vertices[21] = new Vector3(28.2f, y, 17.8f);
        vertices[22] = new Vector3(27.7f, y, 17.7f);
        vertices[23] = new Vector3(27.5f, y, 17.7f);
        vertices[24] = new Vector3(27.3f, y, 17.5f);

        int[] tris = new int[] { 0,1,2, 1,3,4, 1,4,5, 1,5,6, 6,5,7, 6,7,8, 8,7,9, 7,10,9, 9,10,11, 9,11,12, 9,12,13, 12,14,13, 14,15,13, 14,16,15, 16,17,15, 17,18,15, 18,19,15, 19,20,15, 15,22,21, 22,24,23, 15,24,22, 15,20,24};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Crit";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateWestMeditarianSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-5f, 19f, y);

        Vector3[] vertices = new Vector3[33];
        vertices[0] = new Vector3(0f, y, 21.5f);
        vertices[1] = new Vector3(2.9f, y, 21.5f);
        vertices[2] = new Vector3(0f, y, 16.2f);
        vertices[3] = new Vector3(0.5f, y, 16.4f);
        vertices[4] = new Vector3(2.8f, y, 21.3f);
        vertices[5] = new Vector3(3.4f, y, 20.5f);
        vertices[6] = new Vector3(1f, y, 16.2f);
        vertices[7] = new Vector3(2.3f, y, 16.4f);
        vertices[8] = new Vector3(3.4f, y, 16.3f);
        vertices[9] = new Vector3(4f, y, 16.7f);
        vertices[10] = new Vector3(3.9f, y, 20.5f);
        vertices[11] = new Vector3(4.2f, y, 20.9f);
        vertices[12] = new Vector3(4.7f, y, 20.9f);
        vertices[13] = new Vector3(4.6f, y, 16.9f);
        vertices[14] = new Vector3(5.5f, y, 17f);
        vertices[15] = new Vector3(6f, y, 17f);
        vertices[16] = new Vector3(7f, y, 20f);
        vertices[17] = new Vector3(6.5f, y, 16.7f);
        vertices[18] = new Vector3(7f, y, 16.1f);
        vertices[19] = new Vector3(7.5f, y, 16.6f);
        vertices[20] = new Vector3(7.9f, y, 16.6f);
        vertices[21] = new Vector3(9.2f, y, 18.9f);
        vertices[22] = new Vector3(9.4f, y, 18.2f);
        vertices[23] = new Vector3(10.4f, y, 17.8f);
        vertices[24] = new Vector3(10.4f, y, 17.3f);
        vertices[25] = new Vector3(8f, y, 16.1f);
        vertices[26] = new Vector3(7.2f, y, 15f);
        vertices[27] = new Vector3(10.9f, y, 17.4f);
        vertices[28] = new Vector3(11.3f, y, 17f);
        vertices[29] = new Vector3(11.8f, y, 17f);
        vertices[30] = new Vector3(12.2f, y, 16.2f);
        vertices[31] = new Vector3(10.7f, y, 14.6f);
        vertices[32] = new Vector3(8.3f, y, 13.4f);

        int[] tris = new int[] { 0,1,2, 2,1,3, 3,1,4, 4,5,3, 5,6,3, 5,7,6, 5,8,7, 5,9,8, 5,10,9, 10,11,9, 11,12,9, 12,13,9, 12,14,13, 12,15,14, 12,16,15, 16,17,15, 16,18,17, 16,19,18, 16,20,19, 16,21,20, 21,22,20, 22,23,20, 23,24,20, 20,24,25, 24,26,25, 24,27,26, 27,28,26, 28,29,26, 29,30,26, 30,31,26, 31,32,26};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "West Meditatian sea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateTirreneyenSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0; 
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-10f, 23f, y);

        Vector3[] vertices = new Vector3[74];
        vertices[0] = new Vector3(0f, y, 28f);
        vertices[1] = new Vector3(2.9f, y, 21.5f);
        vertices[2] = new Vector3(0f, y, 21.5f);
        vertices[3] = new Vector3(2.6f, y, 22.8f);
        vertices[4] = new Vector3(3.1f, y, 22.6f);
        vertices[5] = new Vector3(3.2f, y, 22.3f);
        vertices[6] = new Vector3(2.6f, y, 23.5f);
        vertices[7] = new Vector3(2.5f, y, 24.3f);
        vertices[8] = new Vector3(2.8f, y, 24.6f);
        vertices[9] = new Vector3(0.6f, y, 28.1f);
        vertices[10] = new Vector3(3.1f, y, 26.6f);
        vertices[11] = new Vector3(3.4f, y, 25.7f);
        vertices[12] = new Vector3(3.1f, y, 24.3f);
        vertices[13] = new Vector3(3.8f, y, 25f);
        vertices[14] = new Vector3(3.8f, y, 25.3f);
        vertices[15] = new Vector3(3.9f, y, 25.5f);
        vertices[16] = new Vector3(4.1f, y, 25.4f);
        vertices[17] = new Vector3(3.1f, y, 27.5f);
        vertices[18] = new Vector3(1.3f, y, 28.8f);
        vertices[19] = new Vector3(2f, y, 28.9f);
        vertices[20] = new Vector3(3.5f, y, 27.8f);
        vertices[21] = new Vector3(3.6f, y, 28.3f);
        vertices[22] = new Vector3(3.4f, y, 28.5f);
        vertices[23] = new Vector3(3.6f, y, 28.8f);
        vertices[24] = new Vector3(2.5f, y, 29.5f);
        vertices[25] = new Vector3(2.8f, y, 29.4f);
        vertices[26] = new Vector3(3.6f, y, 29.7f);
        vertices[27] = new Vector3(3.9f, y, 28.5f);
        vertices[28] = new Vector3(5f, y, 29f);
        vertices[29] = new Vector3(5.3f, y, 29f);
        vertices[30] = new Vector3(5.6f, y, 28.7f);
        vertices[31] = new Vector3(5.6f, y, 27.7f);
        vertices[32] = new Vector3(4f, y, 28f);
        vertices[33] = new Vector3(4.2f, y, 27.5f);
        vertices[34] = new Vector3(4.3f, y, 27f);
        vertices[35] = new Vector3(4.2f, y, 26.3f);
        vertices[36] = new Vector3(7.6f, y, 25.7f);
        vertices[37] = new Vector3(4f, y, 26f);
        vertices[38] = new Vector3(4.2f, y, 25f);
        vertices[39] = new Vector3(4.6f, y, 24.4f);
        vertices[40] = new Vector3(4.6f, y, 24f);
        vertices[41] = new Vector3(4.8f, y, 23.7f);
        vertices[42] = new Vector3(4.7f, y, 23f);
        vertices[43] = new Vector3(4.8f, y, 22.2f);
        vertices[44] = new Vector3(9.3f, y, 25f);
        vertices[45] = new Vector3(9.6f, y, 24.7f);
        vertices[46] = new Vector3(10.3f, y, 24.7f);
        vertices[47] = new Vector3(11.2f, y, 24f);
        vertices[48] = new Vector3(4.7f, y, 21.6f);
        vertices[49] = new Vector3(4.8f, y, 21.3f);
        vertices[50] = new Vector3(4.7f, y, 20.9f);
        vertices[51] = new Vector3(7f, y, 20f);
        vertices[52] = new Vector3(9.2f, y, 18.9f);
        vertices[53] = new Vector3(9.9f, y, 19.6f);
        vertices[54] = new Vector3(10.1f, y, 19.3f); 
        vertices[55] = new Vector3(10.4f, y, 19.3f);
        vertices[56] = new Vector3(10.6f, y, 19.5f);
        vertices[57] = new Vector3(11.7f, y, 23.7f);
        vertices[58] = new Vector3(12f, y, 23.3f);
        vertices[59] = new Vector3(11.4f, y, 19f); 
        vertices[60] = new Vector3(11.7f, y, 19.2f);
        vertices[61] = new Vector3(12f, y, 19f);
        vertices[62] = new Vector3(12.6f, y, 23.2f);
        vertices[63] = new Vector3(13f, y, 22.5f);
        vertices[64] = new Vector3(13.7f, y, 22.2f);
        vertices[65] = new Vector3(12.7f, y, 19.5f);
        vertices[66] = new Vector3(13.2f, y, 19.5f);
        vertices[67] = new Vector3(14, y, 21.5f);
        vertices[68] = new Vector3(14.4f, y, 21.2f);
        vertices[69] = new Vector3(13.6f, y, 19.8f);
        vertices[70] = new Vector3(14.4f, y, 20.9f);
        vertices[71] = new Vector3(14.2f, y, 20.5f);
        vertices[72] = new Vector3(14.2f, y, 20.2f);
        vertices[73] = new Vector3(13.7f, y, 19.7f);

        int[] tris = new int[] { 0,1,2, 0,3,1, 1,3,4, 4,5,1, 0,6,3, 0,7,6, 0,8,7, 0,9,8, 9,10,8, 10,11,8, 11,12,8, 11,13,12, 11,14,13, 11,15,14, 15,16,14, 9,17,10, 9,18,17, 18,19,17, 19,20,17, 19,21,20, 19,22,21, 19,23,22, 19,24,25, 25,23,19, 25,26,23, 26,27,23, 26,28,27, 28,29,27, 29,30,27, 30,31,27, 27,31,32, 32,31,33, 33,31,34, 34,31,35, 31,36,35, 35,36,37, 37,36,15, 36,16,15, 36,38,16, 36,39,38, 36,40,39, 36,41,40, 36,42,41, 36,43,42, 36,44,43, 44,45,43, 45,46,43, 46,47,43, 47,48,43, 47,49,48, 47,50,49, 47,51,50, 47,52,51, 47,53,52, 47,54,53, 47,55,54, 47,56,55, 47,57,56, 57,58,56, 58,59,56, 58,60,59, 58,61,60, 58,62,61, 62,63,61, 63,64,61, 64,65,61, 64,66,65, 64,67,66, 67,68,66, 68,69,66, 68,70,69, 70,71,69, 71,72,69, 72,73,69};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Tirrereyen sea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateCentralMeditarianSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-20f, 13f, y);


        Vector3[] vertices = new Vector3[49];
        vertices[0] = new Vector3(8.3f, y, 13.4f);
        vertices[1] = new Vector3(10.7f, y, 14.6f);
        vertices[2] = new Vector3(8.3f, y, 12.5f);
        vertices[3] = new Vector3(8f, y, 12.1f);
        vertices[4] = new Vector3(7.7f, y, 12.1f);
        vertices[5] = new Vector3(7.2f, y, 11.5f);
        vertices[6] = new Vector3(6.9f, y, 11.5f);
        vertices[7] = new Vector3(6.8f, y, 10.8f);
        vertices[8] = new Vector3(7.3f, y, 10.2f);
        vertices[9] = new Vector3(8.2f, y, 10.2f);
        vertices[10] = new Vector3(8.7f, y, 9.6f);
        vertices[11] = new Vector3(9.5f, y, 9.6f);
        vertices[12] = new Vector3(10.7f, y, 9.1f);
        vertices[13] = new Vector3(10.8f, y, 9.2f);
        vertices[14] = new Vector3(15.5f, y, 8.5f);
        vertices[15] = new Vector3(12.2f, y, 16.2f);
        vertices[16] = new Vector3(12.5f, y, 16.2f);
        vertices[17] = new Vector3(12.7f, y, 15.9f);
        vertices[18] = new Vector3(13.1f, y, 16.1f);
        vertices[19] = new Vector3(13.2f, y, 16.5f);
        vertices[20] = new Vector3(13.6f, y, 17f);
        vertices[21] = new Vector3(16f, y, 7.3f);
        vertices[22] = new Vector3(19.8f, y, 7f);
        vertices[23] = new Vector3(20f, y, 6.7f);
        vertices[24] = new Vector3(22.2f, y, 5.95f);
        vertices[25] = new Vector3(23f, y, 6.2f);
        vertices[26] = new Vector3(23.6f, y, 7.3f);
        vertices[27] = new Vector3(23.5f, y, 10f);
        vertices[28] = new Vector3(24.7f, y, 11.5f);
        vertices[29] = new Vector3(14f, y, 17f);
        vertices[30] = new Vector3(21f, y, 16.1f);
        vertices[31] = new Vector3(22.8f, y, 16.1f);
        vertices[32] = new Vector3(24.6f, y, 16.5f);
        vertices[33] = new Vector3(26.2f, y, 11.8f);
        vertices[34] = new Vector3(27.5f, y, 11.7f);
        vertices[35] = new Vector3(27.1f, y, 17.3f);
        vertices[36] = new Vector3(27.3f, y, 17.1f);
        vertices[37] = new Vector3(27.3f, y, 16.8f);
        vertices[38] = new Vector3(27.8f, y, 16.8f);
        vertices[39] = new Vector3(28f, y, 16.5f);
        vertices[40] = new Vector3(28.4f, y, 16.7f);
        vertices[41] = new Vector3(29f, y, 16.7f);
        vertices[42] = new Vector3(29.3f, y, 16.5f);
        vertices[43] = new Vector3(27.6f, y, 11.5f);
        vertices[44] = new Vector3(28.8f, y, 11.1f);
        vertices[45] = new Vector3(30.5f, y, 11.4f);
        vertices[46] = new Vector3(30.7f, y, 14f);
        vertices[47] = new Vector3(29.5f, y, 16.6f);
        vertices[48] = new Vector3(29.9f, y, 16.6f);

        int[] tris = new int[] { 0,1,2, 3,5,4, 5,7,6, 5,8,7, 5,9,8, 3,9,5, 2,10,3, 3,10,9, 2,11,10, 2,12,11, 1,12,2, 1,13,12, 1,14,13, 1,15,14, 15,16,17, 15,17,14, 14,17,18, 18,19,20, 14,20,21, 18,20,14, 20,22,21, 22,24,23, 20,24,22, 24,26,25, 24,27,26, 20,27,24, 20,28,27, 20,29,28, 29,30,28, 30,31,28, 31,32,28, 32,33,28, 32,34,33, 32,35,36, 32,36,37, 37,38,34, 32,37,34, 38,39,34, 39,40,34, 40,41,34, 41,42,34, 42,43,34, 42,44,43, 42,45,44, 42,46,45, 42,47,46, 47,48,46};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Central Meditarian sea";
        Regions.Add(new Region(tile, positions));
    }
    
    private void GenerateIonicSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-19f, 21f, y);

        Vector3[] vertices = new Vector3[59];
        vertices[0] = new Vector3(13.7f, y, 19.7f);
        vertices[1] = new Vector3(14.2f, y, 20.2f);
        vertices[2] = new Vector3(14.3f, y, 19.7f);
        vertices[3] = new Vector3(14.7f, y, 18.8f);
        vertices[4] = new Vector3(13.8f, y, 19.3f);
        vertices[5] = new Vector3(13.3f, y, 18.5f);
        vertices[6] = new Vector3(13.6f, y, 17f);
        vertices[7] = new Vector3(14f, y, 17f);
        vertices[8] = new Vector3(15.2f, y, 19f);
        vertices[9] = new Vector3(21f, y, 16.1f); 
        vertices[10] = new Vector3(15.1f, y, 19.4f);
        vertices[11] = new Vector3(15.1f, y, 20f);
        vertices[12] = new Vector3(15.4f, y, 21f);
        vertices[13] = new Vector3(15.9f, y, 21.5f);
        vertices[14] = new Vector3(15.8f, y, 22f);
        vertices[15] = new Vector3(17.3f, y, 23.1f);
        vertices[16] = new Vector3(15.3f, y, 22.2f);
        vertices[17] = new Vector3(15.5f, y, 23.2f);
        vertices[18] = new Vector3(15.8f, y, 23.5f);
        vertices[19] = new Vector3(16.8f, y, 23.5f);
        vertices[20] = new Vector3(17.8f, y, 23.5f);
        vertices[21] = new Vector3(19.1f, y, 24.2f);
        vertices[22] = new Vector3(18.8f, y, 24.6f);
        vertices[23] = new Vector3(17.5f, y, 24f);
        vertices[24] = new Vector3(20f, y, 23.7f);
        vertices[25] = new Vector3(20.4f, y, 23.2f);
        vertices[26] = new Vector3(20.5f, y, 23f);
        vertices[27] = new Vector3(20.7f, y, 22.9f);
        vertices[28] = new Vector3(21f, y, 22.4f);
        vertices[29] = new Vector3(21.3f, y, 22.1f); 
        vertices[30] = new Vector3(21.8f, y, 22.5f);
        vertices[31] = new Vector3(21.8f, y, 22.3f);
        vertices[32] = new Vector3(21.5f, y, 21.8f);
        vertices[33] = new Vector3(21.8f, y, 20.5f);
        vertices[34] = new Vector3(21.9f, y, 21.6f);
        vertices[35] = new Vector3(22.2f, y, 21.1f);
        vertices[36] = new Vector3(22.4f, y, 21.5f);
        vertices[37] = new Vector3(22.5f, y, 21.1f);
        vertices[38] = new Vector3(23f, y, 21.5f);
        vertices[39] = new Vector3(23.2f, y, 21.7f);
        vertices[40] = new Vector3(23.9f, y, 21.6f);
        vertices[41] = new Vector3(24.4f, y, 21.8f);
        vertices[42] = new Vector3(24.3f, y, 21.4f);
        vertices[43] = new Vector3(22f, y, 20.1f);
        vertices[44] = new Vector3(22.3f, y, 20.1f);
        vertices[45] = new Vector3(22.7f, y, 19.6f);
        vertices[46] = new Vector3(22.5f, y, 19.4f);
        vertices[47] = new Vector3(22.6f, y, 19f);
        vertices[48] = new Vector3(22.9f, y, 18.8f);
        vertices[49] = new Vector3(23.1f, y, 18.4f);
        vertices[50] = new Vector3(23.4f, y, 18.4f);
        vertices[51] = new Vector3(23.6f, y, 18.2f);
        vertices[52] = new Vector3(23.8f, y, 18.4f);
        vertices[53] = new Vector3(24f, y, 18.8f);
        vertices[54] = new Vector3(24.4f, y, 18.1f);
        vertices[55] = new Vector3(24.6f, y, 17.5f);
        vertices[56] = new Vector3(24.5f, y, 17f);
        vertices[57] = new Vector3(24.6f, y, 16.5f);
        vertices[58] = new Vector3(22.8f, y, 16.1f);

        int[] tris = new int[] { 0,1,2, 0,2,3, 0,3,4, 4,3,5, 5,3,6, 3,7,6, 3,8,7, 8,9,7, 8,10,9, 10,11,9, 11,12,9, 12,13,9, 13,14,9, 14,15,9, 14,16,15, 16,17,15, 17,18,15, 18,19,15, 15,20,9, 20,21,9, 20,22,21, 20,23,22, 21,24,9, 24,25,9, 25,26,9, 26,27,9, 27,28,9, 28,29,9, 28,30,29, 30,31,29, 29,32,9, 32,33,9, 32,34,33, 34,35,33, 34,36,35, 36,37,35, 36,38,37, 36,39,38, 39,40,38, 39,41,40, 41,42,40, 33,43,9, 43,44,9, 44,45,46, 44,46,9, 46,47,9, 47,48,9, 48,49,9, 49, 50,9, 50,51,9, 52,53,54, 51,52,54, 51,54,55, 51,55,56, 51,56,57, 51,57,58, 9,51,58};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Ionic Sea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateEastMeditarianSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-35f, 16f, y);

        Vector3[] vertices = new Vector3[36];
        vertices[0] = new Vector3(30.5f, y, 11.4f);
        vertices[1] = new Vector3(30.7f, y, 14f);
        vertices[2] = new Vector3(32f, y, 11f);
        vertices[3] = new Vector3(33.2f, y, 11.4f);
        vertices[4] = new Vector3(33.3f, y, 11.3f);
        vertices[5] = new Vector3(34.3f, y, 11.6f);
        vertices[6] = new Vector3(35.3f, y, 11.5f);
        vertices[7] = new Vector3(35.9f, y, 11.6f);
        vertices[8] = new Vector3(37.9f, y, 11.4f);
        vertices[9] = new Vector3(38.2f, y, 11.5f); 
        vertices[10] = new Vector3(29.9f, y, 16.6f);
        vertices[11] = new Vector3(30.9f, y, 17.1f);
        vertices[12] = new Vector3(31.2f, y, 17f);
        vertices[13] = new Vector3(31.5f, y, 17.5f);
        vertices[14] = new Vector3(31.6f, y, 17.8f);
        vertices[15] = new Vector3(33.1f, y, 17.9f);
        vertices[16] = new Vector3(35.1f, y, 17.9f);
        vertices[17] = new Vector3(40f, y, 13.3f);
        vertices[18] = new Vector3(40.5f, y, 13.5f);
        vertices[19] = new Vector3(41f, y, 13.9f);
        vertices[20] = new Vector3(37f, y, 18.3f);
        vertices[21] = new Vector3(39.3f, y, 19f);
        vertices[22] = new Vector3(39.8f, y, 18.9f);
        vertices[23] = new Vector3(40.4f, y, 18.6f);
        vertices[24] = new Vector3(41.2f, y, 18.8f);
        vertices[25] = new Vector3(41.2f, y, 19.2f);
        vertices[26] = new Vector3(41.5f, y, 19.3f);
        vertices[27] = new Vector3(41.7f, y, 19.8f);
        vertices[28] = new Vector3(43.1f, y, 14.2f);
        vertices[29] = new Vector3(42.2f, y, 19.8f);
        vertices[30] = new Vector3(42.3f, y, 20f);
        vertices[31] = new Vector3(44f, y, 18.6f);
        vertices[32] = new Vector3(44.6f, y, 18.3f);
        vertices[33] = new Vector3(43.7f, y, 14.6f);
        vertices[34] = new Vector3(44.2f, y, 14.6f);
        vertices[35] = new Vector3(44.7f, y, 15.2f);

        int[] tris = new int[] { 0,1,2, 1,3,2, 3,5,4, 1,5,3, 1,6,5, 1,7,6, 1,8,7, 1,9,8, 1,10,9, 10,11,9, 11,12,9, 12,13,9, 13,14,9, 14,15,9, 15,16,9, 16,17,9, 16,18,17, 16,19,18, 16,20,19, 20,21,19, 21,22,19, 22,23,19, 23,24,19, 24,25,26, 24,26,19, 26,27,19, 27,28,19, 27,29,28, 29,30,28, 30,31,28, 31,32,28, 32,33,28, 32,34,33, 32,35,34};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "East Meditarian sea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateRedSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-52f, 8f, y);

        Vector3[] vertices = new Vector3[18];
        vertices[0] = new Vector3(57.6f, y, 0f);
        vertices[1] = new Vector3(53f, y, 3.1f);
        vertices[2] = new Vector3(57.6f, y, 6f);
        vertices[3] = new Vector3(52.8f, y, 3.8f);
        vertices[4] = new Vector3(48.5f, y, 6.4f);
        vertices[5] = new Vector3(49f, y, 10.2f);
        vertices[6] = new Vector3(47.1f, y, 8f);
        vertices[7] = new Vector3(47.5f, y, 9f);
        vertices[8] = new Vector3(48f, y, 10.2f);
        vertices[9] = new Vector3(46.8f, y, 8.8f);
        vertices[10] = new Vector3(46f, y, 10f);
        vertices[11] = new Vector3(46f, y, 9.5f);
        vertices[12] = new Vector3(44.8f, y, 10f);
        vertices[13] = new Vector3(44.8f, y, 10.2f);
        vertices[14] = new Vector3(45.9f, y, 10.3f);
        vertices[15] = new Vector3(44.7f, y, 10.8f);
        vertices[16] = new Vector3(44f, y, 11.5f);
        vertices[17] = new Vector3(44.5f, y, 11.5f);

        int[] tris = new int[] { 0,1,2, 1,3,2, 3,4,2, 4,5,2, 4,6,5, 6,7,5, 7,8,5, 6,9,7, 9,10,7, 9,11,10, 11,12,10, 12,13,10, 13,14,10, 13,15,14, 13,16,15, 16,17,15 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Red sea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateCyprysSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-38f, 21f, y);

        Vector3[] vertices = new Vector3[51];
        vertices[0] = new Vector3(33.1f, y, 17.9f);
        vertices[1] = new Vector3(33.1f, y, 18.9f);
        vertices[2] = new Vector3(34f, y, 20.5f);
        vertices[3] = new Vector3(35.1f, y, 17.9f);
        vertices[4] = new Vector3(34.6f, y, 20.9f); 
        vertices[5] = new Vector3(34.2f, y, 21.3f);
        vertices[6] = new Vector3(33.9f, y, 21.3f);
        vertices[7] = new Vector3(33.4f, y, 21f);
        vertices[8] = new Vector3(35f, y, 20.9f);
        vertices[9] = new Vector3(35.2f, y, 20.7f);
        vertices[10] = new Vector3(35.5f, y, 21f);
        vertices[11] = new Vector3(35.9f, y, 21.1f);
        vertices[12] = new Vector3(37f, y, 18.3f); 
        vertices[13] = new Vector3(36.4f, y, 21.7f);
        vertices[14] = new Vector3(37.5f, y, 22.7f); 
        vertices[15] = new Vector3(36.5f, y, 22.7f);
        vertices[16] = new Vector3(36.2f, y, 22.4f);
        vertices[17] = new Vector3(39.2f, y, 19.1f);
        vertices[18] = new Vector3(39.2f, y, 19.2f);
        vertices[19] = new Vector3(39.3f, y, 19.8f); 
        vertices[20] = new Vector3(37.6f, y, 22.7f);
        vertices[21] = new Vector3(38.3f, y, 22.4f);
        vertices[22] = new Vector3(38.7f, y, 22.5f);
        vertices[23] = new Vector3(39.2f, y, 22.1f);
        vertices[24] = new Vector3(40.2f, y, 22.4f);
        vertices[25] = new Vector3(40.5f, y, 22.8f);
        vertices[26] = new Vector3(41.2f, y, 21f);
        vertices[27] = new Vector3(42f, y, 22f);
        vertices[28] = new Vector3(41f, y, 23.1f);
        vertices[29] = new Vector3(41.6f, y, 24.5f);
        vertices[30] = new Vector3(41.9f, y, 24.3f);
        vertices[31] = new Vector3(42.2f, y, 24.7f);
        vertices[32] = new Vector3(42.6f, y, 24.7f);
        vertices[33] = new Vector3(43.2f, y, 25.4f);
        vertices[34] = new Vector3(42.4f, y, 22f);
        vertices[35] = new Vector3(43.5f, y, 25.9f);
        vertices[36] = new Vector3(43.8f, y, 25.4f);
        vertices[37] = new Vector3(44.2f, y, 23.7f);
        vertices[38] = new Vector3(44f, y, 23.3f);
        vertices[39] = new Vector3(44.7f, y, 22.5f);
        vertices[40] = new Vector3(44.5f, y, 22f);
        vertices[41] = new Vector3(44.5f, y, 21.5f);
        vertices[42] = new Vector3(44.3f, y, 21f);
        vertices[43] = new Vector3(44.4f, y, 20.5f);
        vertices[44] = new Vector3(42f, y, 21f);
        vertices[45] = new Vector3(42.1f, y, 20.7f);
        vertices[46] = new Vector3(41.8f, y, 20.4f);
        vertices[47] = new Vector3(42.2f, y, 20.4f);
        vertices[48] = new Vector3(42.3f, y, 20f);
        vertices[49] = new Vector3(44.55f, y, 18.35f);
        vertices[50] = new Vector3(44f, y, 18.6f);

        int[] tris = new int[] { 0,1,2, 0,2,3, 2,4,3, 2,5,4, 2,6,5, 2,7,6, 4,8,3, 3,8,9, 3,9,10, 3,10,11, 3,11,12, 12,11,13, 13,14,12, 13,15,14, 13,16,15, 12,14,17, 17,14,18, 14,19,18, 14,20,19, 20,21,19, 21,22,19, 22,23,19, 23,24,19, 24,25,19, 25,26,19, 25,27,26, 25,28,27, 28,29,27, 29,30,27, 30,31,27, 31,32,27, 32,33,27, 27,33,34, 33,35,34, 35,36,34, 36,37,34, 37,38,34, 38,39,34, 39,40,34, 40,41,34, 41,42,34, 42,43,34, 34,43,44, 44,43,45, 45,43,46, 47,46,43, 43,48,47, 43,49,48, 49,50,48};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Cyprys sea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateAdriaticSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-14f, 28f, y);

        Vector3[] vertices = new Vector3[61];
        vertices[0] = new Vector3(7.8f, y, 32f);
        vertices[1] = new Vector3(7.6f, y, 32.7f);
        vertices[2] = new Vector3(7.7f, y, 32.8f);
        vertices[3] = new Vector3(8.3f, y, 32.9f);
        vertices[4] = new Vector3(8.9f, y, 33.3f);
        vertices[5] = new Vector3(9.5f, y, 32.5f);
        vertices[6] = new Vector3(9.25f, y, 32.3f);
        vertices[7] = new Vector3(9.45f, y, 32f);
        vertices[8] = new Vector3(9.75f, y, 31.4f); 
        vertices[9] = new Vector3(8f, y, 31.5f);
        vertices[10] = new Vector3(7.9f, y, 30.9f); 
        vertices[11] = new Vector3(10.2f, y, 31.4f);
        vertices[12] = new Vector3(10.3f, y, 32f);
        vertices[13] = new Vector3(10.6f, y, 31.5f);
        vertices[14] = new Vector3(10.3f, y, 32.5f);
        vertices[15] = new Vector3(10.4f, y, 32.5f);
        vertices[16] = new Vector3(10.7f, y, 32.1f);
        vertices[17] = new Vector3(10.9f, y, 31.1f);
        vertices[18] = new Vector3(11.9f, y, 30.2f); 
        vertices[19] = new Vector3(11.2f, y, 31.5f);
        vertices[20] = new Vector3(7.9f, y, 30.8f);
        vertices[21] = new Vector3(8.2f, y, 30.1f);
        vertices[22] = new Vector3(8.6f, y, 29.7f);
        vertices[23] = new Vector3(8.9f, y, 29.7f);
        vertices[24] = new Vector3(9.1f, y, 29.2f);
        vertices[25] = new Vector3(10.5f, y, 28f);
        vertices[26] = new Vector3(12.8f, y, 29.8f);
        vertices[27] = new Vector3(12.8f, y, 29.3f);
        vertices[28] = new Vector3(13.2f, y, 29.1f); 
        vertices[29] = new Vector3(10.5f, y, 27.8f);
        vertices[30] = new Vector3(11f, y, 27.3f);
        vertices[31] = new Vector3(11.5f, y, 27.1f);
        vertices[32] = new Vector3(12f, y, 26.5f);
        vertices[33] = new Vector3(13.7f, y, 29.3f);
        vertices[34] = new Vector3(14.6f, y, 29.1f);
        vertices[35] = new Vector3(14.3f, y, 28.8f);
        vertices[36] = new Vector3(14.6f, y, 28.5f);
        vertices[37] = new Vector3(14.8f, y, 28.5f);
        vertices[38] = new Vector3(15.1f, y, 28.2f);
        vertices[39] = new Vector3(12.6f, y, 26.5f);
        vertices[40] = new Vector3(12.9f, y, 26.2f);
        vertices[41] = new Vector3(13.5f, y, 26.5f);
        vertices[42] = new Vector3(14.1f, y, 26f);
        vertices[43] = new Vector3(15.9f, y, 28.5f);
        vertices[44] = new Vector3(16.2f, y, 28f);
        vertices[45] = new Vector3(16.7f, y, 28f);
        vertices[46] = new Vector3(14.1f, y, 25.7f);
        vertices[47] = new Vector3(14.7f, y, 25.3f);
        vertices[48] = new Vector3(15f, y, 25.3f);
        vertices[49] = new Vector3(15.1f, y, 25.2f);
        vertices[50] = new Vector3(15.7f, y, 24.8f);
        vertices[51] = new Vector3(16.8f, y, 24.8f);
        vertices[52] = new Vector3(16.8f, y, 28.3f);
        vertices[53] = new Vector3(17.8f, y, 27.2f);
        vertices[54] = new Vector3(17.9f, y, 27.3f);
        vertices[55] = new Vector3(18.2f, y, 26.8f);
        vertices[56] = new Vector3(18.3f, y, 26.2f);
        vertices[57] = new Vector3(18.5f, y, 25.7f);
        vertices[58] = new Vector3(18.6f, y, 24.8f);
        vertices[59] = new Vector3(17.5f, y, 24f);
        vertices[60] = new Vector3(18.8f, y, 24.6f);

        int[] tris = new int[] { 0,1,2, 0,2,3, 0,3,4, 0,4,5, 0,5,6, 0,6,7, 0,7,8, 0,8,9, 9,8,10, 10,8,11, 11,12,13, 12,14,13, 14,15,13, 15,16,13, 11,13,17, 10,11,17, 10,17,18, 17,19,18, 10,18,20, 21,20,18, 18,22,21, 18,23,22, 18,24,23, 18,25,24, 18,26,25, 25,26,27, 25,27,28, 25,28,29, 28,30,29, 28,31,30, 28,32,31, 28,33,32, 33,34,35, 33,35,32, 32,35,36, 32,36,37, 32,37,38, 32,38,39, 38,40,39, 38,41,40, 38,42,41, 38,43,42, 42,43,44, 42,44,45, 42,45,46, 45,47,46, 45,48,47, 45,49,48, 45,50,49, 45,51,50, 45,52,51, 51,52,53, 51,53,54, 51,54,55, 51,55,56, 51,56,57, 51,57,58, 51,58,59, 59,58,60};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Adriatic sea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateAegeanSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-29f, 21f, y);

        Vector3[] vertices = new Vector3[112]; 
        vertices[0] = new Vector3(24.6f, y, 16.5f);
        vertices[1] = new Vector3(24.5f, y, 17f);
        vertices[2] = new Vector3(24.6f, y, 17.5f); 
        vertices[3] = new Vector3(27.1f, y, 17.3f);
        vertices[4] = new Vector3(27.5f, y, 17.7f); 
        vertices[5] = new Vector3(24.4f, y, 18.1f);
        vertices[6] = new Vector3(24.7f, y, 18.4f);
        vertices[7] = new Vector3(25.4f, y, 18.4f);
        vertices[8] = new Vector3(25.2f, y, 18.6f);
        vertices[9] = new Vector3(24.8f, y, 18.6f);
        vertices[10] = new Vector3(24.4f, y, 19f);
        vertices[11] = new Vector3(25.6f, y, 18.6f);
        vertices[12] = new Vector3(27.7f, y, 17.7f);
        vertices[13] = new Vector3(28.2f, y, 17.8f);
        vertices[14] = new Vector3(25.2f, y, 19f); 
        vertices[15] = new Vector3(25.2f, y, 19.6f);
        vertices[16] = new Vector3(25.2f, y, 20f);
        vertices[17] = new Vector3(24.9f, y, 20f);
        vertices[18] = new Vector3(24.8f, y, 20.4f);
        vertices[19] = new Vector3(25.5f, y, 20.4f);
        vertices[20] = new Vector3(25.4f, y, 20.7f);
        vertices[21] = new Vector3(26f, y, 21.6f);
        vertices[22] = new Vector3(30.1f, y, 18f);
        vertices[23] = new Vector3(29.4f, y, 17.8f);
        vertices[24] = new Vector3(28.8f, y, 17.7f);
        vertices[25] = new Vector3(28.3f, y, 17.5f);
        vertices[26] = new Vector3(32.3f, y, 20.4f); 
        vertices[27] = new Vector3(32.8f, y, 19f);
        vertices[28] = new Vector3(31.3f, y, 17.8f);
        vertices[29] = new Vector3(31.3f, y, 17.6f); 
        vertices[30] = new Vector3(30.9f, y, 17.4f);
        vertices[31] = new Vector3(31.6f, y, 17.8f);
        vertices[32] = new Vector3(33.1f, y, 17.9f);
        vertices[33] = new Vector3(33.1f, y, 18.9f);
        vertices[34] = new Vector3(32.1f, y, 20.9f); 
        vertices[35] = new Vector3(32.9f, y, 21.1f);
        vertices[36] = new Vector3(32.6f, y, 21.3f);
        vertices[37] = new Vector3(32.4f, y, 21.4f);
        vertices[38] = new Vector3(32.6f, y, 21.6f);
        vertices[39] = new Vector3(32.1f, y, 21.3f);
        vertices[40] = new Vector3(33.4f, y, 21f);
        vertices[41] = new Vector3(33.4f, y, 21.5f);
        vertices[42] = new Vector3(33.6f, y, 21.5f);
        vertices[43] = new Vector3(33.9f, y, 21.3f);
        vertices[44] = new Vector3(31.4f, y, 21f);
        vertices[45] = new Vector3(31.7f, y, 21f);
        vertices[46] = new Vector3(31.3f, y, 21.2f);
        vertices[47] = new Vector3(30.9f, y, 21.6f);
        vertices[48] = new Vector3(31.2f, y, 21.7f);
        vertices[49] = new Vector3(31.4f, y, 21.4f);
        vertices[50] = new Vector3(30.4f, y, 22f);
        vertices[51] = new Vector3(30f, y, 22.5f);
        vertices[52] = new Vector3(30.5f, y, 22.8f);
        vertices[53] = new Vector3(30.6f, y, 22.6f);
        vertices[54] = new Vector3(30.6f, y, 22.2f);
        vertices[55] = new Vector3(29.4f, y, 23.5f);
        vertices[56] = new Vector3(29.6f, y, 23.8f);
        vertices[57] = new Vector3(30.1f, y, 23.4f);
        vertices[58] = new Vector3(30.1f, y, 23.7f);
        vertices[59] = new Vector3(29.5f, y, 24.3f);
        vertices[60] = new Vector3(29.1f, y, 24.8f);
        vertices[61] = new Vector3(28.2f, y, 25f);
        vertices[62] = new Vector3(28.9f, y, 25.3f);
        vertices[63] = new Vector3(29f, y, 25.4f);
        vertices[64] = new Vector3(25.7f, y, 22.2f);
        vertices[65] = new Vector3(25.3f, y, 22.5f);
        vertices[66] = new Vector3(24.7f, y, 22.5f);
        vertices[67] = new Vector3(24.9f, y, 23.4f); 
        vertices[68] = new Vector3(24.6f, y, 23f);
        vertices[69] = new Vector3(24.5f, y, 22.8f);
        vertices[70] = new Vector3(24.4f, y, 23.4f);
        vertices[71] = new Vector3(24.6f, y, 23.6f);
        vertices[72] = new Vector3(25f, y, 23.8f);
        vertices[73] = new Vector3(24.3f, y, 24.2f);
        vertices[74] = new Vector3(25f, y, 24.8f);
        vertices[75] = new Vector3(24.4f, y, 25.3f);
        vertices[76] = new Vector3(23.7f, y, 25f);
        vertices[77] = new Vector3(24f, y, 25.7f);
        vertices[78] = new Vector3(24.45f, y, 25.8f);
        vertices[79] = new Vector3(24.55f, y, 25.6f);
        vertices[80] = new Vector3(25.5f, y, 25f); 
        vertices[81] = new Vector3(25.2f, y, 25f);
        vertices[82] = new Vector3(25.2f, y, 25.4f);
        vertices[83] = new Vector3(24.9f, y, 25.3f);
        vertices[84] = new Vector3(26f, y, 25.3f); 
        vertices[85] = new Vector3(25.8f, y, 25.3f);
        vertices[86] = new Vector3(25.65f, y, 25.45f);
        vertices[87] = new Vector3(25.8f, y, 25.6f);
        vertices[88] = new Vector3(26.1f, y, 25.6f);
        vertices[89] = new Vector3(28.1f, y, 26.1f); 
        vertices[90] = new Vector3(25.7f, y, 26.2f);
        vertices[91] = new Vector3(25.5f, y, 26.8f);
        vertices[92] = new Vector3(25.1f, y, 26.7f);
        vertices[93] = new Vector3(25.5f, y, 26.2f);
        vertices[94] = new Vector3(25.6f, y, 27.1f);
        vertices[95] = new Vector3(26.1f, y, 27.1f);
        vertices[96] = new Vector3(26.4f, y, 27.35f);
        vertices[97] = new Vector3(28f, y, 26.9f);
        vertices[98] = new Vector3(26.7f, y, 27.6f);
        vertices[99] = new Vector3(27.1f, y, 27.4f);
        vertices[100] = new Vector3(28f, y, 27.7f);
        vertices[101] = new Vector3(27.6f, y, 27.2f);
        vertices[102] = new Vector3(28.9f, y, 27.1f);
        vertices[103] = new Vector3(28.3f, y, 27.3f);
        vertices[104] = new Vector3(29.2f, y, 28f); 
        vertices[105] = new Vector3(29.4f, y, 27.2f);
        vertices[106] = new Vector3(30.4f, y, 27.8f);
        vertices[107] = new Vector3(29.3f, y, 28.7f); 
        vertices[108] = new Vector3(30.8f, y, 27.7f);
        vertices[109] = new Vector3(31.5f, y, 28.1f);
        vertices[110] = new Vector3(31.3f, y, 28.6f);
        vertices[111] = new Vector3(30f, y, 29f);

        int[] tris = new int[] { 0,1,2, 0,2,3, 2,4,3, 2,5,4, 5,6,4, 6,7,4, 6,8,7, 6,9,8, 6,10,9, 7,11,4, 11,12,4, 11,13,12, 11,14,13, 13,14,15, 13,15,16, 15,17,16, 17,18,16, 13,16,19, 13,19,20, 13,20,21, 13,21,22, 13,22,23, 13,23,24, 13,24,25, 21,26,22, 22,26,27, 22,27,28, 22,28,29, 22,29,30, 28,27,31, 31,27,32, 32,27,33, 21,34,26, 34,35,26, 34,36,35, 34,37,36, 37,38,36, 34,39,37, 26,35,40, 35,41,40, 41,42,40, 42,43,40, 34,44,45, 21,44,34, 21,46,44, 21,47,46, 47,48,46, 48,49,46, 21,50,47, 21,51,50, 51,52,50, 52,53,50, 53,54,50, 21,55,51, 55,56,57, 56,58,57, 21,56,55, 21,59,56, 21,60,59, 21,61,60, 61,62,60, 62,63,60, 21,64,61, 64,65,61, 65,66,61, 66,67,61, 66,68,67, 66,69,68, 68,70,67, 70,71,67, 67,72,61, 72,73,61, 73,74,61, 73,75,74, 73,76,75, 76,77,75, 77,78,75, 78,79,75, 74,80,61, 74,81,80, 81,82,80, 81,83,82, 80,84,61, 80,85,84, 85,86,84, 86,87,84, 84,88,61, 88,89,61, 88,90,89, 90,91,89, 90,92,91, 90,93,92, 91,94,89, 94,95,89, 95,96,89, 96,97,89, 96,98,97, 98,99,97, 99,100,101, 99,101,97, 89,97,102, 97,103,102, 103,104,102, 102,104,105, 105,104,106, 104,107,106, 107,108,106, 107,109,108, 107,110,109, 107,111,110};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Aegean sea";
        Regions.Add(new Region(tile, positions));
    }

    private void GenerateBlackSea()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;
        InternalPositions positions = new InternalPositions();
        positions.FleetPosition = new Vector3(-38f, 37f, y);

        Vector3[] vertices = new Vector3[116];
        vertices[0] = new Vector3(31.3f, y, 28.6f);
        vertices[1] = new Vector3(30f, y, 29f);
        vertices[2] = new Vector3(31.6f, y, 28.6f);
        vertices[3] = new Vector3(31.9f, y, 29f);
        vertices[4] = new Vector3(31.8f, y, 29.1f);
        vertices[5] = new Vector3(31.6f, y, 29.4f);
        vertices[6] = new Vector3(31.8f, y, 29.9f); 
        vertices[7] = new Vector3(30.4f, y, 30.2f);
        vertices[8] = new Vector3(29.2f, y, 31.2f);
        vertices[9] = new Vector3(29f, y, 31.8f); 
        vertices[10] = new Vector3(33.6f, y, 30.6f);
        vertices[11] = new Vector3(34f, y, 31.2f);
        vertices[12] = new Vector3(34.3f, y, 31.5f);
        vertices[13] = new Vector3(34.6f, y, 31.9f);
        vertices[14] = new Vector3(34.9f, y, 32.1f);
        vertices[15] = new Vector3(35.3f, y, 32.7f);
        vertices[16] = new Vector3(36f, y, 33.2f);
        vertices[17] = new Vector3(29f, y, 32.2f); 
        vertices[18] = new Vector3(28.6f, y, 31.6f);
        vertices[19] = new Vector3(28.6f, y, 32f);
        vertices[20] = new Vector3(28.7f, y, 33f);
        vertices[21] = new Vector3(28.7f, y, 33.5f);
        vertices[22] = new Vector3(29.2f, y, 33.5f);
        vertices[23] = new Vector3(28.7f, y, 35f);
        vertices[24] = new Vector3(28.6f, y, 35.2f);
        vertices[25] = new Vector3(28.7f, y, 35.6f);
        vertices[26] = new Vector3(28.7f, y, 35.7f);
        vertices[27] = new Vector3(29.2f, y, 35.9f);
        vertices[28] = new Vector3(28.9f, y, 36.2f);
        vertices[29] = new Vector3(29f, y, 36.25f);
        vertices[30] = new Vector3(29.3f, y, 36.52f);
        vertices[31] = new Vector3(29.4f, y, 36.6f);
        vertices[32] = new Vector3(29.5f, y, 37.6f);
        vertices[33] = new Vector3(34.9f, y, 37.5f); 
        vertices[34] = new Vector3(34.8f, y, 37.7f);
        vertices[35] = new Vector3(34.5f, y, 37.9f);
        vertices[36] = new Vector3(34.6f, y, 38.4f);
        vertices[37] = new Vector3(33.9f, y, 38.8f);
        vertices[38] = new Vector3(33.4f, y, 38.7f);
        vertices[39] = new Vector3(33.1f, y, 38.5f);
        vertices[40] = new Vector3(32.7f, y, 38.6f);
        vertices[41] = new Vector3(29.255f, y, 37.885f);
        vertices[42] = new Vector3(29.3f, y, 38.1f);
        vertices[43] = new Vector3(29.7f, y, 38.7f);
        vertices[44] = new Vector3(29.6f, y, 39.3f);
        vertices[45] = new Vector3(30.1f, y, 39.5f); 
        vertices[46] = new Vector3(31.2f, y, 39.8f); 
        vertices[47] = new Vector3(30.1f, y, 40.2f);
        vertices[48] = new Vector3(31.1f, y, 40.1f);
        vertices[49] = new Vector3(31.3f, y, 40.9f);
        vertices[50] = new Vector3(31.5f, y, 40.7f); 
        vertices[51] = new Vector3(31.4f, y, 40.2f);
        vertices[52] = new Vector3(33f, y, 40.4f);
        vertices[53] = new Vector3(33.2f, y, 39.7f);
        vertices[54] = new Vector3(32.9f, y, 39.3f);
        vertices[55] = new Vector3(32.9f, y, 38.9f);
        vertices[56] = new Vector3(35.2f, y, 37.6f);
        vertices[57] = new Vector3(35.4f, y, 38.1f);
        vertices[58] = new Vector3(36.3f, y, 33.3f);
        vertices[59] = new Vector3(36.5f, y, 33.6f);
        vertices[60] = new Vector3(37f, y, 33.7f);
        vertices[61] = new Vector3(38.3f, y, 34.4f);
        vertices[62] = new Vector3(35.4f, y, 38.6f); 
        vertices[63] = new Vector3(35.8f, y, 39f);
        vertices[64] = new Vector3(36f, y, 39.5f);
        vertices[65] = new Vector3(36.9f, y, 40.1f);
        vertices[66] = new Vector3(37.3f, y, 40.1f);
        vertices[67] = new Vector3(37.6f, y, 40.7f); 
        vertices[68] = new Vector3(38.6f, y, 40.7f);
        vertices[69] = new Vector3(38.6f, y, 41f); 
        vertices[70] = new Vector3(39f, y, 41.3f);
        vertices[71] = new Vector3(38.9f, y, 41.6f); 
        vertices[72] = new Vector3(37.1f, y, 40.7f);
        vertices[73] = new Vector3(39.2f, y, 42.5f); 
        vertices[74] = new Vector3(39.2f, y, 41.8f);
        vertices[75] = new Vector3(36.5f, y, 42.5f);
        vertices[76] = new Vector3(35.2f, y, 41.7f);
        vertices[77] = new Vector3(35.1f, y, 41.5f);
        vertices[78] = new Vector3(35.5f, y, 41.1f); 
        vertices[79] = new Vector3(36.7f, y, 40.5f);
        vertices[80] = new Vector3(36.4f, y, 40.5f);
        vertices[81] = new Vector3(35.8f, y, 40.2f);
        vertices[82] = new Vector3(35.4f, y, 40.6f);
        vertices[83] = new Vector3(35.1f, y, 40.8f);
        vertices[84] = new Vector3(34.4f, y, 40.6f);
        vertices[85] = new Vector3(34.3f, y, 40.9f);
        vertices[86] = new Vector3(34.8f, y, 41.2f);
        vertices[87] = new Vector3(39f, y, 40.7f);
        vertices[88] = new Vector3(39.1f, y, 40f);
        vertices[89] = new Vector3(39.5f, y, 40.1f);
        vertices[90] = new Vector3(39.8f, y, 39.9f);
        vertices[91] = new Vector3(40.6f, y, 40.3f);
        vertices[92] = new Vector3(40.8f, y, 40f);
        vertices[93] = new Vector3(41.4f, y, 40.2f);
        vertices[94] = new Vector3(42f, y, 39.7f);
        vertices[95] = new Vector3(42.6f, y, 39.9f);
        vertices[96] = new Vector3(42.8f, y, 39.7f); 
        vertices[97] = new Vector3(39f, y, 33.8f);
        vertices[98] = new Vector3(40f, y, 34.2f);
        vertices[99] = new Vector3(40.7f, y, 34f);
        vertices[100] = new Vector3(41.5f, y, 34.2f);
        vertices[101] = new Vector3(41.9f, y, 34.1f);
        vertices[102] = new Vector3(42f, y, 34f);
        vertices[103] = new Vector3(42.3f, y, 34f);
        vertices[104] = new Vector3(42.7f, y, 34.4f);
        vertices[105] = new Vector3(43.1f, y, 34.4f);
        vertices[106] = new Vector3(43.7f, y, 34.5f);
        vertices[107] = new Vector3(44.7f, y, 35.5f);
        vertices[108] = new Vector3(45.8f, y, 36f);
        vertices[109] = new Vector3(46.4f, y, 36.6f);
        vertices[110] = new Vector3(46.4f, y, 37.2f); 
        vertices[111] = new Vector3(43.6f, y, 39.7f);
        vertices[112] = new Vector3(44f, y, 39.3f);
        vertices[113] = new Vector3(45f, y, 39.3f);
        vertices[114] = new Vector3(46.2f, y, 38.7f);
        vertices[115] = new Vector3(46.7f, y, 37.7f);

        int[] tris = new int[] { 0,1,2, 1,3,2, 1,4,3, 1,5,4, 1,6,5, 1,7,6, 7,8,6, 8,9,6, 9,10,6, 9,11,10, 9,12,11, 9,13,12, 9,14,13, 9,15,14, 9,16,15, 9,17,16, 9,18,17, 18,19,17, 17,20,16, 20,21,16, 21,22,16, 22,23,16, 23,24,16, 24,25,16, 25,26,16, 26,28,27, 28,29,27, 16,26,27, 16,27,30, 16,30,31, 16,31,32, 16,32,33, 32,34,33, 32,35,34, 37,36,35, 38,37,35, 39,38,35, 32,39,35, 32,40,39, 32,41,40, 41,42,40, 42,43,40, 43,44,40, 44,45,40, 45,46,40, 45,47,46, 47,48,46, 47,49,48, 49,50,48, 50,51,48, 46,52,53, 46,53,54, 46,54,55, 46,55,40, 16,33,56, 16,56,57, 16,57,58, 57,59,58, 57,60,59, 57,61,60, 57,62,61, 62,63,61, 63,64,61, 64,65,61, 65,66,61, 66,67,61, 67,68,61, 67,69,68, 67,70,69, 67,71,70, 67,72,71, 72,73,71, 73,74,71, 72,75,73, 72,76,75, 72,77,76, 72,78,77, 72,79,78, 78,79,80, 78,80,81, 78,81,82, 78,82,83, 82,84,83, 84,85,83, 85,86,83, 61,68,87, 61,87,88, 61,88,89, 61,89,90, 61,90,91, 61,91,92, 61,92,93, 61,93,94, 61,94,95, 61,95,96, 61,96,97, 98,97,96, 99,98,96, 100,99,96, 101,100,96, 102,101,96, 103,102,96, 104,103,96, 105,104,96, 106,105,96, 107,106,96, 108,107,96, 109,108,96, 110,109,96, 96,111,112, 96,112,110, 112,113,110, 113,114,110, 114,115,110};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Black sea";
        Regions.Add(new Region(tile, positions));
    }

    private void Update()
    {
        if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("MapTile", "Hover")))
        {
            GameObject hited = info.transform.gameObject;
            //GameObject mapTile = mapTiles.FirstOrDefault(m => m.name == hited.name);

            if (hoveredMapTile == null)
            {
                hited.layer = LayerMask.NameToLayer("Hover");
                hoveredMapTile = hited;

            }
        }
        else
        {
            if (hoveredMapTile != null)
            {
                hoveredMapTile.layer = LayerMask.NameToLayer("MapTile");
                hoveredMapTile = null;
            }
        }
    }
}
