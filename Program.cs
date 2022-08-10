using taskCLI.Services;
using taskCLI.Models;
using Newtonsoft.Json;

var databaseService = new TasksService();

switch (args[0]){

    case "--new":
        Tasks element = new Tasks() { 
            title = args[1], 
            description = args[2]
        };

        await databaseService.CreateTask(element);
        
        Console.WriteLine("Added Succesfully");
    break;

    case "--list": 
        var lst = await databaseService.GetTasks();
        if(lst.Count == 0){
            Console.WriteLine("List empty");
        } else {
            string json = JsonConvert.SerializeObject(lst, Formatting.Indented);
            
            Console.WriteLine(json);
        }
        
    break;

    case "--delete": 
        await databaseService.RemoveTask(args[1]);
        
        Console.WriteLine("Removed Succesfully");
    break;

    case "--update": 
        Tasks updateElement = new Tasks(){ 
            id = args[1], 
            title = args[2], 
            description = args[3]
        };
        
        await databaseService.UpdateTask(args[1], updateElement);
        
        Console.WriteLine("Updated Succesfully");
    break;

    case "--show": 
        var lstOne = await databaseService.GetTask(args[1]);
        
        string JsonOne = JsonConvert.SerializeObject(lstOne, Formatting.Indented);
        
        Console.WriteLine(JsonOne);
    break;

    case "--options": 
        string helpOption = $@"Opciones: 
        --new [TITLE] [DESCRIPTION]:            Agrega un elemento
        --list:                                 Lista tareas guardadas
        --show [ID]:                            Muestra la tarea con el ID
        --delete [ID]:                          Elimina la tarea con el ID
        --update [ID] [TITLE] [DESCRIPTION]:    Actualiza los datos de la tarea con el ID";

        Console.WriteLine(helpOption);
    break;

}




