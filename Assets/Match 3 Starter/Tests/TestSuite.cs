using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class TestSuite
{
    private Game game;
    private BoardManager boardManager;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
            Object.Instantiate(Resources.Load<GameObject>("Prefab/Game"));
        game = gameGameObject.GetComponent<Game>();
        boardManager = game.GetBoard();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(game.gameObject);
    }

    // Test para verificar una combinación de tres fichas
    [Test]
    public void TestThreeTileCombination()
    {
        // Configura un tablero con tres fichas adyacentes iguales
        string[,] grid = {
            { "R", "R", "R", "P", "R", "P", "R", "G"},
            { "B", "P", "Y", "R", "G", "R", "P", "R" },
            { "G", "B", "P", "B", "P", "Y", "G", "Y"},
            { "G", "P", "Y", "R", "R", "R", "R", "P"},
            { "P", "B", "P", "G", "Y", "P", "G", "P"},
            { "G", "Y", "G", "R", "R", "R", "Y", "Y"},
            { "P", "B", "B", "Y", "Y", "G", "P", "Y"},
            { "G", "B", "P", "R", "R", "P", "G", "G"}
        };

        boardManager.InitializeBoard(grid);

        // Llama al método para verificar combinaciones en las posiciones
        var matches = boardManager.FindMatches(new Vector2Int(0, 0));  // Busca combinaciones en la primera posición

        // Verifica si la combinación encontrada tiene 3 elementos
        Assert.AreEqual(matches.Count, 3);
    }

    // Test para verificar una combinación especial de cuatro fichas
    [Test]
    public void TestSpecialFourTileCombination()
    {
        // Configura un tablero con cuatro fichas adyacentes iguales
        string[,] grid = {
            { "R", "R", "R", "R", "G", "P", "R", "G"},
            { "B", "P", "Y", "R", "G", "R", "P", "R" },
            { "G", "B", "P", "B", "P", "Y", "G", "Y"},
            { "G", "P", "Y", "R", "R", "R", "R", "P"},
            { "P", "B", "P", "G", "Y", "P", "G", "P"},
            { "G", "Y", "G", "R", "R", "R", "Y", "Y"},
            { "P", "B", "B", "Y", "Y", "G", "P", "Y"},
            { "G", "B", "P", "R", "R", "P", "G", "G"}
        };

        boardManager.InitializeBoard(grid);

        // Llama al método para verificar combinaciones en las posiciones
        var matches = boardManager.FindMatches(new Vector2Int(0, 0));  // Busca combinaciones en la primera posición

        // Verifica si la combinación encontrada tiene 4 elementos
        Assert.AreEqual(matches.Count, 4);
    }

    // Test para verificar que no haya combinaciones disponibles
    [Test]
    public void TestNoAvailableCombinations()
    {
        // Configura un tablero sin combinaciones posibles
        string[,] grid = {
            { "Y", "R", "G", "P", "B", "B", "P", "R" },
            { "B", "P", "Y", "R", "G", "P", "G", "Y" },
            { "G", "B", "G", "B", "P", "Y", "G", "M" },
            { "G", "M", "Y", "M", "R", "M", "R", "P" },
            { "B", "P", "P", "G", "B", "P", "R", "Y" },
            { "G", "Y", "G", "R", "M", "M", "Y", "B" },
            { "P", "B", "M", "Y", "Y", "G", "P", "G" },
            { "G", "B", "P", "R", "P", "M", "B", "Y" }
        };

        boardManager.InitializeBoard(grid);

        // Llama al método para verificar combinaciones en todas las posiciones
        bool hasMatches = false;
        for (int x = 0; x < boardManager.xSize; x++)
        {
            for (int y = 0; y < boardManager.ySize; y++)
            {
                var matches = boardManager.FindMatches(new Vector2Int(x, y));
                if (matches.Count >= 3)
                {
                    hasMatches = true;
                    break;
                }
            }
        }

        // Verifica que no haya combinaciones
        Assert.IsFalse(hasMatches);
    }
}