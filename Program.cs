using System;
using System.Collections.Generic;
public class Backlog {
    protected string titulo, status, descricao;
    protected long ID;
    protected int horas;
    public Backlog(){
        System.Console.WriteLine("Digite o titulo deste backlog:");
        System.Console.Write("> ");
        titulo = Console.ReadLine();
        System.Console.WriteLine("Digite a descricao deste backlog:");
        System.Console.Write("> ");
        descricao = Console.ReadLine();
        bool lacoStatus = false;
        while (!lacoStatus) {
            System.Console.WriteLine("Digite o status deste backlog (a comecar, em progresso, pronto):");
            System.Console.Write("> ");
            var temp = Console.ReadLine();
            if (temp == "a comecar" || temp == "em progresso" || temp == "pronto") {
                status = temp;
                lacoStatus = true;
            }
        }
        System.Console.WriteLine("Digite o numero de horas deste backlog:");
        System.Console.Write("> ");
        try {
            horas = Convert.ToInt32(Console.ReadLine());
        } catch (Exception e) {
            System.Console.WriteLine("Voce nao digitou um numero inteiro, {0}", e);
        }
        ID = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    } 
    public string getTitulo() {
        return this.titulo;
    }  
    public string getStatus() {
        return this.status;
    }    
    public long getID() {
        return this.ID;
    }
    public string getDescricao() {
        return this.descricao;
    }    
    public int getHoras() {
        return this.horas;
    }
    public void setTitulo(string titulo){
        this.titulo = titulo;
    }
    public void setID(long ID){
        this.ID = ID;
    }
    public void setDescricao(string descricao){
        this.descricao = descricao;
    }                    
    public void setStatus(string status){
        this.status = status;
    }    
    public void setHoras(int horas) {
        this.horas = horas;
    }
    public virtual string getType(){
        return "";
    }
}
    class Feature : Backlog {
    string criteriosDeAceite;
    public Feature(){
    System.Console.WriteLine("Digite os criterios de aceite");
    System.Console.Write("> ");
    criteriosDeAceite = Console.ReadLine();
    System.Console.WriteLine("Backlog criado!");
    }
    public override string getType(){
        return "Feature";
    }
}
    class Mudanca : Backlog {
    string mudanca;
    public Mudanca(){
        System.Console.WriteLine("Qual feature voce gostaria de mudar?");
        System.Console.Write("> ");
        mudanca = Console.ReadLine();
        System.Console.WriteLine("Backlog criado!");
    }
    public string getMudanca(){
        return this.mudanca;
    }
    public void setMudanca(string mudanca) {
        this.mudanca = mudanca;
    }
    public override string getType() {
        return "Mudanca";
    }
}
    class Defeito : Backlog {
    string reproducaoDoProblema;
    public Defeito(){
        System.Console.WriteLine("Digite a reproducao do problema:");
        reproducaoDoProblema = Console.ReadLine();
        System.Console.WriteLine("Backlog criado!");
    }
    public string getProblema(){
        return this.reproducaoDoProblema;
    }
    public void setProblema(string reproducaoDoProblema){
        this.reproducaoDoProblema = reproducaoDoProblema;
    }
    public override string getType() {
        return "Defeito";
    }
}
    class DebitoTecnico : Backlog {
    string justificativa;
    public DebitoTecnico(){
        System.Console.WriteLine("Qual a justificativa?");
        System.Console.Write("> ");
        justificativa = Console.ReadLine();
        System.Console.WriteLine("Backlog criado!");
    }
    public string getJustificativa() {
        return this.justificativa;
    }
    public void setJustificativa(string justificativa) {
        this.justificativa = justificativa;
    }
    public override string getType() {
        return "Debito Tecnico";
    }
}
class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        System.Console.WriteLine("--------------Backlog System--------------");
        List<Backlog> backlogList = new List<Backlog>();
        bool fimLaco = false;
        while (!fimLaco) {
            System.Console.WriteLine("Digite \"ajuda\" \"feature\" \"mudanca\" \"defeito\" \"DT\" \"listar\" ou \"sair\"");
            System.Console.Write("> ");
            string comando = Console.ReadLine();
            switch (comando) {
                case "ajuda": 
                    Console.Clear();
                    mostrarAjuda();
                    break; 
                case "feature":
                    Console.Clear();
                    backlogList.Add(new Feature());
                    break;
                case "mudanca":
                    Console.Clear();                    
                    backlogList.Add(new Mudanca());
                    break;
                case "defeito":
                    Console.Clear();
                    backlogList.Add(new Defeito());
                    break;
                case "DT":
                    Console.Clear();
                    backlogList.Add(new DebitoTecnico());
                    break;
                case "listar":
                    Console.Clear();                
                    listarBacklogList(backlogList);
                    break;
                case "sair":
                    fimLaco = true;
                    break;
                default: 
                    break;
            }
        }
    }
static void mostrarAjuda() {
        Console.WriteLine("ajuda - listar possíveis comandos e descrições");
        Console.WriteLine("sair - desligar o programa");
    }
static void listarBacklogList(List<Backlog> backlogList) {
    foreach (Backlog backlog in backlogList) {
        Console.WriteLine("Tipo: " + backlog.getType());
        System.Console.WriteLine("Status: " + backlog.getStatus());
        System.Console.WriteLine("ID: " + backlog.getID());
        System.Console.WriteLine();
        }
    }       
}