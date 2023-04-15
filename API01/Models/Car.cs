using API01.CustomValidator;

namespace API01.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Model { get; set; } = string.Empty;  
        [MinProductionDate(ErrorMessage = "Can not add production date in the future")]
        public DateTime productionDate { get; set; }
        public string Type { get; set; } = string.Empty;
        public Car() { }
        public Car(int id, string? name, string? model, DateTime productionDate)
        {
            Id = id;
            Name = name;
            Model = model;
            this.productionDate = productionDate;
        }

       
        public override string ToString()
        {
            return $"Car Object\nID:{Id}\nName:{Name}\nModel:{Model}\nProduction Date:{productionDate}";
        }
    }
}
