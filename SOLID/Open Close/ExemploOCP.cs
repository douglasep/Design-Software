// Exemplo dado pelo Eduardo Pires
// Vídeo Youtube => SOLID - Teoria e Prática
// OPEN CLOSE => Classes fechada para modificações mas aberta para extensões 

// OCP/DebitoConta.cs

public abstract class DebitoConta
{
    public string NumeroTransacao { get; set; }
    public abstract string Debitar(decimal valor, string conta);

}

// OCP/DebitoContaCorrente.cs

public class DebitoContaCorrente : DebitoConta
{
//OVERRIDE da debitar
    public override string Debitar(decimal valor, string conta, TipoConta tipoConta)
    {
        // Lógica de Negócio ->> Debita Conta Corrente
        return NumeroTransacao;
    }
}

// OCP/DebitoContaInvestimento.cs

public class DebitoContaInvestimento : DebitoConta
{
    public override string Debitar(decimal valor, string conta, TipoConta tipoConta)
    {
        // Regra de Negócio ->> 
        // Debita Conta Investimento
        // Isenta Taxas
        return NumeroTransacao;
    }
}

// Desta forma podemos notar que cada vez que tivermos que modificar a classe Debito em Conta podemos apenas incluir uma nova classe
// Em outras palavras a classe DebitoConta está fechada para modificações mas aberta para extensões

// Poderia ser assim, forma XGH :(
// Desta forma sempre que tivermos que implementar um novo tipo de Conta devemos modificar a classe DebitoConta, e isto pode facilmente quebrar nosso código
    public class DebitoConta
    {
        public string NumeroTransacao { get; set; }
        
        public override string Debitar(decimal valor, string conta, TipoConta tipoConta)
        {
            if(ContaCorrente)
            {
                // Lógica de Negócio ->> Debita Conta Corrente                    
                return NumeroTransacao;
            }
            if(ContaInvestimento)
            {
                // Lógica de Negócio ->> Debita Conta Corrente                    
                return NumeroTransacao;
            }
        }

    }
