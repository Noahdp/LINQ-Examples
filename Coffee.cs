namespace LinqExamples
{
    public class Coffee
    {
        public Brew CoffeeBrew { get; }

        public Flavor CoffeeFlavor { get; }

        public Size CoffeeSize {get; }

        public Coffee(Brew b, Flavor f, Size s)
        {
            CoffeeBrew = b;
            CoffeeFlavor = f;
            CoffeeSize = s;
        }

        public string Order()
        {
            return $"A {CoffeeSize} {CoffeeFlavor} {CoffeeBrew}!";
        }

        public enum Brew
        {   
            Hot,
            Iced,
            PourOver,
            FrenchPress,
            Latte,
            Espresso
        }

        public enum Flavor
        {   
            Vanilla,
            Caramel,
            Mocha,
            PumpkinSpice,
            Honey,
            PeanutButter,
            Lavender,
            WhiteChoclate,
            Cinnamon
        }       

        public enum Size
        {
            Small,
            Medium,
            Large
        }
    }
}