using MongoDB.Driver;
using taskCLI.Models;

namespace taskCLI.Services;
class TasksService {

    private string ConnectionString = "mongodb://localhost:27018";
    private string DatabaseName = "tasks";
    private string CollectionName = "tasks";

    private readonly IMongoCollection<Tasks> tasksCollection;

    public TasksService(){
        var client = new MongoClient(ConnectionString);
        var database = client.GetDatabase(DatabaseName);

        tasksCollection = database.GetCollection<Tasks>(CollectionName);

    }

    public async Task CreateTask(Tasks task) => await tasksCollection.InsertOneAsync(task);

    public async Task<List<Tasks>> GetTasks() => await tasksCollection.Find(d => true).ToListAsync(); 

    public async Task RemoveTask(string id) => await tasksCollection.DeleteOneAsync(x => x.id == id);

    public async Task UpdateTask(string id, Tasks updatetask) => await tasksCollection.ReplaceOneAsync(x => x.id == id, updatetask);

    public async Task<Tasks> GetTask(string id) => await tasksCollection.Find(x => x.id == id).FirstOrDefaultAsync();
}