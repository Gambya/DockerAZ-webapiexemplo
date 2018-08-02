namespace WebApiCoreExemplo.Model
{
    public class Aluno
    {
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}