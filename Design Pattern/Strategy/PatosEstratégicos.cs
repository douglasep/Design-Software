// Este exemplo foi retirado do livro Head First - Design Patterns
// Exemplo dos patos modificado por Christopher Okhravi
// em: youtube.com/watch?v=v9ejT8FO-7I&t=1290s


// Este exemplo se inicia onde temos apenas dois tipos de patos: Selvagens e da Cidade
// Onde estes patos podem: 
//      Selvagens - Mostrar, Voar e fazer quackquack
//      daCidade - Mostrar, Voar e fazer quackquack

// Aqui poderiamos apenas definir a classe Pai Duck (fly e quack)
// e Definirmos duas heranças WildDuck e CityDuck (método: mostram de suas formas)

// Dai surge a necessidade de adicionarmos outro tipo de pato: Pato de Borracha
//      Borracha - Mostrar, Não voa e Não faz quack
// Aqui deveriamos implementar os 3 métodos de diferentes formas apenas para o pato de borracha
// Criar um comportamento de "Não Voar" para o patinho de borracha

// Então surge o MontainDuck
// Este também possui uma forma diferente de Voar(), então teriamos que implementar outro método para esta classe

// Dai vem o CloudDuck
// O CloudDuck voa igual o Montain Duck, ou seja, o médoto que já foi implementado no MontainDuck terá que ser implementado aqui também

// Usando hierarquias
// Simplificando as implementações dos métodos ficariam assim:
//  Duck -  Display() | Fly() | Quack() 
//      CityDuck : Duck - Display()
//      WildDuck : Duck - Display()
//      RubberDuck : Duck - Display() | NoFly() | NoQuack()
//      MontainDuck : Duck - Display() | SuperFly()
//      ClourDuck : Duck - Display() | SuperFly()


// Aplicando Strategy Pattern

public abstract class Duck
{
    // definindo as interfaces
    IFlyBehavior flyBehavior;
    IQuackBehavior quackBehavior;
    IDisplayBehavior displayBehavior;
    // obs: Se definíssemos os behaviors aqui (hard-code), não consegueriamos implementá-los nos ducks 

    // constructor
    public Duck(
        FlyBehavior flyBehavior,
        QuackBehavior quackBehavior,
        DisplayBehavior displayBehavior)
    {
        this.flyBehavior = flyBehavior;
        this.quackBehavior = quackBehavior;
        this.displayBehavior = displayBehavior;
    }
	
    // métodos
    public void performFly() {
		flyBehavior.Fly();
	}

	public void performQuack() {
		quackBehavior.Quack();
    }

    public void performDisplay() {
        displayBehavior.Display();
    }
}

// CLASSES "FILHAS"

class CityDuck : Duck
{
	flyBehavior = new SimpleFlying();
    quackBehavior = new SimpleQuacking();
    displayBehavior = new AsTextDisplaying();
}

public class WildDuck : Duck 
{
    flyBehavior = new SimpleFlying();
    quackBehavior = new SimpleQuacking();
    displayBehavior = new AsTextDisplaying();
}

public class RubberDuck : Duck
{
 	flyBehavior = new NoFlying();
    quackBehavior = new NoQuacking();
    displayBehavior = new GraphicalDisplaying();   
}
public class CloudDuck : Duck
{
    flyBehavior = new SuperFlying();
    quackBehavior = new SimpleQuacking();
    displayBehavior = new GraphicalDisplaying();
}

class MontainDuck : Duck
{
    flyBehavior = new SuperFlying();
    quackBehavior = new SimpleQuacking();
    displayBehavior = new GraphicalDisplaying();
}

// BEHAVIORS CLASSES (STRATEGIES)

class SimpleQuacking : IQuackBehavior
{
    void Quack()
    {
        // Estratégia de Quack simples
        Console.WriteLine("QUACK!!!")
    }
}

class NoQuacking : IQuackBehavior
{
    void Quack()
    {
        // Estratégia sem Quack
        Console.WriteLine("[...]")
    }
}

class SimpleFlying : IFlyBehavior
{
    void Fly()
    {
        // Estratégia de vôo simples
        Console.WriteLine("Eu vôo normalmente :)")
    }
}

public class NoFlying : IFlyBehavior
{
    public void Fly()
    {
        // Estratégia sem vôo
        Console.WriteLine("Eu não sei voar")
    }
} 

class SuperFlying : IFlyBehavior
{
    void Fly()
    {
        // Estratégia SUPER vôo a jato
        Console.WriteLine("Eu tenho um SUPER vôo a jato u.U")
    }
}


class GraphicalDisplaying : IDisplayBehavior
{
    void Display()
    {
        // Estratégia para mostrar graficamente
    }
}

class AsTextDisplaying : IDisplayBehavior
{
    void Display()
    {
        // Estratégia para mostrar uma string
    }
}
// INTERFACES

public interface IQuackBehavior
{
    public void Quack();
}

public interface IFlyBehavior
{
    public void Fly();
}

public interface IDisplayBehavior
{
    public void Display();
}
