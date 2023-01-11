using System;
using System.Globalization;
public class cardHolder{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;
    String cpf;

    public cardHolder(String cardNum, int pin, string firstName, string lastName, double balance, String cpf){
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
        this.cpf = cpf;
    }

    public String getNum(){
        return cardNum;
    }
    public int getPin(){
        return pin;
    }
    public String getFirstName(){
        return firstName;
    }
    public String getLastName(){
        return lastName;
    }
    public double getBalance(){
        return balance;
    }
    public String getCpf(){
        return cpf;
    }
    
    public void setNum(String cardNum){
        this.cardNum = cardNum;
    }
    public void setPin(int pin){
        this.pin = pin;
    }
    public void setFirstName(String firstName){
        this.firstName = firstName;
    }
    public void setLastName(String lastName){
        this.lastName = lastName;
    }
    public void setBalance(double balance){
        this.balance = balance;
    }
    public void setCpf(String cpf){
        this.cpf = cpf;
    }

    public static void Main(String[] args){
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        void printOptions(){
            Console.WriteLine("Por favor, escolha uma das opções abaixo...");
            Console.WriteLine("1. Depósito");
            Console.WriteLine("2. Saque");
            Console.WriteLine("3. Mostrar Saldo");
            Console.WriteLine("4. Sair");
        }
        void deposit(cardHolder currentUser){
            Console.WriteLine("Quanto R$ você deseja depositar? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Depósito efetuado com sucesso. Seu novo saldo é: R$"+currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser){
            Console.WriteLine("Quanto R$ você deseja sacar? ");
            double withdraw = Double.Parse(Console.ReadLine());
            //Checa se o usuario tem dinheiro
            if(currentUser.getBalance() < withdraw){
                Console.WriteLine("Saldo insuficiente");
            }
            else{
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Saque efetuado com sucesso! Muito obrigado");
            }
        }
        void balance(cardHolder currentUser){
            Console.WriteLine("Saldo atual: R$" + currentUser.getBalance());
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("5256894721660216", 1234, "Gabriel", "Coelho", 297.50, "80196161010"));
        cardHolders.Add(new cardHolder("8759997787841437", 2345, "Luciano", "Huck", 190.72, "73959137010"));
        cardHolders.Add(new cardHolder("6855955190799104", 3456, "Talita", "Werneck", 861.20, "62599551030"));
        cardHolders.Add(new cardHolder("2598102174337609", 4567, "Filipe", "Ayrosa", 4.90, "44684146006"));
        cardHolders.Add(new cardHolder("8617137925138870", 5678, "Thiago", "Ventura", 420.90, "71857853083"));

        //Interface do usuario
        Console.WriteLine("Bem vindo ao BanquinhoBrasil");
        Console.WriteLine("Insira o seu cartão de débito: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true){
            try{
                debitCardNum = Console.ReadLine();
                //checar se eh valido
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) break;
                else Console.WriteLine("Cartão não identificado. Tente novamente");
            }
            catch {Console.WriteLine("Cartão não identificado. Tente novamente");}
        }
        Console.WriteLine("Insira a sua senha: ");
        int userPin = 0;
        while(true){
            try{
                userPin = int.Parse(Console.ReadLine());
                if(currentUser.getPin() == userPin) break;
                else Console.WriteLine("Senha incorreta. Tente novamente");
            }
            catch {Console.WriteLine("Senha incorreta. Tente novamente");}
        }

        Console.WriteLine("Olá, "+currentUser.getFirstName());
        int option = 0;
        do{
            printOptions();
            try{
                option = int.Parse(Console.ReadLine());
            }
            catch{}
            if(option == 1) deposit(currentUser);
            else if(option == 2) withdraw(currentUser);
            else if (option == 3) balance(currentUser);
            else if (option == 4) break;
            else option = 0;
        }
        while(option != 4);
        Console.WriteLine("Obrigado! Desejamos um bom dia a você");
    }

    
}
    

