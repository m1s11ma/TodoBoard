using TodoBoardCore.Data.Common;
using TodoBoardCore.Exceptions.TodoItems;

namespace TodoBoardCore.Data.ValueObjects
{
    public sealed class TodoItemColour : ValueObject
    {
        public string Colour { get; init; }

        private TodoItemColour(string colour)
        {
            Colour = colour;
        }

        public static TodoItemColour From(string colour)
        {
            var newColour = new TodoItemColour(colour);
            if (!SupportedColours.Contains(newColour)) throw new UnsupportedColourException(colour);
            return newColour;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Colour;
        }

        public override string ToString()
        {
            return Colour;
        }

        public static TodoItemColour Red => new("Red");
        public static TodoItemColour Green => new("Green");
        public static TodoItemColour Blue => new("Blue");

        protected static IEnumerable<TodoItemColour> SupportedColours { get
            {
                yield return Red;
                yield return Green;
                yield return Blue;
            } }
    }
}
