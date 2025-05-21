class Program{ 
    
    public static void Ingresar(ref string [,] parqueos, ref Vehiculo [,] vehiculos, int pisos, int parqueosPiso, int motos, int suv){

        Console.WriteLine("Ingrese el tipo de vehiculo que desea estacionar. Puede ser tipo sedan, suv o moto"); //Ingresar el tipo de vehiculo 
        string tipo = Console.ReadLine().ToLower();  
        bool valido = false; 

        if(tipo == "moto" || tipo == "suv" || tipo == "sedan"){ //Validar que el usuario haya ingresado un tipo de vehiculo aceptado 
            valido = true; 
        }


        while (!valido){
            Console.WriteLine("Ingrese nuevamente el tipo de vehiculo que desea estacionar"); 
            tipo = Console.ReadLine();

            if(tipo == "moto" || tipo == "suv" || tipo == "sedan"){
                valido = true; 
            }

        } //Verificar que el usuario ingrese un tipo de vehiculo valido para seguir el flujo del programa 

        Console.WriteLine("Ingrese la marca  de vehiculo que desea estacionar"); //Ingreso de la marca del vehiculo 
        string marca = Console.ReadLine(); 

        Console.WriteLine("Ingrese el color de vehiculo que desea estacionar"); //Ingreso del color del vehiculo 
        string color = Console.ReadLine(); 

        Console.WriteLine("Ingrese la placa del vehiculo que desea estacionar. Debe de estar en mayusculas y tener 6 caracteres"); //Ingreso de la placa del vehiculo 
        string placa = Console.ReadLine();   
        bool placaValida = false; 

        if (placa.Length == 6 && placa == placa.ToUpper()){ 
            placaValida = true; 
        } //Validar que la placa tenga solamente 6 caracteres 

        while (!placaValida){
            Console.WriteLine("Ingrese nuevamente la placa del vehiculo que desea estacionar. Debe de estar en mayusculas y tener 6 caracteres"); 
            placa = Console.ReadLine();   

            if (placa.Length == 6 && placa == placa.ToUpper()){ 
                placaValida = true; 
            }      
        } //Validar que la placa ingresada esté en mayusculas 

         
        Random numero = new Random(); 
        int hora = numero.Next(5,21); //Se genera la hora de entrada aleatoriamente entre 5 y 20 
        int sumaMotos = 0;
        int sumaSuv = 0;  
        int sumaVehiculos = 0;  

        
        for (int i=0; i<pisos; i++){ //Mostrar la matriz del estacionamiento con los codigos de parqueo en los que se puede estacionar el tipo de vehiculo ingresado, de manera que se muestra el codigo de los parqueos disponibles y con una X en los que no se puede estacionar 
            for (int j=0; j<parqueosPiso; j++){ 
                if(tipo == "moto"){ //Se muestra el codigo solamente de los parqueos que esten disponibles y que sean para moto 
                    if (sumaMotos<motos && parqueos[i,j] != "X"){
                        Console.Write(parqueos[i,j] + "\t"); 
                    }
                    else{
                        Console.Write("X" + "\t");
                    }
                    sumaMotos++; 
                }
                if(tipo == "suv"){ //Se muestra el codigo solamente de los parqueos que esten disponibles y que sean para suv 
                    if (sumaSuv<suv && sumaMotos >= motos && parqueos[i,j] != "X"){
                        Console.Write(parqueos[i,j] + "\t");
                        sumaSuv++;
                    }
                    else{
                        Console.Write("X" + "\t");
                    }
                    sumaMotos++; 

                }
                if(tipo == "sedan"){//Se muestra el codigo solamente de los parqueos que esten disponibles y que sean para sedan 
                    if(sumaVehiculos>= (motos+suv) && parqueos[i,j] != "X"){
                        Console.Write(parqueos[i,j] + "\t");
                    }else{
                        Console.Write("X" + "\t");
                    } 
                    sumaVehiculos++; 
                }
            }
            Console.Write("\n");
        } 

        Console.WriteLine("Ingrese el codigo del parqueo en el que desea estacionar su vehiculo"); //Ingresar el codigo de parqueo en el que se estacionara el vehiculo ingresado 
        string codigo = Console.ReadLine(); 
        bool asignado = false;
        int suma = 1; 
        for (int i = 0; i < pisos; i++)
        {
            for (int j = 0; j < parqueosPiso; j++)
            {
                if (parqueos[i, j] == codigo)//Se busca el codigo del parqueo ingresado dentro de la matriz de parqueo. 
                {
                    if ((tipo == "moto" && suma <= motos) || (tipo == "suv" && suma > motos && suma <= (motos + suv)) || (tipo == "sedan" && suma > (motos + suv)))
                    {
                        Vehiculo vehiculo = new Vehiculo(parqueos[i, j], tipo, marca, color, placa, hora);
                        vehiculos[i, j] = vehiculo;
                        parqueos[i, j] = "X";
                    }
                    else
                    {
                        Console.WriteLine("El tipo de vehiculo ingresado no puede ser asignado en el parqueo seleccionado");

                    }//Se valida que realmente el tipo de vehiculo ingresado se pueda estacionar en el codigo de parqueo ingresado 
                    asignado = true; 

                }
                suma++;

            }
        } 
        if(!asignado){
            Console.WriteLine("Estacionamiento ocupado");
        } //Se indica que el parqueo ingresado esta ocupado en caso se haya ingresado el codigo de un parqueo ocupado 

    }

    public static void IngresarLote(ref string [,] parqueos, ref Vehiculo [,] vehiculos, int pisos, int parqueosPiso, int motos, int suv){
        Random numero = new Random();  
        int cantidad = numero.Next(2,7); //Se genera automaticamente la cantidad de vehiculo que tendrá el lote a ingresar 
        for (int k = 0; k<cantidad; k++){
            string [] marcas = ["Honda","Mazda","Hyundai","Toyota","Suzuki"]; //Posibles marcas
            string [] colores = ["Rojo","Azul","Gris","Blanco"]; //Posibles colores 
            string [] tipos  = ["moto","sedan","suv"]; //Posibles tipos de vehiculo   
            string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //Letras para asignarle un codigo a cada estacionamiento 
            Random numero1 = new Random(); 
            int hora = numero1.Next(5,21); //Se genera aleatoriamente la hora de ingreso de cada vehiculo del lote 
            Random numero2 = new Random(); 
            string placa = "P" + numero2.Next(100,999).ToString() + abecedario[numero.Next(0,25)] + abecedario[numero1.Next(0,25)] + abecedario[numero2.Next(0,25)];  //Se genera automaticamente la placa de cada vehiculo en el formato de las placas guatemaltecas 

            Random indice = new Random(); 
            int indiceMarca = indice.Next(0,5); 
            int indiceColor = indice.Next(0,4);
            int indiceTipo = indice.Next(0,3); 

            string marca = marcas[indiceMarca]; //Se asigna automaticamente una marca del listado de marcas  
            string color = colores[indiceColor]; //Se asigna automaticamente un color a cada vehiculo del listado de colores 
            string tipo = tipos[indiceTipo]; //Se asigna automaticamente un tipo de vehiculo a cada vehiculo del lista de tipos 


            int sumaMotos = 0;
            int sumaSuv = 0;  
            int sumaVehiculos = 0; 
            bool disponible = true;  //Variable para comprobar que el estacionamiento ingresado realmente esté disponible 

            for (int i=0; i<pisos; i++){
                for (int j=0; j<parqueosPiso; j++){ 
                    if(tipo == "moto"){ //Se asignan los vehiculos tipo moto a los parqueos correspondientes a las motos 
                        if (sumaMotos<motos && parqueos[i,j] != "X"){
                            if (disponible){
                                Vehiculo vehiculo = new Vehiculo(parqueos[i,j],tipo,marca,color,placa,hora);
                                parqueos[i,j] = "X";
                                vehiculos[i,j] = vehiculo;
                                disponible = false; 
                                vehiculo.Mostrar(); 
                                Console.Write("\n"); 
                            }   
                        }
                        sumaMotos++; 
                    }
                    if(tipo == "suv"){ //Se asignan los vehiculos tipo suv a los parqueos correspondientes a los vehiculos tipo suv 
                        if (sumaSuv<suv && sumaMotos >= motos && parqueos[i,j] != "X"){
                            if (disponible){
                                Vehiculo vehiculo = new Vehiculo(parqueos[i,j],tipo,marca,color,placa,hora);
                                parqueos[i,j] = "X";
                                vehiculos[i,j] = vehiculo;
                                disponible = false;
                                vehiculo.Mostrar(); 
                                Console.Write("\n"); 
                            }
                            sumaSuv++;
                        }
                        sumaMotos++; 

                    }
                    if(tipo == "sedan"){ //Se asignan los vehiculo tipo sedan a los parqueos correspondientes a los vehiculos tipo sedan
                        if(sumaVehiculos>= (motos+suv) && parqueos[i,j] != "X"){
                            if (disponible){
                                Vehiculo vehiculo = new Vehiculo(parqueos[i,j],tipo,marca,color,placa,hora);
                                parqueos[i,j] = "X";
                                vehiculos[i,j] = vehiculo;
                                disponible = false;
                                vehiculo.Mostrar(); 
                                Console.Write("\n"); 
                            }
                        }
                        sumaVehiculos++; 
                    }
                }
            }

           

        }

        for (int i=0; i<pisos;i++){ //Se muestra la matriz de estacionamientos actualizada sin el vehiculo que se retiró 
            for (int j=0; j<parqueosPiso;j++){
                Console.Write(parqueos[i,j] + "\t");
            } 
            Console.Write("\n");
        }  

    }

    public static void Buscar(ref string [,] parqueos, ref Vehiculo [,] vehiculos, int pisos, int parqueosPiso){
        Console.WriteLine("Ingrese el numero de placa de su vehiculo"); 
        string buscarPlaca = Console.ReadLine();  //Se ingresa la placa del vehiculo a buscar 
        bool existe = false; 
        for (int i=0; i<pisos;i++){ //Se recorre toda la matriz de vehiculo. Al encontrar la placa del vehiculo, se accede a su metodo de mostrar, para que se muestre toda su informacion (atributos)
            for (int j=0; j<parqueosPiso;j++){
                if (parqueos[i,j] == "X"){
                    if (vehiculos[i,j].Placa == buscarPlaca ){
                        vehiculos[i,j].Mostrar();  
                        existe = true; 
                    }
                    
                }
            } 
        } 

        if (!existe){
            Console.WriteLine("No existe"); //Si la placa ingresada no existe, se le notifica al usuario 
        }   

    }

    public static void Retirar(ref string [,] parqueos, ref Vehiculo [,] vehiculos, int pisos, int parqueosPiso){
        Console.WriteLine("Ingrese el codigo del parqueo en donde estacionó su vehiculo"); 
        string buscarParqueo = Console.ReadLine(); //Se ingresa el codigo del estacionamiento del vehiculo que se desea retirar 
        int registroHora = 0;
        bool ocupado = false; 
        for (int i = 0; i < pisos; i++) //Se recorre la matriz con los vehiculos, se accede al atributo del codigo de cada vehiculo y se compara con el codigo de parqueo ingresado.
        {
            for (int j = 0; j < parqueosPiso; j++)
            {
                if (parqueos[i, j] == "X")
                {
                    if (vehiculos[i, j].Codigo == buscarParqueo) //Al encontrar el codigo ingreado se almacena la hora de entrada para calcular cuanto debe de pagar el usuario y se coloca un objeto vacío en el lugar en donde estaba el vehiculo que salio del parqueo 
                    {
                        registroHora = vehiculos[i, j].Hora;
                        parqueos[i, j] = vehiculos[i, j].Codigo;
                        vehiculos[i, j] = null;
                        ocupado = true; //Se valida que el lugar relamente este ocupado para notificarle al usuario si el codigo de parqueo ingresado estaba vacío 

                    }
                }
            }
        }

        if (ocupado)
        {
            
            int horas = 24 - registroHora;
            int costo;
            int pagoTotal = 0;

            if (horas > 0 && horas <= 1) //Calculo de la tarifa que debe de pagar el usuario 
            {
                costo = 0;
            }
            else if (horas >= 2 && horas <= 4)
            {
                costo = 15;
            }
            else if (horas >= 5 && horas <= 7)
            {
                costo = 45;
            }
            else if (horas >= 8 && horas <= 11)
            {
                costo = 60;
            }
            else
            {
                costo = 150;
            }
            bool opcionValida = false; 
            Console.WriteLine("Opciones de pago: \n1. Efectivo \n2.Tarjeta \n3.Sticker"); //Se le pregunta al usuario si desea pagar con efectivo 
            int opcionPago = int.Parse(Console.ReadLine()); //Se selecciona el metodo de pago 

            while (!opcionValida)
            {
                switch (opcionPago)
                {
                    case 1:
                        while (pagoTotal < costo) //El programa no continua hasta que el usuario haya pagado totalmente la tarifa establecida 
                        {
                            Console.WriteLine($"Debe de pagar:Q{costo - pagoTotal} \nIngrese pago con billetes de Q100, Q50, Q20, Q10 o Q5");
                            int pago = int.Parse(Console.ReadLine());
                            if (pago == 5 || pago == 10 || pago == 20 || pago == 50 || pago == 100)
                            {
                                pagoTotal = pagoTotal + pago;
                            }
                            else
                            {
                                Console.WriteLine("Solamente se admiten billetes de Q100, Q50, Q20, Q10 o Q5");
                            }
                        }

                        int vuelto = pagoTotal - costo;
                        Console.WriteLine($"Vuelto  Q: {vuelto}"); //Se calcula el vuelto en caso el usuario haya pagado con mas dinero. 
                        Console.WriteLine("Feliz viaje");
                        opcionValida = true;
                        break;

                    case 2:
                        Console.WriteLine("Feliz viaje");
                        opcionValida = true;
                        break;
                    case 3:
                        Console.WriteLine("Feliz viaje");
                        opcionValida = true;
                        break;

                    default:
                        Console.WriteLine("Ingrese una opcion válida");
                        break;

                }
            }
            

            for (int i = 0; i < pisos; i++) //Se muestra la matriz de parqueos actualizada sin el vehiculo anteriormente retirado 
                {
                    for (int j = 0; j < parqueosPiso; j++)
                    {
                        Console.Write(parqueos[i, j] + "\t");
                    }
                    Console.Write("\n");
                }
                
        }
        else
        {
            Console.WriteLine("No hay vehiculos en el codigo de parqueo ingresado"); //Si no hay ningun vehiculo en el codigo del parqueo ingresado, se le notifica al usuario. 
        }

    }


    public static void Main (string [] args){
        Console.WriteLine("Proyecto No. 2. Manuel Ruiz. Estacionamientos");  
        Console.WriteLine("Ingrese cantidad de pisos del estacionamiento "); 
        int pisos = int.Parse(Console.ReadLine());  //Cantidad de pisos del parqueo (cantidad de filas de la matriz)

        while (pisos > 27 ){
            Console.WriteLine("Ingrese cantidad de pisos del estacionamiento "); 
            pisos = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Ingrese cantidad de estacionamientos en cada piso "); 
        int parqueosPiso = int.Parse(Console.ReadLine());   //Cantidad de parqueos por piso (cantidad de columnas de la matriz)


        Console.WriteLine("Cantidad de parqueos tipo moto: ");  //Cantidad de parqueos de moto
        int motos = int.Parse(Console.ReadLine()); 

        Console.WriteLine("Cantidad de parqueos tipo SUV: ");  //Cantidad de parqueos de vehiculo tipo suv 
        int suv = int.Parse(Console.ReadLine());  

        while ((motos+suv) > ((pisos*parqueosPiso)) ){  //Validar que el usuario no ingrese una cantidad mayor de parqueos para moto o suv que la cantidad de parqueos que tiene el estacionamiento
            Console.WriteLine("La cantidad de parqueos requerida para vehiculos tipo suv y moto, sobrepasa la capacidad del parqueo "); 

            Console.WriteLine("Ingrese nuevamente la cantidad de parqueos tipo moto: "); 
            motos = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Ingrese nuevamente la cantidad de parqueos tipo SUV: "); 
            suv = int.Parse(Console.ReadLine()); 
        }
 
        string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //String que sera utilizado posteriormente para asignarle un codigo a cada parqueo 

        string [,] parqueos = new string [pisos,parqueosPiso]; //Matriz de strings con los codigos de los parqueos que se mostrará al usuario

        Vehiculo [,] vehiculos = new Vehiculo [pisos,parqueosPiso]; //Matriz de vehiculos, tipo vehiculo. En ella estará cada vehiculo con sus atributos y métodos. 

        for (int i=0; i<pisos; i++){  //Inicializacion de codigos para todos los parqueos 
            for (int j=0; j<parqueosPiso; j++){
                parqueos[i,j] = abecedario[i] + (j+1).ToString(); 
            }
        } 

          
        bool seguir = true; //Variable utilizada para verificar cuando el usuario desea salir 
        
        while(seguir){
            Console.WriteLine($"Ingrese la opcion a realizar: \n1.Ingresar vehiculo individual \n2.Ingresar lote de vehiculos  \n3.Buscar vehiculo por placa \n4.Retirar vehiculo \n5.Salir"); 
            int opcion =int.Parse(Console.ReadLine()); //Menu de opciones 
            switch(opcion){
                case 1: 
                    Ingresar(ref parqueos, ref vehiculos,pisos,parqueosPiso,motos,suv); //Funcion para ingresar un vehiculo individualmente 
                    break; 
                
                case 2: 
                    IngresarLote(ref parqueos,ref vehiculos,pisos,parqueosPiso,motos,suv); //Funcion para ingresar un lote de vehiculos entre 2 a 6 vehiculos
                    break; 
                
                case 3: 
                    Buscar(ref parqueos,ref vehiculos,pisos,parqueosPiso); //Funcion para buscar un vehiculo por su placa 
                    break; 
                
                case 4: 
                    Retirar(ref parqueos,ref vehiculos,pisos,parqueosPiso);  //Funcion para retirar un vehiculo en el codigo de parqueo ingresado  
                    break; 
                
                case 5: 
                    seguir = false; //Opcion para salir del programa 
                    break; 


                default: 
                    Console.WriteLine("Solamente existen 4 opciones numeradas del 1 al 4 de las acciones que puedes realizar. \nIngresa uno de estos numeros para poder continuar"); //Validar que el usuario solamente ingrese opciones validas 
                    break; 

            }
        }

        
    }

} 


