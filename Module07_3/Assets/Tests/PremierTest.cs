using NUnit.Framework;
using System.Collections.Generic;

public class PremierTest
{
    [Test]
    public void TestQuiPasse()
    {
        Assert.Pass();
    }

    [Test]
    public void TestQuiNePassePas()
    {
        Assert.AreEqual(5, 2 + 2);
    }

    [Test]
    public void TrouverPlusPrecieux_Simple1()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() {
            new TestPrecieux { Valeur = 10 },
            new TestPrecieux { Valeur = 50 },
            new TestPrecieux { Valeur = 20 }
         };
        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);
        // Assert
        Assert.AreEqual(50, plusPrecieux.Valeur);
    }


    [Test]
    public void TrouverPlusPrecieux_Simple2()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() {
            new TestPrecieux { Valeur = -10 },
            new TestPrecieux { Valeur = -50 },
            new TestPrecieux { Valeur = 20 }
         };

        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);
        // Assert
        Assert.AreEqual(20, plusPrecieux.Valeur);
    }



    [Test]
    public void TrouverPlusPrecieux_Simple3()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() {};
        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);
        // Assert
        Assert.AreEqual( null , plusPrecieux.Valeur);
    }

    [Test]
    public void TrouverPlusPrecieux_Simple4()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new() {
            new TestPrecieux { Valeur = 20 }
         };
        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);
        // Assert
        Assert.AreEqual(20, plusPrecieux.Valeur);
    }

}
