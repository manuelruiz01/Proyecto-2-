class Vehiculo{
    public string Codigo {get; set;} 
    public string Tipo {get; set;}
    public string Marca {get; set; } 
    public string Color {get; set; }
    public string Placa {get; set; } 
    public int Hora {get; set; }  

    public Vehiculo (string codigo, string tipo, string marca, string color, string placa, int hora){
        Codigo = codigo; 
        Tipo = tipo; 
        Marca = marca; 
        Color = color; 
        Placa = placa; 
        Hora = hora; 
    } 

    public void Mostrar(){
        Console.WriteLine($"Codigo de parqueo: {Codigo}");
        Console.WriteLine($"Tipo de vehiculo: {Tipo}");
        Console.WriteLine($"Marca: {Marca}"); 
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Placa: {Placa}");
        Console.WriteLine($"Hora de entrada: {Hora}");
    }

}