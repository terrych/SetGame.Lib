using SetGame.Set;

namespace SetGame.Test
{
    /// <summary>
    /// For visualization number takes form: Position3, position 2, position 1, position 0
    /// Position0: count. Digit + 1 is count.
    /// Position1: shape. 0 is squiggles, 1 is diamonds, 2 is ovals.
    /// Position2: color. 0 is red, 1 is green, 2 is blue.
    /// Position3: shading. 0 is solid, 1 is lines(shaded), 2 is empty
    /// </summary>

    [TestClass]
    public abstract class OriginalGameTests
    {
        public Game TheGame = new Game(3, 4);
    }
}